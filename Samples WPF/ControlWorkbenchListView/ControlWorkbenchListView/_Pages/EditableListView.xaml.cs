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
    /// Interaction logic for EditableListView.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class EditableListView : Page, IUseCaseView
    {
        private readonly ObservableCollection<Person> mv_colPersons;
        private readonly ObservableCollection<string> mv_colCities;


        public EditableListView()
        {
            mv_colPersons = new ObservableCollection<Person>();
            mv_colCities = new ObservableCollection<string> {"Berlin", "Paris", "Rome", "Liverpool"};

            InitializeComponent();
            
            // Erstellung der Listen
            mv_colPersons.Add(new Person { FirstName = "Torsten", City = "Berlin", PortraitName = "Torsten", Group = 2});
            mv_colPersons.Add(new Person {FirstName = "John", City = "Liverpool", PortraitName = "John", Group = 3});

            lsvPersons.ItemsSource = Persons;
        }

        public ObservableCollection<Person> Persons
        {
            get { return mv_colPersons; }
        }

        public ObservableCollection<string> Cities
        {
            get { return mv_colCities; }
        }


        public object View
        {
            get { return this; }
        }

        public string Description { get { return "";  } }
    }
}
