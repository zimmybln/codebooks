using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public class StateDescriptorWithExpressions<TState, TData> : StateDescriptor<TState, TData>
    {
        private readonly List<Func<TData, bool>> _stateExpressions;

        public StateDescriptorWithExpressions(TState state) : base(state)
        {
            _stateExpressions = new List<Func<TData, bool>>();
        }

        public StateDescriptorWithExpressions<TState, TData> WithEnterCondition(Expression<Func<TData, bool>> condition)
        {
            //if (condition.Body.NodeType == ExpressionType.Equal)
            //{
            //    BinaryExpression expression = (BinaryExpression)condition.Body;

            //    Debug.WriteLine(expression.Left.ToString());
            //}

            _stateExpressions.Add(condition.Compile());
            return this;
        }

        public override bool IsState(TData data)
        {
            return _stateExpressions.FirstOrDefault(fnc => !fnc(data)) == null;
        }
    }
}
