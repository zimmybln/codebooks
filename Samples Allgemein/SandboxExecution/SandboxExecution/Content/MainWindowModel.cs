using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using SandboxExecution.Library;

namespace SandboxExecution
{
    internal class MainWindowModel : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private ICommand mv_cmdExecuteText;
        private string mv_strRunnableText;

        internal MainWindowModel()
        {
            mv_strRunnableText = "return DateTime.Now;";
            mv_cmdExecuteText = new DelegateCommand(ExecuteText);
        }

        private void ExecuteText(object parameter)
        {
         
            CodeExecution cmd = new CodeExecution();

            cmd.ExecuteCode(mv_strRunnableText);
            
        }



        public string RunnableText
        {
            get { return mv_strRunnableText; }
            set
            {
                if (mv_strRunnableText != value)
                {
                    mv_strRunnableText = value;
                    RaisePropertyChanged("RunnableText");
                }
            }
        }

        public ICommand Execute
        {
            get { return mv_cmdExecuteText; }
        }

        private void RaisePropertyChanged(string PropertyName)
        {
            var p = this.PropertyChanged;

            if (p != null)
                p(this, new PropertyChangedEventArgs(PropertyName));

        }


    }
}
