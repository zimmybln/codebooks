using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;


namespace ControlWorkbenchRichTextBox.Pages
{
    /// <summary>
    /// Interaction logic for InsertHyperlink.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class InsertHyperlink : Page, IUseCaseView
    {

        private XpsDocumentWriter xdw = null;

        public InsertHyperlink()
        {
            InitializeComponent();

            Stream fsDocument =
                this.GetType().Assembly.GetManifestResourceStream(
                    "ControlWorkbenchRichTextBox._Resources.DefaultDocument.xml");

            if (fsDocument != null)
            {
                FlowDocument fd = XamlReader.Load(fsDocument) as FlowDocument;

                fsDocument.Close();
                fsDocument.Dispose();

                rtbContent.Document = fd;
            }

            rtbContent.Focus();
        }


        public string Description
        {
            get { return ""; }
        }

        public object View
        {
            get { return this; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Strategie zum Schreiben des Dokumentes:
        /// - Zustandsänderung: Initialisierung(Anzahl zu schreibender Seiten), Seite geschrieben (Nummer), Abschluss (Fehler, Abgebrochen, Ok)
        /// - Geschriebene Seiten: 
        /// </remarks>
        private void SaveDocument(string fileName, FixedDocument document, ISavingDocumentStrategy Strategy)
        {
            //Delete any existing file.
            File.Delete(fileName);

            //Create a new XpsDocument at the given location.
            XpsDocument xpsDocument = new XpsDocument(fileName, FileAccess.ReadWrite);

            //Create a new XpsDocumentWriter for the XpsDocument object.
            xdw = XpsDocument.CreateXpsDocumentWriter(xpsDocument);

            //We want to be notified of when the progress changes.
            xdw.WritingProgressChanged +=
                delegate(object sender, WritingProgressChangedEventArgs e)
                {
                    if (Strategy != null)
                        Strategy.Changed(e.Number, e.ProgressPercentage);
                };

            //We want to be notified of when the operation is complete.
            xdw.WritingCompleted +=
                delegate(object sender, WritingCompletedEventArgs e)
                {
                    //We're finished with the XPS document, so close it.
                    //This step is important.
                    xpsDocument.Close();

                    if (e.Error != null)
                    {
                        if (Strategy != null)
                            Strategy.FinishedWithError(e.Error);
                    }
                    else if (e.Cancelled)
                    {
                        if (Strategy != null)
                            Strategy.Cancelled();
                    }
                    else
                    {
                        if (Strategy != null)
                            Strategy.Finished();
                    }
                };

            ////Show the long operation mask with the Cancel button and progress bar.
            //spProgressMask.Visibility = Visibility.Visible;
            //pbSaveProgress.Maximum = document.Pages.Count;
            //pbSaveProgress.Value = 0;
            //Write the document to the XPS file asynchronously.

            xdw.WriteAsync(document);
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is RichTextBox))
                return;

            var rtb = sender as RichTextBox;

            if (rtb.CaretPosition.Parent is List)
                Console.WriteLine("Es handelt sich um eine Liste");
            else if (rtb.CaretPosition.Parent is Paragraph)
                Console.WriteLine("Absatz");
            else if (rtb.CaretPosition.Parent is Run)
            {
                //var p = rtb.GetNearestFromCaret(typeof (ListItem)) as ListItem;

                //if (p != null)
                //    Console.WriteLine("Paragraph gefunden");
                //else
                //    Console.WriteLine("Es wurde nichts gefunden.");

                if (rtb.CaretPosition != null)
                    rtb.CaretPosition.ListElementHierarchie(Console.Out);

                /* 

                 Wünschenswert wäre hier folgende Variante:
                 Es werden ausgehend von der aktuellen Position alle vorkommenden Objekttypen aufgelistet und je nach dem, was vorkommt,
                 wird die Bearbeitung aktiviert oder nicht aktiviert.


                 */
            }
        }

        private void OnFormat(object sender, RoutedEventArgs e)
        {
            var rtb = rtbContent;

            if (sender == cmdFormatBold)
            {
                EditingCommands.ToggleBold.Execute(null, rtb);
            }
            else if (sender == cmdFormatItalic)
            {
                EditingCommands.ToggleItalic.Execute(null, rtb);
            }
            else if (sender == cmdFormatUnderline)
            {
                EditingCommands.ToggleUnderline.Execute(null, rtb);
            }
        }

        private void OnTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1 && e.AddedItems[0] == tiView)
            {
                MemoryStream fsDocument = new MemoryStream();

                XamlWriter.Save(rtbContent.Document, fsDocument);

                fsDocument.Flush();
                fsDocument.Seek(0, SeekOrigin.Begin);

                FlowDocument f = XamlReader.Load(fsDocument) as FlowDocument;

                flowViewer.Document = f;

                fsDocument.Close();
                fsDocument.Dispose();
            }
            else if (e.AddedItems.Count == 1 && e.AddedItems[0] == tiXAML)
            {

                MemoryStream fsDocument = new MemoryStream();

                XamlWriter.Save(rtbContent.Document, fsDocument);

                fsDocument.Flush();
                fsDocument.Seek(0, SeekOrigin.Begin);

                StreamReader sr = new StreamReader(fsDocument);

                tbViewer.Text = sr.ReadToEnd();

                sr.Close();
                sr.Dispose();
            }
        }

        private void OnHyperlink(object sender, RoutedEventArgs e)
        {
            Hyperlink h = rtbContent.GetNearestFromCaret<Hyperlink>();

            HyperlinkDialog dlgHyperlink = new HyperlinkDialog();

            if (h != null)
            {
                dlgHyperlink.HyperlinkTarget = h.NavigateUri.ToString();
                dlgHyperlink.HyperlinkText = ((Run)h.Inlines.FirstInline).Text;
            }

            if (dlgHyperlink.ShowDialog() == true)
            {
                // 
                if (h == null)
                {
                    Run r = new Run(dlgHyperlink.HyperlinkText);

                    TextPointer tp = rtbContent.CaretPosition.GetInsertionPosition(LogicalDirection.Forward);

                    h = new Hyperlink(r, tp);
                }

                h.NavigateUri = new Uri(dlgHyperlink.HyperlinkTarget);
                h.ToolTip = dlgHyperlink.HyperlinkTarget;



            }
        }

        private void OnInsertList(object sender, RoutedEventArgs e)
        {
            var lst = rtbContent.GetNearestFromCaret<List>();
            
            if (lst == null)
            {
                lst = new List();

                lst.ListItems.Add(new ListItem(new Paragraph(new Run(String.Format("Test: {0}", DateTime.Now.ToString())))));

                var tp = rtbContent.CaretPosition.GetInsertionPosition(LogicalDirection.Forward);

                var block = rtbContent.GetNearestFromCaret<Paragraph>();
                
                block.Background = Brushes.BurlyWood;
                block.Margin= new Thickness(30);
            }

        }

        private void OnParagraph(object sender, RoutedEventArgs e)
        {
            var p = rtbContent.GetNearestFromCaret<Paragraph>();

            if (p != null)
            {
                p.Background = new SolidColorBrush(Colors.Beige);
                p.BorderThickness = new Thickness(5, 4, 3, 2);
                p.BorderBrush = new SolidColorBrush(Colors.Blue);
            }


        }


    }
}
