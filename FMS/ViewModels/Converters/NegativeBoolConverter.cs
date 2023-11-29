using System.Globalization;
using System.Windows.Data;

namespace FMS.ViewModels.Converters
{
    public class NegativeBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool negated = (bool)value;
            return !negated;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
