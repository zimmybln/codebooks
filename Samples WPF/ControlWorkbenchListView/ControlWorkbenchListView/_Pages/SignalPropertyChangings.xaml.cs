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

namespace ControlWorkbenchListView._Pages
{
    /// <summary>
    /// Interaktionslogik für SignalPropertyChangings.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class SignalPropertyChangings : Page, IUseCaseView
    {
        // http://stackoverflow.com/questions/7211463/datatrigger-enteractions-beginstoryboard-not-beginning
        // http://msdn.microsoft.com/de-de/library/ms743659%28v=vs.110%29.aspx

        // http://msdn.microsoft.com/de-de/library/ms742536%28v=vs.110%29.aspx

        private readonly ObservableCollection<Person> mv_colPersons;

        public SignalPropertyChangings()
        {
            InitializeComponent();

            mv_colPersons = new ObservableCollection<Person>();

            // Erstellung der Listen
            mv_colPersons.Add(new Person { FirstName = "Torsten", City = "Berlin", PortraitName = "Torsten", Group = 2 });
            mv_colPersons.Add(new Person { FirstName = "John", City = "Liverpool", PortraitName = "John", Group = 3 });
            mv_colPersons.Add(new Person { FirstName = "Paul", City = "Liverpool", PortraitName = "Paul", Group = 1 });
            mv_colPersons.Add(new Person { FirstName = "George", City = "Berlin", PortraitName = "George", Group = 2 });

            lsvPersons.ItemsSource = mv_colPersons;
        }


        public string Description
        {
            get { return String.Empty; }
        }

        public object View
        {
            get { return this; }
        }

        private void OnExecute(object sender, RoutedEventArgs e)
        {
            if (!(lsvPersons.SelectedItem is Person))
                return;

            int group = (int) ((Person) lsvPersons.SelectedItem).Group;

            if (group < 3)
                group += 1;
            else
                group = 1;

            ((Person)lsvPersons.SelectedItem).Group = group;

        }
    }
}
