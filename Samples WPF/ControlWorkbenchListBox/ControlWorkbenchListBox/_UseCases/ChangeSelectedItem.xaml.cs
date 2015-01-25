using System;
using System.Collections.Generic;
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

namespace ControlWorkbenchListBox._UseCases
{
    /// <summary>
    /// Interaktionslogik für ChangeSelectedItem.xaml
    /// </summary>
    /// <remarks>
    /// http://leeontech.wordpress.com/2008/07/15/customizing-itemcontainerstyle-in-listbox/
    /// http://www.tewari.info/2011/04/29/remove-listboxitem-highlighting/
    /// </remarks>
    [Export(typeof(IUseCaseView))]
    public partial class ChangeSelectedItem : Page, IUseCaseView
    {
        public ChangeSelectedItem()
        {
            InitializeComponent();

            lstPersons.ItemsSource = Person.CommonPersons;
        }
        
        public object View
        {
            get { return this; }
        }
    }
}
