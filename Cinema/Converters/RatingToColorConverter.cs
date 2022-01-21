using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Cinema.Converters
{
    internal class RatingToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double number = (double)System.Convert.ChangeType(value, typeof(double));

            SolidColorBrush color = ColorBrush("#4287f5");

            if (number < 5)
                color = ColorBrush("#ff6161");

            if (number >= 5 && number < 7.5)
                color = ColorBrush("#ffc052");

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack not supported");
        }

        public SolidColorBrush ColorBrush(string value)
        {
            return new((Color)ColorConverter.ConvertFromString(value));
        }
    }
}
