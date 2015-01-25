using System.ComponentModel.Composition;
using System.Waf.Applications;
using ImageExplorer.Base;

namespace ImageExplorer.Applications
{
    [Export]
    public class ShellViewModel : ViewModel<IShellView>
    {
        private ImageExplorer.Base.IMessageService mv_implMessageService;
        private string mv_strStatusMessage;
        private object mv_objFileSelectionView;
        private object mv_objFileMethodView;

        [ImportingConstructor]
        public ShellViewModel(IShellView View, ImageExplorer.Base.IMessageService MessageService)
            : base(View)
        {
            mv_implMessageService = MessageService;

            mv_implMessageService.OnMessage += ReceiveMessage;
        }

        public object FileSelectionView
        {
            get { return mv_objFileSelectionView; }
            set
            {
                if (mv_objFileSelectionView != value)
                {
                    mv_objFileSelectionView = value;
                    RaisePropertyChanged("FileSelectionView");
                }
            }
        }

        public object FileMethodView
        {
            get { return mv_objFileMethodView; }
            set
            {
                if (mv_objFileMethodView != value)
                {
                    mv_objFileMethodView = value;
                    RaisePropertyChanged("FileMethodView");
                }
            }
        }

        private void ReceiveMessage(string Message)
        {
            this.StatusMessage = Message;
        }

        public string Title
        {
            get { return ApplicationInfo.ProductName; }
        }

        public string StatusMessage
        {
            get { return mv_strStatusMessage; }
            private set
            {
                if (mv_strStatusMessage != value)
                {
                    mv_strStatusMessage = value;
                    RaisePropertyChanged("StatusMessage");
                }
            }

        }

        public void Show()
        {
            ViewCore.Show();
        }

        public void Close()
        {
            ViewCore.Close();
        }
    }
}
