using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApplication2
{
    class slideToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = System.Convert.ToByte(value);
            switch ((string)parameter)
            {
                case "red":  return new SolidColorBrush(Color.FromRgb(v, 0, 0));
                case "green": return new SolidColorBrush( Color.FromRgb(0,v, 0));
                case "blue": return new SolidColorBrush( Color.FromRgb(0, 0, v));
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
