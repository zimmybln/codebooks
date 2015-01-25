using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using ImageExplorer.Base;

namespace ImageExplorer.Applications
{
    [Export]
    public class FileMethodViewModel : ViewModel<IFileMethodView>
    {
        private string mv_strSelectedPath;
        private IImageExplorerMethodModel mv_implActiveMethod;
        private readonly ObservableCollection<IImageExplorerMethodModel> mv_colMethods;

        [ImportingConstructor]
        public FileMethodViewModel(IFileMethodView View, ImageExplorer.Base.IMessageService MessageService)
            : base(View)
        {
            mv_colMethods = new ObservableCollection<IImageExplorerMethodModel>();
        }

        public string SelectedPath
        {
            get { return mv_strSelectedPath; }
            set
            {
                if (mv_strSelectedPath != value)
                {
                    mv_strSelectedPath = value;
                    RaisePropertyChanged("SelectedPath");
                }
            }
        }

        public IImageExplorerMethodModel ActiveModelView
        {
            get { return mv_implActiveMethod;  }
            set
            {
                if (mv_implActiveMethod != value)
                {
                    mv_implActiveMethod = value;
                    RaisePropertyChanged("ActiveModelView");
                }
            }
        }

        public ObservableCollection<IImageExplorerMethodModel> Methods
        {
            get { return mv_colMethods; }
        }
    }
}
