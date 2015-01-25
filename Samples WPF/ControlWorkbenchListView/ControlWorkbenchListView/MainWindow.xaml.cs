using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AssemblyCatalog catalog = new AssemblyCatalog(this.GetType().Assembly);

            CompositionContainer container = new CompositionContainer(catalog);

            IEnumerable<Lazy<IUseCaseView>> colUseCases = container.GetExports<IUseCaseView>();

            foreach (var i in colUseCases)
                lsbUseCases.Items.Add(i.Value);

            if (lsbUseCases.Items.Count >= 1)
                lsbUseCases.SelectedIndex = 0;

        }

        private void OnUseCaseSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is IUseCaseView)
            {
                IUseCaseView view = e.AddedItems[0] as IUseCaseView;

                if (view != null)
                    frmUseCases.Navigate(view.View);
            }
        }
    }
}
