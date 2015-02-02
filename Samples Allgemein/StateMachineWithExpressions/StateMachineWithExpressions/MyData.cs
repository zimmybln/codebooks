using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{

    public enum ItemStates
    {
        Zero = 0,
        Between10And19 = 1,
        Between20And29 = 2
    }

    public interface IMyData
    {
        int i { get; set; }

        int j { get; set; }
    }


    public class MyData : IMyData
    {
        public int i { get; set; }

        public int j { get; set; }
    }

    public class MyDataWithNotifier : IMyData, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string memberName = null)
        {
            var p = PropertyChanged;

            if (p != null)
            {
                p(this, new PropertyChangedEventArgs(memberName));
            }
        }

        private int _i;

        public int i
        {
            get { return _i; }
            set
            {
                if (!_i.Equals(value))
                {
                    _i = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _j;

        public int j
        {
            get { return _j; }
            set
            {
                if (!_j.Equals(value))
                {
                    _j = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
