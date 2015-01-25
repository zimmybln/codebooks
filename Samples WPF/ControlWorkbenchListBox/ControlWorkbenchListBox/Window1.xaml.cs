using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ControlWorkbenchListBox
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}
