using System.Windows;
// Referensi yang diperlukan untuk aplikasi

namespace OxVidco;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        try
        {
            // Set font default
            var defaultFont = new System.Windows.Media.FontFamily("Segoe UI");
            
            // Tambahkan resource yang diperlukan
            if (!Current.Resources.Contains("DefaultFont"))
            {
                Current.Resources.Add("DefaultFont", defaultFont);
            }
            
            // Atur warna default
            if (!Current.Resources.Contains("PrimaryColor"))
            {
                Current.Resources.Add("PrimaryColor", (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#7B1FA1"));
            }
            
            if (!Current.Resources.Contains("SecondaryColor"))
            {
                Current.Resources.Add("SecondaryColor", (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#CDDC39"));
            }
        }
        catch (Exception ex)
        {
            // Log error jika diperlukan
            System.Diagnostics.Debug.WriteLine($"Error in App startup: {ex.Message}");
        }
    }
}