using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ControlWorkbenchListView
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool fParameter = false;
            bool fValue = false;
            bool fTemp;

            if (parameter != null)
            {
                if (bool.TryParse((string)parameter, out fTemp))
                    fParameter = fTemp;
            }

            if (value != null)
            {
                fValue = (bool)value;
            }

            return fParameter == fValue ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
