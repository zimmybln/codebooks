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

namespace ThemedApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <remarks>
    /// Interessante Artikel:
    /// - http://www.codeproject.com/KB/WPF/wpfdynamicthemes.aspx
    /// 
    /// </remarks>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Auswählen der Pfade
            Uri uriPath = new Uri(this.GetType().Assembly.CodeBase);
            string strPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(uriPath.LocalPath), "Themes");

            foreach (string strFile in System.IO.Directory.GetFiles(strPath, "*.*"))
            {
                cboThemes.Items.Add(System.IO.Path.GetFileName(strFile));
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string strTheme = null;

            if (e.AddedItems.Count == 1)
                strTheme = e.AddedItems[0] as string;
    
            ((App)Application.Current).ApplyDesign(strTheme);


        }

        private void OnSetDefault(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).ApplyDefaultDesign();
        }
    }
}
