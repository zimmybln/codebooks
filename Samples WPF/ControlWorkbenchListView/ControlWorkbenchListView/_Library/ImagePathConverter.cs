using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ControlWorkbenchListView
{
    public class ImagePathConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string moduleName = "ControlWorkbenchListView"; // typeof(Person).GetType().Assembly.GetName().Name;
            string resourceLocation = string.Format("pack://application:,,,/{0};component/_Resources/{1}.png", moduleName, value as string);

            var bi = new BitmapImage();
            bi.BeginInit();
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bi.UriSource = new Uri(resourceLocation, UriKind.RelativeOrAbsolute);
            bi.EndInit();

            return bi;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
