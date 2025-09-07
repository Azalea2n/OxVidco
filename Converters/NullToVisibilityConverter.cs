using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OxVidco.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isInverse = parameter is string paramString && paramString.ToLower() == "inverse";
            
            // Cek apakah parameter berisi "inverse"

            bool isNull = value == null || (value is string str && string.IsNullOrEmpty(str));
            
            if (isInverse)
            {
                return isNull ? Visibility.Visible : Visibility.Collapsed;
            }
            
            return isNull ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
