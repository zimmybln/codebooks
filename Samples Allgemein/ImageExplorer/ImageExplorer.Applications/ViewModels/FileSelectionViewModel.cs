using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.Windows;
using System.Windows.Input;
using ImageExplorer.Base;

namespace ImageExplorer.Applications
{
    [Export]
    public class FileSelectionViewModel : ViewModel<IFileSelectionView>
    {
        private readonly ImageExplorer.Base.IMessageService mv_implMessageService;

        private string mv_strSelectedPath;
        
        [ImportingConstructor]
        public FileSelectionViewModel(IFileSelectionView View, ImageExplorer.Base.IMessageService MessageService)
            : base(View)
        {
            mv_implMessageService = MessageService;
        }


        public string SelectedPath
        {
            get
            {
                return mv_strSelectedPath;
            }
            set
            {
                if (mv_strSelectedPath != value)
                {
                    mv_strSelectedPath = value;
                    RaisePropertyChanged("SelectedPath");

                    mv_implMessageService.ShowMessage(String.Format("Aktueller Pfad: {0}", mv_strSelectedPath));
                }
            }
        }
    }
}
