using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FMS.ViewModels.Converters
{
    public class BoolToRedGreyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush retColor = new()
            {
                Color = Colors.Black
            };
            if ((bool)value)
            {
                retColor.Color = Colors.LightGray;
            }
            else
            {
                retColor.Color = Colors.Red;
            }
            return retColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
