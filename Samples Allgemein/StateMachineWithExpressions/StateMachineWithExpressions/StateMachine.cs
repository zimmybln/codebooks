using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public class StateMachine<T>
        where T: class 
    {
        private List<State<T>> _states = new List<State<T>>();

        private Dictionary<string, object> dictionary
            = new Dictionary<string, object>();

        private T _item;

        public StateMachine(T item)
        {
            _item = item;
        }


        public State<T> AddState(string name)
        {
            if (_states.FirstOrDefault(s => s.Name.Equals(name)) != null)
                throw new Exception("item already in");

            var state = new State<T>(name, this);

            _states.Add(state);

            return state;
        }

        internal T Host  { get { return _item; } }

        public State<T> this[string name]
        {
            get { return _states.FirstOrDefault(s => s.Name.Equals(name)); }
        }


    }
}
