using Cinema.Service;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Cinema.Converters
{
    internal class MovieIdToTitleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Guid id = (Guid)values[0];

            string name = id.ToString();

            if(values[1] != DependencyProperty.UnsetValue)
            {
                DataManager manager = (DataManager)values[1];
                name = manager.GetMovieById(id).MovieName;
            }
 
            return name;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
