using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.Converters
{
    public class BoolToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool b && b) ? "Not Done" : "Done";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
