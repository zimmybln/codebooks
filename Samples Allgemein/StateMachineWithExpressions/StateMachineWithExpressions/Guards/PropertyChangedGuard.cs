using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions.Guards
{
    public class PropertyChangedGuard<TStates, TData> : IGuard<TStates, TData>
        where TData : INotifyPropertyChanged
    {
        private StateMachine<TStates, TData> _stateMachine;
        private TData _propertyHost;
        private readonly List<string> _listOfPropertyNames = new List<string>();

        public PropertyChangedGuard()
        {
            
        }

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

        public void AddWatch(Expression<Func<TData, bool>> watchFunc)
        {
            if (watchFunc != null)
            {
                Debug.WriteLine("Expression gefunden");
            }
        }

        public void Initialize(StateMachine<TStates, TData> stateMachine, TData propertyHost)
        {
            _propertyHost = propertyHost;
            _stateMachine = stateMachine;

            _propertyHost.PropertyChanged += OnPropertyChanged;
        }
    }
}
