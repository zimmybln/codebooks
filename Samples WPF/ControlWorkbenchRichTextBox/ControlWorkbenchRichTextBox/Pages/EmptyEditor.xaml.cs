using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
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

namespace ControlWorkbenchRichTextBox.Pages
{
    /// <summary>
    /// Interaction logic for EmptyEditor.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class EmptyEditor : Page, IUseCaseView
    {
        public EmptyEditor()
        {
            InitializeComponent();
        }


        public string Description
        {
            get { return "Einfacher Editor"; }
        }

        public object View
        {
            get { return this; }
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(String.Format("Auswahl hat sich geändert: {0}", ((RichTextBox)sender).Selection.IsEmpty));
        }
    }
}
