using System;
using System.Globalization;
using System.Windows.Data;

namespace Cinema.Converters
{
    internal class RatingToStarsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double number = (double)System.Convert.ChangeType(value, typeof(double));

            var amountOfStars = 5;

            if (number <= 2)
            {
                amountOfStars = 1;
            }

            if (number > 2 && number <= 4)
            {
                amountOfStars = 2;
            }

            if (number > 4 && number <= 6)
            {
                amountOfStars = 3;
            }

            if (number > 6 && number <= 8)
            {
                amountOfStars = 4;
            }

            return amountOfStars;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
