using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace DynamicPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(string str in this.GetType().Assembly.GetManifestResourceNames())
                Debug.WriteLine(str);
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            object item = null;

            using (var stm = this.GetType().Assembly.GetManifestResourceStream("DynamicPage.Samples.SimplePage.txt"))
            {
                var xmlreader = XmlReader.Create(stm);

                item = XamlReader.Load(xmlreader);


            }

            frame.Content = item;
        }
    }
}
