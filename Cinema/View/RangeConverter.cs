using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Cinema.VM
{
    internal class RangeConverter : IValueConverter
    {
        public object Convert(
        object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            double number = (double)System.Convert.ChangeType(value, typeof(double));

            if (number < 5)
                return -1;

            if (number >= 5 && number < 7.5)
                return 0;

            return +1;
        }

        public object ConvertBack(
            object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack not supported");
        }
    }
}
