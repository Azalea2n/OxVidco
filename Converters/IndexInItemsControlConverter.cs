using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace OxVidco.Converters;

public class IndexInItemsControlConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var item = (DependencyObject)value!;
        var itemsControl = ItemsControl.ItemsControlFromItemContainer(item);
            
        if (itemsControl == null) 
            return string.Empty;

        if (true)
        {
            var index = itemsControl.ItemContainerGenerator.IndexFromContainer(item) + 1;
            return index > 0 ? index.ToString() : string.Empty;
        }
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException("ConvertBack is not supported");
    }
}