using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
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

namespace ControlWorkbenchRichTextBox
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        

        public Window1()
        {
            InitializeComponent();

            var catalog = new AssemblyCatalog(this.GetType().Assembly);

            var container = new CompositionContainer(catalog);

            IEnumerable<Lazy<IUseCaseView>> colUseCases = container.GetExports<IUseCaseView>();

            foreach (var i in colUseCases)
                lsbUseCases.Items.Add(i.Value);

            if (lsbUseCases.Items.Count >= 1)
                lsbUseCases.SelectedIndex = 0;



        }

        private void OnUseCaseSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is IUseCaseView)
            {
                IUseCaseView view = e.AddedItems[0] as IUseCaseView;

                if (view != null)
                    frmUseCases.Navigate(view.View);
            }
        }

        //    //Present the user with a save dialog, getting the path
        //    //to a file where the document will be saved.
        //    // SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    //       saveFileDialog.Filter = ".xps|*.xps";
        //    //saveFileDialog.OverwritePrompt = true;
        //    //saveFileDialog.Title = "Save to Xps Document";
        //    ////If the user cancelled the dialog, bail.
        //    //if (saveFileDialog.ShowDialog(this) == false)
        //    //{
        //    //    return;
        //    //}
        //    ////Save the document.
        //    //SaveDocument(saveFileDialog.FileName,
        //    //    dvDocumentViewer.Document as FixedDocument);




    }


}
