using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPFArchitectureModel.Library.Models;

namespace SplashScreenCase1.Models
{

    public class ShellModel : ViewModelBase
    {
        public UserControl LeftControl
        {
            get { return ((App) Application.Current).GetCommonControlInstance(0); }
        }

        public UserControl RightControl
        {
            get { return ((App) Application.Current).GetCommonControlInstance(4); }
        }
    }
}
