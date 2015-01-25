using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ControlWorkbenchButton.Contracts;

namespace ControlWorkbenchButton.Modules
{
    public class AdjustedButtonFactory : IApplicationItemFactory
    {
        private object _viewModule;
        private ImageSource _moduleImage;

        public string Name
        {
            get { return "Angepasster Button"; }
        }

        public ImageSource Image
        {
            get
            {
                if (_moduleImage == null)
                {
                    _moduleImage = new BitmapImage(new Uri("..\\..\\Resources\\Module1.png", UriKind.RelativeOrAbsolute));
                }

                return _moduleImage;
            }

        }

        public object Item
        {
            get { return _viewModule ?? (_viewModule = new AdjustedButtonView()); }
        }
    }
}
