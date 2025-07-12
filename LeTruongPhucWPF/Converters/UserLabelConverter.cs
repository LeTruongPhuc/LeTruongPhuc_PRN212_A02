using System;
using System.Globalization;
using System.Windows.Data;

namespace LeTruongPhucWPF.Converters
{
    public class UserLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool isAdmin && isAdmin ? "Username:" : "Phone:";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}