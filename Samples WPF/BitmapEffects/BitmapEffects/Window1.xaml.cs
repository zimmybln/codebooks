using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace BitmapEffects
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnLoadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();

            dlgOpenFile.Filter = "Bilder|*.png|Alle Dateien|*.*";
            dlgOpenFile.FilterIndex = 0;

            if (dlgOpenFile.ShowDialog() == true)
            {
                var img = this.FindResource("DefaultImage2") as ImageSource;

                if (img != null)
                {
                    try
                    {
                        BitmapImage bmp = new BitmapImage();

                        bmp.BeginInit();
                        bmp.UriSource = new Uri(dlgOpenFile.FileName);
                        bmp.EndInit();
                    
                        this.Resources["DefaultImage2"] = bmp;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Die Datei '{0}' konnte nicht geladen werden: {1}.",
                                                      dlgOpenFile.FileName, ex.Message));
                    }
                }
            }
        }

        private void OnSelectColor(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
