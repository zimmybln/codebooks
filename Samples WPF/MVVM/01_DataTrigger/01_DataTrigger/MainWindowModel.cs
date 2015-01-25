using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace UseCase_01_DataTrigger
{
    public class MainWindowModel : INotifyPropertyChanged
    {

        private string mv_strEnvironmentInfo;
        private bool mv_fState = false;

        public MainWindowModel()
        {
            mv_strEnvironmentInfo = String.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string EnvironmentInfo
        {
            get { return mv_strEnvironmentInfo; }
            set
            { 
                mv_strEnvironmentInfo = value;
                RaisePropertyChanged("EnvironmentInfo");
            }
        }

        public bool State
        {
            get { return mv_fState; }
            set
            {
                mv_fState = value;
                RaisePropertyChanged("State");
            }
        }

        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler h = this.PropertyChanged;

            if (h != null)
                h(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
