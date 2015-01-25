using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
    /// Interaktionslogik für ParagraphProperties.xaml
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/de-de/library/system.windows.documents.paragraph.aspx
    /// </remarks>
    [Export(typeof(IUseCaseView))]
    public partial class ParagraphProperties : Page, IUseCaseView
    {
        public ParagraphProperties()
        {
            InitializeComponent();
        }


        public string Description
        {
            get { return ""; }
        }

        public object View
        {
            get { return this; }
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
