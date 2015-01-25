using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using HtmlAgilityPack;

namespace MVVMTask
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private string mv_strTitle;
        
        public MainWindowModel()
        {
            ExecuteBackgroundTask = new MethodCommand(OnExecuteBackgroundTask);    
        }

        #region Methoden für Commands

        public void OnExecuteBackgroundTask(object Parameter)
        {
            this.Title = DateTime.Now.ToString();

            Task<string> tsk = new Task<string>(FindWebsiteInfo);

            tsk.ContinueWith(t => this.Title = t.Result);

            tsk.Start();

        }
        
        #endregion

        private string FindWebsiteInfo()
        {
            var client = new WebClient();

            client.Proxy = WebRequest.GetSystemWebProxy();

            string strValue = 
                client.DownloadString("http://www.spiegel.de");
            
            client.Dispose();

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(strValue);

            var title = doc.DocumentNode.SelectSingleNode("//title");

            if (title != null)
                strValue = title.InnerText;

            return strValue;
        }


        #region Eigenschaften

        public ICommand ExecuteBackgroundTask { get; set; }

        public string Title
        {
            get { return mv_strTitle; }
            set
            {
                if (String.Compare(mv_strTitle, value) == 0)
                    return;

                mv_strTitle = value;
                RaisePropertyChanged("Title");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string PropertyName)
        {
            var p = PropertyChanged;

            if (p != null)
            {
                p(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        
        #endregion
        
    }
}
