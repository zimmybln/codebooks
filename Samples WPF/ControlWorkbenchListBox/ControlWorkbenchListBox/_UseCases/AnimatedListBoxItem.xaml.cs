using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlWorkbenchListBox._UseCases
{
    /// <summary>
    /// Interaktionslogik für AnimatedListBoxItem.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class AnimatedListBoxItem : Page, IUseCaseView
    {
        public AnimatedListBoxItem()
        {
            InitializeComponent();

            // Initialisierung der Variablen
            Persons = new ObservableCollection<Person>();
            
            Persons.Add(new Person() {Age = 25, FirstName = "Max", LastName = "Mustermann"});
            Persons.Add(new Person() {Age = 30, FirstName = "Hans", LastName = "Beispielname"});
            Persons.Add(new Person() {Age = 35, FirstName = "Heidemarie", LastName = "Schmidt"});
            
            this.DataContext = this;
        }

        public ObservableCollection<Person> Persons { get; private set; }

        public object View
        {
            get { return this; }
        }

        private void OnExecute(object Sender, RoutedEventArgs E)
        {
            foreach (Person p in Persons)
            {
                if (p.Age < 30)
                {
                    var element =
                        lstPersons.ItemContainerGenerator.ContainerFromItem(p) as FrameworkElement;

                    if (element != null)
                        VisualStateManager.GoToState(element, "Young", true);
                }
            }
        }
    }

    //public class Person
    //{
    //    public int Age { get; set; }

    //    public string FirstName { get; set; }

    //    public string LastName { get; set; }
    //}
}
