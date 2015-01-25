using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyBinding
{
    public class ComboBoxModel : INotifyPropertyChanged 
    {

        internal ComboBoxModel()
        {
            SomeData = new ObservableCollection<AnyType>
                {
                    new AnyType() {FirstName = "Angelika", LastName = "Mustermann", City = "Hamburg"},
                    new AnyType() {FirstName = "Lars", LastName = "Beispiel", City = "München"}
                };
        }
        
        public ObservableCollection<AnyType> SomeData { get; private set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string PropertyName)
        {
            var p = this.PropertyChanged;

            if (p != null)
                p(this, new PropertyChangedEventArgs(PropertyName));
        }
    }

    public class AnyType
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }
    }
}
