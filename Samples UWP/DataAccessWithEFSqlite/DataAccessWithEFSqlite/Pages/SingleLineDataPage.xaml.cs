using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DataAccessWithEFSqlite.Data;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace DataAccessWithEFSqlite
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class SingleLineDataPage : Page
    {
        public SingleLineDataPage()
        {
            this.InitializeComponent();
        }

        private void OnSave_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();

            person.LastName = txtLastName.Text;

            using (var data = new PersonDataContext())
            {
                data.Persons.Add(person);

                data.SaveChanges();
            }
        }
    }
}
