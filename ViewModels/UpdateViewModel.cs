using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using OxVidco.Commands;
using OxVidco.Models;
using OxVidco.Services;

namespace OxVidco.ViewModels
{
    public class UpdateViewModel : INotifyPropertyChanged
    {
        private readonly UpdateService _updateService;
        public ICommand CheckForUpdatesCommand { get; }

        public string CurrentVersion => GetCurrentVersion();

        private string _statusMessage = string.Empty;
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        private bool _isCheckingForUpdates;
        public bool IsCheckingForUpdates
        {
            get => _isCheckingForUpdates;
            set
            {
                _isCheckingForUpdates = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanCheckForUpdates));
            }
        }

        public bool CanCheckForUpdates => !IsCheckingForUpdates;

        private bool _isUpToDate;
        public bool IsUpToDate
        {
            get => _isUpToDate;
            set
            {
                _isUpToDate = value;
                OnPropertyChanged();
            }
        }

        private bool _hasUpdate;
        public bool HasUpdate
        {
            get => _hasUpdate;
            set
            {
                _hasUpdate = value;
                OnPropertyChanged();
            }
        }

        private UpdateInfo? _updateInfo;
        public UpdateInfo? UpdateInfo
        {
            get => _updateInfo;
            set
            {
                _updateInfo = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ViewModel yang digunakan untuk memeriksa pembaruan OxVidco.
        /// </summary>
        public UpdateViewModel()
        {
            _updateService = new UpdateService();
            CheckForUpdatesCommand = new RelayCommand<object>(
                async _ => await CheckForUpdatesAsync(),
                _ => !IsCheckingForUpdates
            );
            StatusMessage = "Klik tombol di bawah untuk memeriksa pembaruan.";
        }

        private async Task CheckForUpdatesAsync()
        {
            IsCheckingForUpdates = true;
            StatusMessage = "Memeriksa pembaruan...";
            
            try
            {
                var currentVersion = Version.Parse(CurrentVersion);
                var updateInfo = await _updateService.CheckForUpdatesAsync(currentVersion);
                
                if (updateInfo == null)
                {
                    StatusMessage = "Tidak dapat memeriksa pembaruan. Coba lagi nanti.";
                    return;
                }

                UpdateInfo = updateInfo;

                if (updateInfo.Version != null && updateInfo.Version > currentVersion)
                {
                    HasUpdate = true;
                    IsUpToDate = false;
                    StatusMessage = $"Versi terbaru {updateInfo.Version} tersedia!";
                }
                else
                {
                    HasUpdate = false;
                    IsUpToDate = true;
                    StatusMessage = "✓ Aplikasi sudah versi terbaru.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"❌ Gagal memeriksa pembaruan: {ex.Message}";
                Debug.WriteLine($"Error checking for updates: {ex}");
            }
            finally
            {
                IsCheckingForUpdates = false;
            }
        }


        private string GetCurrentVersion()
        {
            try
            {
                var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
                var version = assemblyName?.Version;
                if (version == null)
                    throw new InvalidOperationException("Versi assembly tidak ditemukan");
                    
                return $"{version.Major}.{version.Minor}.{version.Build}";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting version: {ex}");
                return "1.0.0"; // Nilai default jika terjadi error
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged = null!;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (PropertyChanged is null) return;
            try
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error on OnPropertyChanged: {ex}");
            }
        }
    }
}
