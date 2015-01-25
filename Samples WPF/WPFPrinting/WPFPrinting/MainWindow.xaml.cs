using System;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace WPFPrinting
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LocalPrintServer printServer = new LocalPrintServer();


            // Ermitteln der lokal verfügbaren Drucker
            PrintQueueCollection printQueuesOnLocalServer = printServer.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });

            // Die verfügbaren Queues werden der Liste hinzugefügt
            (from p in printQueuesOnLocalServer orderby p.Name select p).ToList().ForEach(x => cboPrinter.Items.Add(x));


            // Template des DocumentViewers: http://msdn.microsoft.com/en-us/library/aa970452.aspx
            
        }

        private void OnPrint(object sender, RoutedEventArgs e)
        {
            var paginator = new CustomPaginator();

            using (var stream = new MemoryStream())
            {
                Package package = Package.Open(stream, FileMode.Create, FileAccess.ReadWrite);

                var uri = new Uri(@"memorystream://myXps.xps");
                PackageStore.AddPackage(uri, package);
                var xpsDoc = new XpsDocument(package);

                // Dokument erstellen
                xpsDoc.Uri = uri;
                XpsDocument.CreateXpsDocumentWriter(xpsDoc).Write(paginator);


                // Dokument zuordnen
                viewer.Document = xpsDoc.GetFixedDocumentSequence();
                PackageStore.RemovePackage(uri);
            }


            // Frage: Wie kann der Druck direkt auf dem Druckerobjekt und ohne vorherigen Dialog erfolgen?
            // Dabei ist die Zielsetzung ein selbstkonfiguriertes Druckerticket zu verwenden

            // http://msdn.microsoft.com/de-de/library/ms604587.aspx

            //if (cboPrinter.SelectedItem == null)
            //    return;

            //// Auswertung der Einstellungen
            //var ticket = new PrintTicket();


            //var objPrinterInfo = cboPrinter.SelectedItem as PrintQueue;

            //XpsDocumentWriter printer = PrintQueue.CreateXpsDocumentWriter(objPrinterInfo);

            //// hier könnte das Ticket angepasst werden
            //var result = objPrinterInfo.MergeAndValidatePrintTicket(objPrinterInfo.UserPrintTicket, ticket);


            //printer.Write(paginator, result.ValidatedPrintTicket);

        }

        private void OnSelectedPrinterChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPrinter.SelectedItem == null)
                return;

            var objPrinter = cboPrinter.SelectedItem as PrintQueue;
            var objPrintCapabilities = objPrinter.GetPrintCapabilities();
            
            var printServer = new LocalPrintServer();

            // Duplex: http://msdn.microsoft.com/en-us/library/ms552920.aspx
            foreach (var p in objPrintCapabilities.DuplexingCapability)
            {
                Debug.WriteLine(p.ToString()); 
            }

            // Papierformate
            Debug.WriteLine("** Papierformate **");
            // http://stackoverflow.com/questions/5879731/convert-paperkind-to-pagemediasizename
            foreach (var p in objPrintCapabilities.PageMediaSizeCapability)
                Debug.WriteLine(String.Format("{0} ({1}x{2})", p.PageMediaSizeName, p.Width, p.Height));

            Debug.WriteLine("** Druckreihenfolge **");
            foreach(var p in objPrintCapabilities.PageOrderCapability)
                Debug.WriteLine(String.Format("{0}", p.ToString()));

            Debug.WriteLine("** Ausrichtung **");
            foreach(var p in objPrintCapabilities.PageOrientationCapability)
                Debug.WriteLine(String.Format("{0}", p.ToString()));

            if (objPrintCapabilities.PagesPerSheetCapability.Any())
            {
                cboPaperSize.Items.Clear();
                cboPaperSize.Visibility = Visibility.Visible;
                foreach (var p in objPrintCapabilities.PagesPerSheetCapability)
                    cboPaperSize.Items.Add(String.Format("{0}", p.ToString()));
            }
            else
                cboPaperSize.Visibility = Visibility.Collapsed;

            if (objPrintCapabilities.OutputColorCapability.Any())
            {
                cboColor.Items.Clear();
                cboColor.Visibility = Visibility.Visible;
                foreach (var p in objPrintCapabilities.OutputColorCapability)
                    cboColor.Items.Add(String.Format("{0}", p.ToString()));
            }
            else
                cboColor.Visibility = Visibility.Collapsed;


        }
    }
}
