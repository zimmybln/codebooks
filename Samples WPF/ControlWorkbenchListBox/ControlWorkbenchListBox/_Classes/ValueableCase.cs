using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace ControlWorkbenchListBox
{
    public class ValueableCase : INotifyPropertyChanged
    {
        private int _nAmount = 0;
        private string _strTitle;

        public ValueableCase(string title)
        {
            _strTitle = title;
        }

        public int Amount
        {
            get { return _nAmount; }
            set
            {
                if (!int.Equals(value, _nAmount))
                {
                    _nAmount = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Title
        {
            get { return _strTitle; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string MemberName = "")
        {
            var p = this.PropertyChanged;

            if (p != null)
                p(this, new PropertyChangedEventArgs(MemberName));
        }
        
    }
}
