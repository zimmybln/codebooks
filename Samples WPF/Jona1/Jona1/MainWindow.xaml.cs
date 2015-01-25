using System;
using System.Collections.Generic;
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

namespace Jona1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (chkGeduscht.IsChecked == true)
            {
                MessageBox.Show("du darfst jetzt noch Fußball kucken");

                MessageBox.Show("Fein, Jona kann noch etwas fernsehen.");
            }
            else

            {
                MessageBox.Show("Jetzt aber flott unter die Dusche und dann ins Bett");
                MessageBox.Show("Ich (Papa) pups wen du nicht sofort Duschen gehst");
            }
            if (UseLayoutRounding)
            {
                
            }
        }
    }
}
