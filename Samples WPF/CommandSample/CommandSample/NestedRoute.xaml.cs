using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CommandSample
{
    /// <summary>
    /// Interaktionslogik für NestedRoute.xaml
    /// </summary>
    public partial class NestedRoute : Window
    {
        public NestedRoute()
        {
            InitializeComponent();
        }

        private void OnCanRoute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.ContinueRouting = true;
        }

        private void OnRouted(object sender, ExecutedRoutedEventArgs e)
        {
            lstReceives.Items.Add(String.Format("Empfangen {0}", DateTime.Now.ToString()));

            e.Handled = false;
        }
    }
}
