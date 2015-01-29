using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public class StateDescriptor<TState>
    {
        private readonly List<Func<StateMachine<TState>, bool>> _stateExpressions;
        private readonly List<TState> _listPredecessorStates = new List<TState>();
        private readonly List<TState> _listSucessorStates = new List<TState>(); 

        private readonly StateMachine<TState> _parentMachine;
         
        internal StateDescriptor(TState state, StateMachine<TState> parentMachine)
        {
            _stateExpressions = new List<Func<StateMachine<TState>, bool>>();
            ItemState = state;

            _parentMachine = parentMachine;
        }

        public TState ItemState { get; private set; }

        public StateDescriptor<TState> WithEnterCondition(Expression<Func<StateMachine<TState>, bool>> condition)
        {
            //if (condition.Body.NodeType == ExpressionType.Equal)
            //{
            //    BinaryExpression expression = (BinaryExpression)condition.Body;

            //    Debug.WriteLine(expression.Left.ToString());
            //}

            _stateExpressions.Add(condition.Compile());
            return this;
        }

        /// <summary>
        /// Fügt dem Status Nachfolgestatus zu.
        /// </summary>
        public StateDescriptor<TState> WithSuccessorStates(params TState[] states)
        {
            _listSucessorStates.Clear();
            _listPredecessorStates.AddRange(states);

            return this;
        }


        /// <summary>
        /// Fügt dem Status Vorgängerstatus hinzu.    
        /// </summary>
        public StateDescriptor<TState> WithPredecessorStates(params TState[] states)
        {
            _listPredecessorStates.Clear();
            _listPredecessorStates.AddRange(states);

            return this;
        }

        /// <summary>
        /// Überprüft, ob ein Status gesetzt ist oder nicht.
        /// </summary>
        /// <remarks>
        /// Der Status ist an eine Anzahl von Bedingungen geknüpft. Hier wird überprüft, ob es mindestens
        /// eine Bedingung gibt, die nicht erfüllt ist.
        /// </remarks>
        public bool IsState()
        {
            return _stateExpressions.FirstOrDefault(fnc => !fnc(_parentMachine)) == null;
        }

        //public bool IsState()
        //{
        //    // http://stackoverflow.com/questions/7801165/how-to-create-a-expression-lambda-when-a-type-is-not-known-until-runtime

        //    //_parentData.Values.ToList()
        //    //    .ForEach(delegate(object o)
        //    //    {
        //    //        var t = o.GetType().MakeByRefType();

        //    //        _listExpressions.ToArray().OfType<t>()
        //    //    });


        //}

    }
}
