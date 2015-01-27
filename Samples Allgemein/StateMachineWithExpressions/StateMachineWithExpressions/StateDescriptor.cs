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
        private readonly Dictionary<string, object> _parentData;
        
         
        internal StateDescriptor(TState state, Dictionary<string, object> data)
        {
            // _stateExpressions = new List<Func<StateRequest, bool>>();
            _listExpressions = new ArrayList();
            ItemState = state;

            _parentData = data;
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

        public bool IsState()
        {
            // http://stackoverflow.com/questions/7801165/how-to-create-a-expression-lambda-when-a-type-is-not-known-until-runtime

            //_parentData.Values.ToList()
            //    .ForEach(delegate(object o)
            //    {
            //        var t = o.GetType().MakeByRefType();

            //        _listExpressions.ToArray().OfType<t>()
            //    });


        }

    }
}
