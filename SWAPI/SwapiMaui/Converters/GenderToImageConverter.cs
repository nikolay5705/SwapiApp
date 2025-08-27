using System.Globalization;

namespace SwapiMaui.Converters;

public class GenderToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string gender)
        {
            gender = gender.ToLowerInvariant();
            return gender switch
            {
                "male" => "male_icon.png",
                "female" => "female_icon.png",
                _ => "na_icon.png"
            };
        }

        return "unknown_icon.png";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}