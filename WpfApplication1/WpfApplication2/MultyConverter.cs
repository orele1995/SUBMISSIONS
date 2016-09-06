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
   public class MultyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Byte red = System.Convert.ToByte(values[0]);
            Byte green = System.Convert.ToByte(values[1]);
            Byte blue = System.Convert.ToByte(values[2]);
            return new SolidColorBrush(Color.FromRgb(red, green, blue));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
