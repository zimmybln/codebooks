using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ItemsWithProgressBar.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class ItemsWithProgressBar : Page, IUseCaseView
    {
        private readonly ObservableCollection<ValueableCase> _lstItems = new ObservableCollection<ValueableCase>();
        private Timer _timer;

        public ItemsWithProgressBar()
        {
            InitializeComponent();

            _timer = new Timer(OnTimer);

            _lstItems.Add(new ValueableCase("Eins"));
            _lstItems.Add(new ValueableCase("Zwei"));
            _lstItems.Add(new ValueableCase("Drei"));

            lstItems.ItemsSource = _lstItems;
        }

        public ObservableCollection<ValueableCase> CaseItems
        {
            get { return _lstItems; }
        }

        public object View
        {
            get { return this; }
        }

        private void OnTimer(object state)
        {
            
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
