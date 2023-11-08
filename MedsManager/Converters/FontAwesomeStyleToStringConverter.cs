using MedsManager.Models;
using System.Globalization;

namespace MedsManager.Converters;

class FontAwesomeStyleToStringConverter : IValueConverter
{
    const string FAB = "FAB";
    const string FAR = "FAR";
    const string FAS = "FAS";
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => (string)value switch
        {
            FAB => FontAwesomeStyle.Brand,
            FAR => FontAwesomeStyle.Regular,
            FAS => FontAwesomeStyle.Solid,
            _ => FontAwesomeStyle.Solid
        };

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => (FontAwesomeStyle)value switch
        {
            FontAwesomeStyle.Brand => FAB,
            FontAwesomeStyle.Regular => FAR,
            FontAwesomeStyle.Solid => FAS,
            _ => FAS
        };
}
