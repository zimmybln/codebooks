using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using Microsoft.Win32;

namespace ControlWorkbenchRichTextBox.Pages
{
    /// <summary>
    /// Interaktionslogik für SaveDocument.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class SaveDocument : Page, IUseCaseView
    {
        public SaveDocument()
        {
            InitializeComponent();

            Stream fsDocument = this.GetType().Assembly.GetManifestResourceStream("ControlWorkbenchRichTextBox._Resources.DefaultDocument.xml");

            if (fsDocument != null)
            {
                FlowDocument fd = XamlReader.Load(fsDocument) as FlowDocument;

                fsDocument.Close();
                fsDocument.Dispose();

                editor.Document = fd;
            }

            editor.Focus();
        }


        public string Description
        {
            get { return String.Empty; }
        }

        public object View
        {
            get { return this; }
        }

        private void OnSaveAsRtf(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();

            dlg.DefaultExt = "rtf";
            dlg.AddExtension = true;
            dlg.OverwritePrompt = true;
            dlg.Filter = "RTF (*.rtf)|*.rtf|Alle Dateien (*.*)|*.*";

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    using (var fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        var tr = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd);
                        tr.Save(fs, DataFormats.Rtf);
                    }
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
            }
        }

    }
}
