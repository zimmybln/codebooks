using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;
using ICSharpCode.AvalonEdit.Document;
using Microsoft.Win32;
using WPFArchitectureModel.Library.Commands;
using WPFArchitectureModel.Library.Models;

namespace FlowDocumentEditor
{
    public class MainWindowModel : ViewModelBase
    {

        public MainWindowModel()
        {
            RefreshCommand = new MethodCommand(OnRefreshCommand);
            FileNewCommand = new MethodCommand(OnFileNewCommand);
            FileSaveCommand = new MethodCommand(OnFileSaveCommand);
            FileSaveAsCommand = new MethodCommand(OnFileSaveAsCommand);
            FileOpenCommand = new MethodCommand(OnFileOpenCommand);
            
            SourceDocument = new TextDocument();
            SourceDocument.Text = DefaultSourceDocument;

            DataDocument = new TextDocument();
            DataDocument.Text = DefaultDataDocument;

            PropertyChanged += OnPropertyChanged;


        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName.Equals("File"))
            {
                Title = String.Format("FlowDocumentEditor [{0}]", File);
            }
        }

        #region Dateibehandlung

        private void OnFileNewCommand(ICommand command, object parameter)
        {
            SourceDocument.Text = string.Empty;
            DataDocument.Text = string.Empty;
            File = DefaultSourceDocument;
        }

        private void OnFileSaveCommand(ICommand command, object parameter)
        {
            var strFile = File;

            if (String.IsNullOrEmpty(strFile))
            {
                OnFileSaveAsCommand(FileSaveAsCommand, parameter);
                return;
            }

            SaveCurrentContentToFile(strFile);
        }

        private void OnFileSaveAsCommand(ICommand command, object parameter)
        {
            var dlgFileSave = new SaveFileDialog();

            dlgFileSave.Filter = "FlowDocument Daten|*.fdd";
            dlgFileSave.FilterIndex = 0;

            if (dlgFileSave.ShowDialog() == true)
            {
                SaveCurrentContentToFile(dlgFileSave.FileName);
            }
        }

        private void OnFileOpenCommand(ICommand command, object o)
        {
            var dlgFileOpen = new OpenFileDialog();

            dlgFileOpen.Filter = "FlowDocument Daten|*.fdd";
            dlgFileOpen.FilterIndex = 0;
            
            if (dlgFileOpen.ShowDialog() == true)
            {
                using (var file = new FileStream(dlgFileOpen.FileName, FileMode.Open))
                {
                    using (var archive = new ZipArchive(file, ZipArchiveMode.Read, true))
                    {
                        var entryDocument = archive.GetEntry("Document");

                        if (entryDocument != null)
                        {
                            using (var entryDocumentStream = entryDocument.Open())
                            using (var entryDocumentReader = new StreamReader(entryDocumentStream))
                            {
                                SourceDocument.Text = entryDocumentReader.ReadToEnd();
                            }
                        }

                        var entryData = archive.GetEntry("Data");
                        if (entryData != null)
                        {
                            using (var entryDataStream = entryData.Open())
                            using (var entryDataReader = new StreamReader(entryDataStream))
                            {
                                DataDocument.Text = entryDataReader.ReadToEnd();
                            }
                        }
                    }
                }

                File = dlgFileOpen.FileName;
            }
        }

        #endregion

        private void SaveCurrentContentToFile(string fileName)
        {
            string flowContent = SourceDocument.Text;
            string dataContent = DataDocument.Text;

            // Löschen der Datei
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);

            // Erstellen der neuen Daten
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                using (var archive = new ZipArchive(file, ZipArchiveMode.Create, true))
                {
                    var entryDocument = archive.CreateEntry("Document");

                    using (var entryDocumentStream = entryDocument.Open())
                    using (var entryDocumentWriter = new StreamWriter(entryDocumentStream))
                    {
                        entryDocumentWriter.Write(flowContent);
                    }

                    var entryData = archive.CreateEntry("Data");
                    using (var entryDataStream = entryData.Open())
                    using (var entryDataWriter = new StreamWriter(entryDataStream))
                    {
                        entryDataWriter.Write(dataContent);
                    }
                }
            }

            File = fileName;
        }


        private void OnRefreshCommand(ICommand command, object o)
        {
            ConvertStringToFlowDocument(SourceDocument.Text);
        }

        private void ConvertStringToFlowDocument(string content)
        {
            if (!String.IsNullOrEmpty(this.File) && System.IO.File.Exists(this.File))
            {
                SaveCurrentContentToFile(File);
            }

            FlowDocument doc = null;
           
            try
            {
                doc = XamlReader.Parse(content) as FlowDocument;

                if (!String.IsNullOrEmpty(DataDocument.Text))
                {
                    var data = new XmlDocument();
                    data.LoadXml(DataDocument.Text);

                    var dataprovider = new XmlDataProvider();
                    dataprovider.Document = data;

                    doc.DataContext = dataprovider;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            Document = doc;
        }

        private string DefaultSourceDocument
        {
            get
            {
                return
                    "<FlowDocument\r\t xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\r\t xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">\r\t<Paragraph>\r\t</Paragraph>\r</FlowDocument>";
            }
        }

        private string DefaultDataDocument
        {
            get
            {
                return
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            }
        }

        private byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        #region Eigenschaften

        public string Title
        {
            get { return GetValue("Title") as string; }
            set { SetValue("Title", value); }
        }

        public string File
        {
            get { return GetValue("File") as string; }
            set { SetValue("File", value); }
        }

        private TextDocument _sourceDocument = null;
        public TextDocument SourceDocument
        {
            get { return this._sourceDocument; }
            set
            {
                if (this._sourceDocument != value)
                {
                    this._sourceDocument = value;
                    RaisePropertyChanged("SourceDocument");
                }
            }
        }

        private TextDocument _dataDocument = null;

        public TextDocument DataDocument
        {
            get { return this._dataDocument; }
            set
            {
                if (this._dataDocument != value)
                {
                    this._dataDocument = value;
                    RaisePropertyChanged("DataDocument");
                }
            }
        }

        
        public FlowDocument Document
        {
            get { return GetValue("Document") as FlowDocument; }
            set { SetValue("Document", value); }
        }

        public ICommand RefreshCommand { get; private set; }

        public ICommand FileNewCommand { get; private set; }

        public ICommand FileSaveCommand { get; private set; }

        public ICommand FileOpenCommand { get; private set; }

        public ICommand FileSaveAsCommand { get; private set; }

        #endregion

    }
}
