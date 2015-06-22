using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions.Guards
{
    public class PropertyChangedGuard<TStates, TData>
        where TData : INotifyPropertyChanged
    {
        private readonly StateMachine<TStates, TData> _stateMachine;
        private readonly TData _propertyHost;
        private readonly List<string> _listOfPropertyNames = new List<string>(); 

        public PropertyChangedGuard(StateMachine<TStates, TData> stateMachine, TData propertyHost)
        {
            _propertyHost = propertyHost;
            _stateMachine = stateMachine;

            _propertyHost.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (_listOfPropertyNames.Contains(args.PropertyName))
            {
                _stateMachine.FindState(_propertyHost);
            }
        }

        public List<string> PropertyNames
        {
            get { return _listOfPropertyNames; }
        }
    }
}
