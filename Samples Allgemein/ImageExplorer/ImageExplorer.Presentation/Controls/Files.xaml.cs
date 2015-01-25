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

namespace ImageExplorer.Presentation.Controls
{
    /// <summary>
    /// Interaction logic for Files.xaml
    /// </summary>
    public partial class Files : UserControl
    {
        public static readonly DependencyProperty PathProperty = DependencyProperty.Register(
            "Path", typeof(string), typeof(Files), new FrameworkPropertyMetadata(String.Empty, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnPathChanged)));

        public static readonly DependencyProperty FileProperty = DependencyProperty.Register(
            "File", typeof (string), typeof (Files),
            new FrameworkPropertyMetadata(String.Empty, FrameworkPropertyMetadataOptions.None,
                                          new PropertyChangedCallback(OnFileChanged)));


        public Files()
        {
            InitializeComponent();
        }

        public string Path
        {
            get { return (string)this.GetValue(PathProperty); }
            set { this.SetValue(PathProperty, value); }
        }

        public string File
        {
            get { return (string) this.GetValue(FileProperty); }
            set { this.SetValue(FileProperty, value); }
        }

        private static void OnFileChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
             
        }

        private static void OnPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Files ctl = d as Files;

            if (ctl == null) return;

            // Aufbereiten der Daten
            ctl.lsbFiles.Items.Clear();

            string strDirectory = e.NewValue as string;

            if (String.IsNullOrEmpty(strDirectory))
                return;

            foreach (string strFile in System.IO.Directory.GetFiles(strDirectory))
            {
                var lstItem = new ListBoxItem();
                lstItem.Content = System.IO.Path.GetFileName(strFile);
                lstItem.Tag = strFile;
                ctl.lsbFiles.Items.Add(lstItem);
            }
        }

        private void OnSelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is ListBoxItem)
            {
                this.File = (string) ((ListBoxItem) e.AddedItems[0]).Tag;
            }
        }
    }
}
