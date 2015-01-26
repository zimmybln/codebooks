using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public class StateMachine<TStates, T>
        where T: class 
    {
        private List<StateDescriptor<TStates>> _states = new List<StateDescriptor<TStates>>();

        private Dictionary<string, object> dictionary
            = new Dictionary<string, object>();

        private T _item;

        public StateMachine(TStates state, T item)
        {
            _item = item;
        }

        public StateDescriptor<TStates> AddStateDescriptor(TStates state)
        {
            if (_states.FirstOrDefault(s => s.ItemState.Equals(state)) != null)
                throw new Exception("item already in");

            var statedescriptor = new StateDescriptor<TStates>(state);

            _states.Add(statedescriptor);

            return statedescriptor;
        }

        internal T Host  { get { return _item; } }

        public StateDescriptor<TStates> this[TStates state]
        {
            get { return _states.FirstOrDefault(s => s.ItemState.Equals(state)); }
        }


    }
}
