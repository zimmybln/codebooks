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
        //private readonly List<Func<StateRequest, bool>> _stateExpressions;

        private readonly ArrayList _listExpressions;
         
        internal StateDescriptor(TState state)
        {
            // _stateExpressions = new List<Func<StateRequest, bool>>();
            _listExpressions = new ArrayList();
            ItemState = state;
        }

        public TState ItemState { get; private set; }

        public StateDescriptor<TState> WithEnterCondition<T>(Expression<Func<T, bool>> condition)
        {
            //if (condition.Body.NodeType == ExpressionType.Equal)
            //{
            //    BinaryExpression expression = (BinaryExpression)condition.Body;

            //    Debug.WriteLine(expression.Left.ToString());
            //}
            
            _listExpressions.Add(condition.Compile());
            return this;
        }

        /// <summary>
        /// Überprüft, ob ein Status gesetzt ist oder nicht.
        /// </summary>
        /// <remarks>
        /// Der Status ist an eine Anzahl von Bedingungen geknüpft. Hier wird überprüft, ob es mindestens
        /// eine Bedingung gibt, die nicht erfüllt ist.
        /// </remarks>
        public bool IsState<TData>(TData queryData)
        {
            return _listExpressions.ToArray()
                .OfType<Func<TData, bool>>()
                .FirstOrDefault(c => c(queryData) == false) == null;
        }

    }
}
