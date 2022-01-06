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

            if (number < 5)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff6161"));

            if (number >= 5 && number < 7.5)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffc052"));

            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4287f5"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack not supported");
        }
    }
}
