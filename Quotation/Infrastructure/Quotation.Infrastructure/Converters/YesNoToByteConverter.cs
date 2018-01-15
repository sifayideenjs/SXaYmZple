using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Quotation.Infrastructure.Converters
{
    [ValueConversion(typeof(string), typeof(byte))]

    public class YesNoToByteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is byte)
            {
                if ((byte)value == 1)
                    return "YES";
                else
                    return "NO";
            }
            return "NO";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return 0;

            switch (value.ToString().ToLower())
            {
                case "yes":
                    return 1;
                case "no":
                    return 0;
            }
            return false;
        }
    }
}
