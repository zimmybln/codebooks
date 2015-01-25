using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace UseCase_02_Dialog
{
    public class ActionCommand : ICommand
    {
        private readonly Action<object> mv_actExecutingMethod = null;

        public ActionCommand(Action<object> ExecuteAction)
        {
            mv_actExecutingMethod = ExecuteAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (mv_actExecutingMethod == null) return;
            mv_actExecutingMethod(parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        void ICommand.Execute(object parameter)
        {
            Execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        private void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

    }
}
