using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TreeViewHierarchy.Library
{
    class MethodCommand : ICommand
    {
        private Action<object> _action;

        internal MethodCommand(Action<object> Action)
        {
            _action = Action;

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
