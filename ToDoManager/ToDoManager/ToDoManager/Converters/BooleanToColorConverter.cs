using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ToDoManager.Converters
{
    class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                {
                    return Color.WhiteSmoke;
                }
                else
                {
                    return Color.White;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
