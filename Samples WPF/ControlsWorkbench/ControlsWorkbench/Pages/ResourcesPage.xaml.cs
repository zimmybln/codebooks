using System.Windows;
using System.Windows.Controls;

namespace ControlsWorkbench.Pages
{
    /// <summary>
    /// Interaktionslogik für ResourcesPage.xaml
    /// </summary>
    public partial class ResourcesPage : Page
    {
        public ResourcesPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SampleResourceClass objClass =
                TryFindResource("FirstResourceClass") as SampleResourceClass;

            if (objClass != null)
                MessageBox.Show(objClass.Name);
            else
                MessageBox.Show("Die Resource konnte nicht gefunden werden.");

            if (this.FindName("button1") == null)
                MessageBox.Show("Die Resource konnte nicht gefunden werden.");
            else
                MessageBox.Show("gefunden");
        }
    }
}
