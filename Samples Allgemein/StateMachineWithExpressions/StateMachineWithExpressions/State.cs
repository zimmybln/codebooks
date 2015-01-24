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
    public class State<T>
        where T: class 
    {
        private readonly List<Func<T, bool>> _stateExpressions;
        private readonly StateMachine<T> _parentMachine;

        internal State(string name, StateMachine<T> parent)
        {
            _stateExpressions = new List<Func<T, bool>>();
            Name = name;
            _parentMachine = parent;
        }
        
        public string Name { get; private set; }


        public State<T> WithCondition(Expression<Func<T, bool>> condition)
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
            return _stateExpressions.FirstOrDefault(c => c(_parentMachine.Host) == false) == null;
        }

    }
}
