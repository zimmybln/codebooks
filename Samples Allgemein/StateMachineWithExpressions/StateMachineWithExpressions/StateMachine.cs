using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public class StateMachine<TStates>
    {
        private List<StateDescriptor<TStates>> _states = new List<StateDescriptor<TStates>>();

        private Dictionary<string, object> dictionary
            = new Dictionary<string, object>();

        public StateMachine(TStates state)
        {
            Current = state;
        }

        public StateDescriptor<TStates> AddStateDescriptor(TStates state)
        {
            if (_states.FirstOrDefault(s => s.ItemState.Equals(state)) != null)
                throw new Exception("item already in");

            var statedescriptor = new StateDescriptor<TStates>(state);

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
                
            }

            var stateTo = this[state];

            if (stateTo != null)
            {
                
            }

            // Wenn alle überprüfungen erfolgreich durchgeführt worden sind, kann der Status gewechselt werden
            Current = state;

            return true;
        }

        public TStates Current { get; private set; }

        public StateDescriptor<TStates> this[TStates state]
        {
            get { return _states.FirstOrDefault(s => s.ItemState.Equals(state)); }
        }


    }
}
