using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using OxVidco.Commands;
using OxVidco.Models;
using WinForms = System.Windows.Forms;

namespace OxVidco;

/// <summary>
/// Kelas untuk merepresentasikan item video dalam daftar
/// </summary>
public class VideoFile : INotifyPropertyChanged
{
    private string _status = "Menunggu";

    private string _filePath = string.Empty;
    public string FilePath
    {
        get => _filePath;
        set
        {
            _filePath = value;
            OnPropertyChanged(nameof(FileName));
            OnPropertyChanged(nameof(FileExtension));
            OnPropertyChanged(nameof(FileSize));
        }
    }

    public string FileName => Path.GetFileName(FilePath);
    public string FileExtension => Path.GetExtension(FilePath).ToUpper().TrimStart('.');
    public double FileSize => string.IsNullOrEmpty(FilePath) ? 0 : new FileInfo(FilePath).Length / (1024.0 * 1024.0); // Ukuran dalam MB

    public string Status
    {
        get => _status;
        set
        {
            _status = value;
            OnPropertyChanged(nameof(Status));
        }
    }

#nullable disable
    public event PropertyChangedEventHandler PropertyChanged;
#nullable restore

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

/// <summary>
/// Kelas helper untuk menangani operasi FFmpeg
/// </summary>
public static class FFmpegHelper
{
    private static bool _initialized;
    private static string _ffmpegPath = string.Empty; // Inisialisasi dengan nilai default

    public static void Initialize()
    {
        if (!_initialized)
        {
            // Set path ke direktori FFmpeg
            var rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg");
            var libraryPath = Path.Combine(rootPath, "x64"); // Selalu gunakan x64 karena kita sudah set platform target ke x64
                
            // Set path ke executable FFmpeg
            _ffmpegPath = Path.Combine(libraryPath, "ffmpeg.exe");
                
            // Verifikasi file FFmpeg ada
            if (!File.Exists(_ffmpegPath))
            {
                throw new FileNotFoundException("File FFmpeg tidak ditemukan. Pastikan FFmpeg sudah terinstall di folder yang benar.", _ffmpegPath);
            }
                
            _initialized = true;
        }
    }

    public static string GetFFmpegPath()
    {
        if (!_initialized)
            throw new InvalidOperationException("FFmpeg belum diinisialisasi. Panggil Initialize() terlebih dahulu.");
                
        return _ffmpegPath;
    }

    private static TimeSpan GetVideoDuration(string inputPath)
    {
        try
        {
            var ffprobePath = Path.Combine(Path.GetDirectoryName(_ffmpegPath) ?? string.Empty, "ffprobe.exe");
            var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = ffprobePath,
                    Arguments = $"-v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 \"{inputPath}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (double.TryParse(output, out double seconds))
            {
                return TimeSpan.FromSeconds(seconds);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error getting video duration: {ex.Message}");
        }

        return TimeSpan.Zero;
    }

    public static async Task<bool> ConvertVideoAsync(string inputPath, string outputPath, string format, int quality, IProgress<int>? progress = null, CancellationToken cancellationToken = default)
    {
        try
        {
            // Validasi input
            if (!File.Exists(inputPath))
                throw new FileNotFoundException("File input tidak ditemukan", inputPath);

            // Pastikan direktori output ada
            var outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Konfigurasi kualitas
            string qualityPreset = quality switch
            {
                0 => "-preset slow -crf 18",     // Kualitas Tinggi
                1 => "-preset medium -crf 23",   // Kualitas Standar
                _ => "-preset fast -crf 28"      // Kualitas Rendah
            };

            // Format output
            string formatArgs = format.ToLower() switch
            {
                "mp4" => "-c:v libx264 -c:a aac -movflags +faststart",
                "avi" => "-c:v mpeg4 -c:a libmp3lame -q:v 2 -q:a 2",
                "mkv" => "-c:v libx264 -c:a aac -f matroska",
                "mov" => "-c:v libx264 -c:a aac -f mov",
                "wmv" => "-c:v wmv2 -c:a wmav2",
                _ => "-c:v libx264 -c:a aac"
            };

            // Build perintah FFmpeg
            string args = $"-y -i \"{inputPath}\" {qualityPreset} {formatArgs} \"{outputPath}\"";

            // Dapatkan path ke FFmpeg
            var ffmpegPath = GetFFmpegPath();

            // Eksekusi FFmpeg
            var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = args,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                },
                EnableRaisingEvents = true
            };

            // Buat task completion source untuk menunggu proses selesai
            var tcs = new TaskCompletionSource<bool>();
                
            // Handler untuk event output
            process.ErrorDataReceived += (_, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    // Parsing progress dari output FFmpeg
                    // Format: frame= 1234 fps= 23 q=28.0 size=    5120kB time=00:00:41.00 bitrate=1023.0kbits/s speed=0.767x
                    if (e.Data.Contains("time="))
                    {
                        try
                        {
                            // Ambil bagian time=...
                            var timeStr = e.Data.Substring(e.Data.IndexOf("time=", StringComparison.Ordinal) + 5, 11).Trim();
                            if (TimeSpan.TryParse(timeStr, out var currentTime))
                            {
                                // Dapatkan durasi video
                                var duration = GetVideoDuration(inputPath);
                                if (duration.TotalSeconds > 0)
                                {
                                    // Hitung progress dalam persen
                                    int percent = (int)((currentTime.TotalSeconds / duration.TotalSeconds) * 100);
                                    percent = Math.Clamp(percent, 0, 100);
                                    progress?.Report(percent);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error parsing progress: {ex.Message}");
                        }
                    }
                }
            };

            process.Exited += (_, _) =>
            {
                tcs.TrySetResult(process.ExitCode == 0);
                process.Dispose();
            };

            // Mulai proses
            process.Start();
            process.BeginErrorReadLine();

            // Tunggu proses selesai atau dibatalkan
            using (cancellationToken.Register(() => 
                   {
                       try 
                       { 
                           if (!process.HasExited) 
                           {
                               process.Kill();
                           }
                       }
                       catch (Exception ex) when (ex is InvalidOperationException || ex is Win32Exception)
                       {
                           // Log error yang terjadi saat mencoba mematikan proses
                           System.Diagnostics.Debug.WriteLine($"Gagal menghentikan proses: {ex.Message}");
                       }
                       finally
                       {
                           tcs.TrySetCanceled();
                       }
                   }))
            {
                return await tcs.Task;
            }
        }
        catch (Exception ex)
        {
            // Log error
            System.Diagnostics.Debug.WriteLine($"Error during video conversion: {ex.Message}");
            throw;
        }
    }
}

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : INotifyPropertyChanged
{
    private readonly ObservableCollection<VideoFile> _videoFiles = new();
    private string _outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
    private ObservableCollection<FeatureCard> _featureCards = new();
    private ObservableCollection<HelpItem> _helpItems = new();

    public ObservableCollection<FeatureCard> FeatureCards
    {
        get => _featureCards;
        set
        {
            _featureCards = value;
            OnPropertyChanged();
        }
    }
        
    public ObservableCollection<HelpItem> HelpItems
    {
        get => _helpItems;
        set
        {
            _helpItems = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private bool _isProcessing;

    public MainWindow()
    {
        InitializeComponent();
        VideoList.ItemsSource = _videoFiles;
        OutputFolderTextBox.Text = _outputFolder;
            
        // Inisialisasi command
        new RelayCommand<string>(SearchHelp);
            
        // Inisialisasi daftar fitur dan bantuan
        InitializeFeatureCards();
        InitializeHelpItems();
            
        // Set data context
        DataContext = this;
    }

    private void AddFilesButton_Click(object sender, RoutedEventArgs _)
    {
        if (_isProcessing) return;

        var openFileDialog = new Microsoft.Win32.OpenFileDialog
        {
            Multiselect = true,
            Filter = "File Video|*.mp4;*.avi;*.mkv;*.mov;*.wmv|Semua File|*.*",
            Title = "Pilih File Video"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            foreach (var file in openFileDialog.FileNames)
            {
                if (!_videoFiles.Any(v => v.FilePath.Equals(file, StringComparison.OrdinalIgnoreCase)))
                {
                    _videoFiles.Add(new VideoFile { FilePath = file });
                }
            }
        }
    }

    private void BrowseFolderButton_Click(object sender, RoutedEventArgs _)
    {
        if (_isProcessing) return;

        var dialog = new FolderBrowserDialog
        {
            Description = "Pilih Folder Tujuan",
            SelectedPath = _outputFolder
        };

        if (dialog.ShowDialog() == WinForms.DialogResult.OK)
        {
            _outputFolder = dialog.SelectedPath;
            OutputFolderTextBox.Text = _outputFolder;
        }
    }

    private CancellationTokenSource? _cancellationTokenSource;

    private async void ConvertButton_Click(object sender, RoutedEventArgs e)
    {
        if (_isProcessing || !_videoFiles.Any()) return;

        _isProcessing = true;
        _cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = _cancellationTokenSource.Token;
            
        UpdateUiState();
            
        var format = (OutputFormatComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()?.ToLower() ?? "mp4";
        var quality = QualityComboBox.SelectedIndex; // 0: Tinggi, 1: Standar, 2: Rendah

        // Inisialisasi FFmpeg
        FFmpegHelper.Initialize();

        var progress = new Progress<int>(percent =>
        {
            Dispatcher.Invoke(() =>
            {
                ConversionProgress.Value = percent;
                StatusText.Text = $"Mengkonversi: {percent}%";
            });
        });

        for (int i = 0; i < _videoFiles.Count; i++)
        {
            if (cancellationToken.IsCancellationRequested)
                break;

            var video = _videoFiles[i];
            video.Status = "Sedang diproses...";
            VideoList.Items.Refresh();

            try
            {
                // Buat nama file output
                string outputFileName = Path.ChangeExtension(
                    Path.GetFileNameWithoutExtension(video.FilePath), 
                    $".{format.ToLower()}"
                );
                string outputPath = Path.Combine(_outputFolder, outputFileName);

                // Update status
                var i1 = i;
                Dispatcher.Invoke(() =>
                {
                    StatusText.Text = $"Mengkonversi {i1 + 1} dari {_videoFiles.Count}: {video.FileName}";
                    ConversionProgress.Value = 0;
                });

                // Lakukan konversi
                bool success = await FFmpegHelper.ConvertVideoAsync(
                    video.FilePath, 
                    outputPath,
                    format,
                    quality,
                    progress,
                    cancellationToken
                );

                video.Status = success ? "Selesai" : "Gagal: Proses konversi";
            }
            catch (OperationCanceledException)
            {
                video.Status = "Dibatalkan";
                break;
            }
            catch (Exception ex)
            {
                video.Status = $"Gagal: {ex.Message}";
                System.Diagnostics.Debug.WriteLine($"Error converting {video.FileName}: {ex.Message}");
            }
            finally
            {
                VideoList.Items.Refresh();
            }
        }

        _isProcessing = false;
        UpdateUiState();
            
        if (!cancellationToken.IsCancellationRequested)
        {
            StatusText.Text = "Konversi selesai";
            System.Windows.MessageBox.Show("Proses konversi selesai!", "Selesai", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            StatusText.Text = "Konversi dibatalkan";
        }
    }

    private void ClearButton_Click(object sender, RoutedEventArgs _)
    {
        if (_isProcessing) return;
        _videoFiles.Clear();
        ConversionProgress.Value = 0;
        StatusText.Text = "Siap";
    }

    // Koleksi untuk data bantuan
    private ObservableCollection<HelpItem> _basicHelpItems = new();
    private ObservableCollection<HelpItem> _tipsItems = new();
    private ObservableCollection<FAQItem> _faqItems = new();

    // Properti untuk binding
    public ObservableCollection<HelpItem> BasicHelpItems => _basicHelpItems;
    public ObservableCollection<HelpItem> TipsItems => _tipsItems;
    public ObservableCollection<FAQItem> FaqItems => _faqItems;

    // Command untuk pencarian bantuan

    private void InitializeHelpItems()
    {
        // Inisialisasi command
        new RelayCommand<string>(SearchHelp);

        // Panduan Dasar
        _basicHelpItems.Add(new HelpItem
        {
            Id = "add_files",
            Title = "Menambahkan File Video",
            Description = "Pelajari cara menambahkan file video ke dalam antrian konversi dengan mudah.",
            Steps = new ObservableCollection<string>
            {
                "Klik tombol 'Tambah File' di bagian atas jendela aplikasi",
                "Jelajahi dan pilih satu atau beberapa file video yang ingin dikonversi",
                "Klik 'Buka' untuk menambahkan file-file tersebut ke dalam antrian konversi",
                "File yang ditambahkan akan muncul dalam daftar dengan status 'Menunggu'"
            },
            ImagePath = "pack://application:,,,/Resources/Images/add_files.png",
            Category = HelpItem.HelpCategory.Basic
        });

        _basicHelpItems.Add(new HelpItem
        {
            Id = "select_format",
            Title = "Memilih Format Output",
            Description = "Cara memilih format output yang sesuai dengan kebutuhan Anda.",
            Steps = new ObservableCollection<string>
            {
                "Pilih file dari daftar yang ingin diubah formatnya",
                "Klik pada kolom 'Format' di baris file yang dipilih",
                "Pilih format yang diinginkan dari daftar dropdown (MP4, AVI, MKV, MOV, WMV)",
                "Format yang didukung: MP4 (Rekomendasi), AVI, MKV, MOV, WMV"
            },
            ImagePath = "pack://application:,,,/Resources/Images/select_format.png",
            Category = HelpItem.HelpCategory.Basic
        });

        // Tips & Trik
        _tipsItems.Add(new HelpItem
        {
            Id = "tip_quality",
            Title = "Kualitas Terbaik dengan Ukuran Minimal",
            Description = "Gunakan format H.265 (HEVC) untuk mendapatkan kualitas yang lebih baik dengan ukuran file yang lebih kecil dibanding H.264.",
            Icon = "VideoHighDefinition",
            Category = HelpItem.HelpCategory.Tips
        });

        _tipsItems.Add(new HelpItem
        {
            Id = "tip_batch",
            Title = "Konversi Banyak File Sekaligus",
            Description = "Anda bisa menambahkan banyak file sekaligus dengan menekan Ctrl+A atau menyeret kursor untuk memilih beberapa file.",
            Icon = "FileMultiple",
            Category = HelpItem.HelpCategory.Tips
        });

        // FAQ
        _faqItems.Add(new FAQItem
        {
            Question = "Berapa ukuran maksimal file yang didukung?",
            Answer = "Tidak ada batasan ukuran file. Aplikasi ini mendukung file berukuran besar, namun pastikan perangkat Anda memiliki ruang penyimpanan yang cukup."
        });

        _faqItems.Add(new FAQItem
        {
            Question = "Apakah kualitas video akan berkurang setelah dikonversi?",
            Answer = "Kualitas video bisa berkurang tergantung pada format dan pengaturan kualitas yang Anda pilih. Gunakan preset kualitas yang lebih tinggi untuk meminimalkan penurunan kualitas."
        });
    }

    private void SearchHelp(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            // Reset semua filter jika pencarian kosong
            foreach (var item in _basicHelpItems) item.IsExpanded = false;
            foreach (var item in _tipsItems) item.IsExpanded = false;
            foreach (var item in _faqItems) item.IsExpanded = false;
            return;
        }

        var searchQuery = searchText.ToLower();

        // Cari di Panduan Dasar
        foreach (var item in _basicHelpItems)
        {
            item.IsExpanded = item.Title.ToLower().Contains(searchQuery) ||
                              item.Description.ToLower().Contains(searchQuery) ||
                              string.Join(" ", item.Steps).ToLower().Contains(searchQuery);
        }

        // Cari di Tips & Trik
        foreach (var item in _tipsItems)
        {
            item.IsExpanded = item.Title.ToLower().Contains(searchQuery) ||
                              item.Description.ToLower().Contains(searchQuery);
        }

        // Cari di FAQ
        foreach (var item in _faqItems)
        {
            item.IsExpanded = item.Question.ToLower().Contains(searchQuery) ||
                              item.Answer.ToLower().Contains(searchQuery);
        }
    }

    private void InitializeFeatureCards()
    {
        FeatureCards = new ObservableCollection<FeatureCard>
        {
            new FeatureCard
            {
                Icon = "📁",
                Title = "Multi Format",
                Description = "Mendukung berbagai format video termasuk MP4, AVI, MKV, dan lebih banyak lagi"
            },
            new FeatureCard
            {
                Icon = "⚡",
                Title = "Cepat & Efisien",
                Description = "Proses konversi yang cepat dengan kualitas terbaik"
            },
            new FeatureCard
            {
                Icon = "🎯",
                Title = "Kualitas Terjaga",
                Description = "Hasil konversi dengan kualitas tinggi dan ukuran yang optimal"
            },
            new FeatureCard
            {
                Icon = "🔒",
                Title = "Aman & Privasi",
                Description = "File Anda aman dan tidak dikirim ke server manapun"
            }
        };
    }

    private void UpdateUiState()
    {
        Dispatcher.Invoke(() =>
        {
            AddFilesButton.IsEnabled = !_isProcessing;
            ConvertButton.IsEnabled = !_isProcessing && _videoFiles.Count > 0;
            CancelButton.IsEnabled = _isProcessing;
            ClearButton.IsEnabled = !_isProcessing && _videoFiles.Count > 0;
            BrowseFolderButton.IsEnabled = !_isProcessing;
            OutputFormatComboBox.IsEnabled = !_isProcessing;
            QualityComboBox.IsEnabled = !_isProcessing;
        });
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        if (!_isProcessing || _cancellationTokenSource == null) return;
            
        var result = System.Windows.MessageBox.Show("Apakah Anda yakin ingin membatalkan proses konversi?", 
            "Konfirmasi Pembatalan", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);
                
        if (result == MessageBoxResult.Yes)
        {
            _cancellationTokenSource.Cancel();
            StatusText.Text = "Membatalkan...";
        }
    }
}