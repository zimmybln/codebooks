using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMTask
{
    public class MethodCommand : ICommand
    {
        private readonly Action<object> mv_action; 

        public MethodCommand(Action<object> Action)
        {
            mv_action = Action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (mv_action != null)
                mv_action(parameter);
        }
    }
}
