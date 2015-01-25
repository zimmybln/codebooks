using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyBinding
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private string _strItemCity;
        private AnyType _Item;

        internal MainWindowModel()
        {
            this.PropertyChanged += OnPropertyChanged;
            _strItemCity = "nichts ausgewählt";
        }

        private void OnPropertyChanged(object Sender, PropertyChangedEventArgs ChangedEventArgs)
        {
            // Auf die Änderung der Eigenschaft reagieren
            if (ChangedEventArgs.PropertyName == "Item")
                ItemCity = Item != null ? Item.City : String.Empty;
        }

        public AnyType Item
        {
            get { return _Item; }
            set
            {
                if (!object.Equals(value, _Item))
                {
                    _Item = value;
                    RaisePropertyChanged("Item");
                }
            }
        }
        
        public string ItemCity
        {
            get { return _strItemCity; }
            set
            {
                if (!String.Equals(_strItemCity, value))
                {
                    _strItemCity = value;
                    RaisePropertyChanged("ItemCity");
                }
            }
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
