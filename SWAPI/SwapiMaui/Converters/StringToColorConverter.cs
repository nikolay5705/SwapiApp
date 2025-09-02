using System.Globalization;
using SwapiMaui.ColorsPalette;

namespace SwapiMaui.Converters;

public class StringToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string colorName && ColorsPalette.ColorsPalette.ColorHexMap.TryGetValue(colorName, out var hex))
        {
            return Color.FromArgb(hex);
        }

        return Colors.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}