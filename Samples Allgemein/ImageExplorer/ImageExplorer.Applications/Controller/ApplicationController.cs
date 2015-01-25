using System;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using ImageExplorer.Base;

namespace ImageExplorer.Applications
{
    [Export(typeof(IApplicationController))]
    public class ApplicationController : Controller, IApplicationController
    {
        private readonly CompositionContainer mv_implCompositionContainer;
        private ShellViewModel mv_implShellViewModel;
        private FileSelectionViewModel mv_implFileSelectionViewModel;
        private FileMethodViewModel mv_implFileMethodViewModel;

        private ImageMethodsController mv_implImageMethodsController;
        
        [ImportingConstructor]
        public ApplicationController(CompositionContainer Container)
        {
            mv_implCompositionContainer = Container;
            mv_implImageMethodsController = mv_implCompositionContainer.GetExportedValue<ImageMethodsController>();
        }

        public void Initialize(string[] args)
        {
            // Hier könnte es eine Auswertung der Parameter geben
            mv_implShellViewModel = mv_implCompositionContainer.GetExportedValue<ShellViewModel>();
            mv_implFileSelectionViewModel = mv_implCompositionContainer.GetExportedValue<FileSelectionViewModel>();
            mv_implFileMethodViewModel = mv_implCompositionContainer.GetExportedValue<FileMethodViewModel>();

            mv_implFileSelectionViewModel.PropertyChanged += OnFileSelectionPropertyChanged;

            var lstMethods =  mv_implCompositionContainer.GetExportedValues<IImageExplorerMethodModel>();

            foreach(IImageExplorerMethodModel objItem in lstMethods)
            {
                mv_implFileMethodViewModel.Methods.Add(objItem);
            }

        }

        void OnFileSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedPath")
            {
                mv_implFileMethodViewModel.SelectedPath = mv_implFileSelectionViewModel.SelectedPath;
            }
        }

        public void Run()
        {
            mv_implFileSelectionViewModel.SelectedPath =
                System.Environment.GetFolderPath(Environment.SpecialFolder.System);

            // Zuordnen der Standardansicht
            mv_implShellViewModel.FileSelectionView = mv_implFileSelectionViewModel.View;
            mv_implShellViewModel.FileMethodView = mv_implFileMethodViewModel.View;
            mv_implShellViewModel.Show();
        }

        public void Close()
        {
            mv_implShellViewModel.Close();
        }

        public void Shutdown()
        {
            // Momentan gibt es hier nichts zu tun
        }
    }
}
