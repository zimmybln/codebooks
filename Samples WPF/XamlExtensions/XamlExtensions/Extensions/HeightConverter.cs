using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace XamlExtensions
{
    [ValueConversion(typeof(double), typeof(string))]
    public class HeightConverter : IValueConverter
    {
        #region IValueConverter Member

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strResult = String.Empty;

            if (value != null)
            {
                double dblValue = (double)value;

                if (dblValue == 0)
                    strResult = "ohne Angabe";
                else if (dblValue > 0 && dblValue <= 20)
                    strResult = "doch recht klein";
                else if (dblValue > 20 && dblValue < 80)
                    strResult = "mittelmäßige Höhe";
                else if (dblValue >= 80 && dblValue <= 100)
                    strResult = "ziemlich hoch";
                else
                {
                    strResult = "unbekannte Zuordnung";
                }
            }

            return strResult;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
