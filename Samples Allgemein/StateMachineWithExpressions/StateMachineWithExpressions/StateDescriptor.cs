using System;
using System.Collections.Generic;
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
        private readonly List<Func<StateTransition, bool>> _stateExpressions;
        
        internal StateDescriptor(TState state)
        {
            _stateExpressions = new List<Func<StateTransition, bool>>();
            ItemState = state;
        }
        
        public TState ItemState { get; private set; }
        
        public StateDescriptor<TState> WithCondition(Expression<Func<StateTransition, bool>> condition)
        {
            if (condition.Body.NodeType == ExpressionType.Equal)
            {
                BinaryExpression expression = (BinaryExpression)condition.Body;

                Debug.WriteLine(expression.Left.ToString());
            }
            
            _stateExpressions.Add(condition.Compile());
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
            return _stateExpressions.FirstOrDefault(c => c(new StateTransition()) == false) == null;
        }

    }
}
