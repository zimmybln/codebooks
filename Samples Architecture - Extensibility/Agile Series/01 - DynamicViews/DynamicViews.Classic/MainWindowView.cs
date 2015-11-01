using DynamicViews.Classic.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DynamicViews.Classic
{
    public class MainWindowView : INotifyPropertyChanged
    {
        public List<ViewPartDescriptor> _lstViewParts = new List<ViewPartDescriptor>();

        public MainWindowView()
        {
            _lstViewParts.Add(new ViewPartDescriptor() { Name = "Klassische Ansicht" });
        }

        public List<ViewPartDescriptor> ViewParts { get { return _lstViewParts; } }

        
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            var p = PropertyChanged;
            if (p != null)
            {
                p(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

    }
}
