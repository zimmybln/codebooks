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

    /// <summary>
    /// Mit dieser Klasse wird ein Zustand beschrieben.
    /// </summary>
    public class StateDescriptor<TState>
    {
        private readonly List<Func<StateMachine<TState>, bool>> _stateExpressions;
        private readonly List<TState> _listPredecessorStates = new List<TState>();

        private StateMachine<TState> _parentMachine;

        public StateDescriptor(TState state)
        {
            _stateExpressions = new List<Func<StateMachine<TState>, bool>>();
            ItemState = state;

            _parentMachine = null;
        }
         
        public TState ItemState { get; private set; }

        internal StateMachine<TState> Host
        {
            get { return _parentMachine; }
            set { _parentMachine = value; }
        }

        public ReadOnlyCollection<TState> PredecessorStates
        {
            get { return _listPredecessorStates.AsReadOnly(); }
        }

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
        public virtual bool IsState()
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
