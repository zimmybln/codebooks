using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace AttachedAdorner
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private readonly ReorderAdapter mv_objAdapter;

        public MainWindowModel()
        {
            mv_objAdapter = new ReorderAdapter();
            mv_objAdapter.ReOrderColor = Colors.RosyBrown;
            mv_objAdapter.ReOrderWidth = 2;
        }

        public ReorderAdapter Reorder
        {
            get { return mv_objAdapter; }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string PropertyName)
        {
            var p = this.PropertyChanged;

            if (p != null)
                p(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
