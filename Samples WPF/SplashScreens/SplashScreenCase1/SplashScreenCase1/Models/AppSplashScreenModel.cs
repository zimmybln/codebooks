using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using SplashScreenCase1.Contracts;
using WPFArchitectureModel.Library.Commands;
using WPFArchitectureModel.Library.Models;

namespace SplashScreenCase1
{
    public class AppSplashScreenModel : ViewModelBase, ISplashScreenInfo
    {

        public AppSplashScreenModel()
        {

        }

        public string Status
        {
            get { return GetValue("Status", String.Empty); }
            set { SetValue("Status", value); }
        }

        public ICommand CancelCommand { get; set; }
    }
}
