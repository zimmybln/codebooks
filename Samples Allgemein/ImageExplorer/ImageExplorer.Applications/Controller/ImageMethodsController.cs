using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Waf.Applications;
using ImageExplorer.Base;

namespace ImageExplorer.Applications
{
    [Export]
    public class ImageMethodsController : Controller
    {
        private readonly CompositionContainer mv_implCompositionContainer;
        private readonly FileSelectionViewModel mv_implFileSelectionViewModel;
        private readonly ImageExplorerFilterModel mv_implFileFilterViewModel;
        private const string mc_strFilePatterns = "*.jpg;*.ico;*.gif;*.bmp";
        
        [ImportingConstructor]
        public ImageMethodsController(CompositionContainer Container)
        {
            mv_implCompositionContainer = Container;

            // Ermitteln der verwendeten Modelle
            mv_implFileSelectionViewModel = mv_implCompositionContainer.GetExportedValue<FileSelectionViewModel>();
            mv_implFileFilterViewModel = mv_implCompositionContainer.GetExportedValue<ImageExplorerFilterModel>();

            AddWeakEventListener(mv_implFileSelectionViewModel as INotifyPropertyChanged, OnFileSelectionPropertyChanged);
            AddWeakEventListener(mv_implFileFilterViewModel as INotifyPropertyChanged, OnFileFilterPropertyChanged);

        }

        void OnFileSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (new[] {"SelectedPath"}.Contains(e.PropertyName))
                this.OnFilter();
        }

        void OnFileFilterPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (new[] { "DateFrom", "Size" }.Contains(e.PropertyName))
            //    this.OnFilter();
        }

        private void OnFilter()
        {
            Debug.WriteLine("Es wird gefiltert");

            if (mv_implFileFilterViewModel.Size == null)
                Debug.WriteLine("Die Größe ist null");
            else
                Debug.WriteLine("Die Größe ist {0}", mv_implFileFilterViewModel.Size);


            var lstFiles = new List<string>();

                foreach(var strFilePattern in mc_strFilePatterns.Split(';'))
                {
                    string[] strFiles = System.IO.Directory.GetFiles(mv_implFileSelectionViewModel.SelectedPath, strFilePattern);

                    if (strFiles.Length > 0)
                        lstFiles.AddRange(strFiles);
                }

                string[] strCollectedFiles = lstFiles.ToArray();

                // Die Änderung des Pfades wird an alle weitergereicht
                foreach (IImageExplorerMethodModel objItem in mv_implCompositionContainer.GetExportedValues<IImageExplorerMethodModel>())
                {
                    objItem.SelectedFiles = strCollectedFiles;
                }


        }
    }
}
