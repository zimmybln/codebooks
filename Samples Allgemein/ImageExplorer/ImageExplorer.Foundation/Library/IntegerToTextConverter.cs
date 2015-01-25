using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ImageExplorer.Foundation
{
    [ValueConversion(typeof(int), typeof(string))]
    public class IntegerToTextConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return value.ToString();

            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? nValue = null;

            if (value != null && !String.IsNullOrEmpty(value as string))
            {
                int nValueTemp = 0;

                if (int.TryParse(value as string, out nValueTemp))
                {
                    nValue = nValueTemp;
                }
            }



            return nValue;

        }
    }
}
