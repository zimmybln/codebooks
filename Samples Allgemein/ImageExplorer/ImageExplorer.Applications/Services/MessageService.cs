using System.ComponentModel.Composition;
using ImageExplorer.Base;

namespace ImageExplorer.Applications
{
    [Export(typeof(ImageExplorer.Base.IMessageService))]
    public class MessageService : ImageExplorer.Base.IMessageService 
    {
        public event Message OnMessage;
        
        public void ShowMessage(string Message)
        {
            if (OnMessage != null)
                OnMessage(Message);
        }
    }
}
