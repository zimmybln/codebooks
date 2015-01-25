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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandSample.Pages
{
    /// <summary>
    /// Interaktionslogik für InnerPage.xaml
    /// </summary>
    public partial class InnerPage : Page
    {
        public InnerPage()
        {
            InitializeComponent();
        }

        private void OnRoute(object sender, ExecutedRoutedEventArgs e)
        {
            lstReceives.Items.Add(String.Format("Empfangen {0}", DateTime.Now.ToString()));
        }

        private void OnCanRoute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
