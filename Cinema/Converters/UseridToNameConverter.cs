using Cinema.Service;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Cinema.Converters
{
    internal class UseridToNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Guid id = (Guid)values[0];

            string name = id.ToString();

            if(values[1] != DependencyProperty.UnsetValue)
            {
                DataManager manager = (DataManager)values[1];

                if(manager.GetUsers.Any(i => i.UserId == id))
                {
                    name = manager.GetUserById(id).UserName;
                }
            }

            return name;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
