using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ImageExplorer.Foundation
{
    [ValueConversion(typeof(int), typeof(double))]
    public class IntegerToDoubleConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return value;

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? nValue = null;

            if (value != null)
            {
                nValue = System.Convert.ToInt32(value);
            }



            return nValue;

        }
    }
}
