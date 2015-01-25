using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlWorkbenchListView
{
    /// <summary>
    /// Interaction logic for CustomView.xaml
    /// http://www.switchonthecode.com/tutorials/wpf-tutorial-using-the-listview-part-1
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class CustomView : Page, IUseCaseView
    {
        private readonly ObservableCollection<Person> mv_colPersons;

        public CustomView()
        {
            mv_colPersons = new ObservableCollection<Person>();

            InitializeComponent();

            Person p = new Person {FirstName = "Torsten", City = "Berlin", PortraitName = "Person"};
            
            // Erstellung der Listen
            mv_colPersons.Add(p);
            mv_colPersons.Add(new Person { FirstName = "John", City = "Liverpool", PortraitName="Person2" });
            mv_colPersons.Add(new Person { FirstName = "Paul", City = "Liverpool", PortraitName = "Person2" });

            lsvPersons.ItemsSource = Persons;
        }

        public ObservableCollection<Person> Persons
        {
            get { return mv_colPersons; }
        }

        public object View
        {
            get { return this; }
        }

        public string Description { get { return ""; } }

        private void OnViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem ciSelectedItem = (ComboBoxItem) cboViews.SelectedItem;

            ViewBase v = (ViewBase)this.FindResource(ciSelectedItem.Content);

            if (v != null)
                lsvPersons.View = v;
            
        }
    }
}
