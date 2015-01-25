using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
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
using System.Windows.Xps.Packaging;

namespace FlowDocumentDataBinding
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowDocument(object sender, RoutedEventArgs e)
        {
            var document = Application.LoadComponent(new Uri("DefaultReport.xaml", UriKind.RelativeOrAbsolute)) as FlowDocument;

            var context = new Person();
            context.FirstName = "Samplevalue";

            document.DataContext = context;

            // show as flowdocument
            FlowDocumentReader.Document = document;


            FlowDocumentReader.UpdateDefaultStyle();
            FlowDocumentReader.UpdateLayout();

            document = FlowDocumentReader.Document;

            // show as fixeddocument
            var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
            var package = Package.Open(new MemoryStream(), FileMode.Create, FileAccess.ReadWrite);
            var packUri = new Uri("pack://temp.xps");
            PackageStore.RemovePackage(packUri);
            PackageStore.AddPackage(packUri, package);
            var xps = new XpsDocument(package, CompressionOption.NotCompressed, packUri.ToString());
            XpsDocument.CreateXpsDocumentWriter(xps).Write(paginator);
            DocumentViewer.Document = xps.GetFixedDocumentSequence().References[0].GetDocument(true);


        }
    }
}
