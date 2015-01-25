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
    /// Interaction logic for MultiColumnPage.xaml
    /// </summary>
        [Export(typeof(IUseCaseView))]
    public partial class MultiColumnPage : Page, IUseCaseView
    {
        private List<string> mv_lstValues;
            
        public MultiColumnPage()
        {
            InitializeComponent();

            mv_lstValues = new List<string>();

            mv_lstValues.AddRange(new []{"eins", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun", "zehn"});

            CategoryListBox.ItemsSource = mv_lstValues;

        }

        public List<string> Values
        {
            get { return mv_lstValues; }
        }

        public object View
        {
            get { return this; }
        }
    }
}
