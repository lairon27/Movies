using Cinema.Service;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Cinema.Converters
{
    internal class UseridToNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Guid id = (Guid)values[0];

            string name = id.ToString();

            DataManager manager = values[1] as DataManager;
            if (manager != null)
            {
                var user = manager.GetUserById(id);

                if (user != null)
                {
                    name = user.UserName;
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
