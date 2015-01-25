using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SplashScreenCase1.Contracts
{
    public interface ISplashScreenInfo
    {
        string Status { get; set; }

        ICommand CancelCommand { get; set; }
    }
}
