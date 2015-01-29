using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public class StateMachine<TStates>
    {
        private readonly List<StateDescriptor<TStates>> _states = new List<StateDescriptor<TStates>>();

        
        public StateMachine(TStates state)
        {
            Data = new ObservableDictionary<string, object>();
            Data.CollectionChanged += OnDataCollectionChanged;

            Current = state;
        }

        private void OnDataCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            
        }

        public StateDescriptor<TStates> AddStateDescriptor(TStates state)
        {
            if (_states.FirstOrDefault(s => s.ItemState.Equals(state)) != null)
                throw new Exception("item already in");

            var statedescriptor = new StateDescriptor<TStates>(state, this);

            _states.Add(statedescriptor);

            return statedescriptor;
        }

        public bool TryToEnterState(TStates state)
        {
            // Wenn der Status bereits aktuell ist, erfolgt kein Wechsel
            if (state.Equals(Current))
                return true;

            // Darf der aktuelle Status verlassen werden?
            var stateFrom = this[Current];

            if (stateFrom != null)
            {
                
                // TODO: Überprüfen, ob von diesem Status in den anderes gewechselt werden kann: ist gültiger Nachfolgestatus
                
            }

            var stateTo = this[state];

            // TODO: Was passiert, wenn keine Beschreibung des Status gefunden wurde?
            // a ) Der Statuswechsel wird durchgeführt
            // b ) Der Statuswechsel wird mit einer Fehlermeldung abgebrochen
            
            if (stateTo != null && !stateTo.IsState())
            {
                // TODO: Überprüfen, ob von diesem Status in den anderes gewechselt werden kann: ist gültiger Vorgängerstatus

                return false;
            }

            // Wenn alle Überprüfungen erfolgreich durchgeführt worden sind, kann der Status gewechselt werden
            Current = state;

            return true;
        }

        public ObservableDictionary<string, object> Data { get; private set; } 

        public TStates Current { get; private set; }

        public StateDescriptor<TStates> this[TStates state]
        {
            get { return _states.FirstOrDefault(s => s.ItemState.Equals(state)); }
        }


    }
}
