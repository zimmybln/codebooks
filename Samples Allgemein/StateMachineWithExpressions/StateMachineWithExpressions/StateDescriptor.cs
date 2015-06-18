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
    /// <remarks>Diese Klasse beschreibt die grundlegenden Eigenschaften eines Zustandes</remarks>
    public abstract class StateDescriptor<TState, TData>
    {
        
        private readonly List<TState> _listPredecessorStates = new List<TState>();

        protected StateDescriptor(TState state)
        {
            ItemState = state;
        }
         
        public TState ItemState { get; private set; }

        public ReadOnlyCollection<TState> PredecessorStates
        {
            get { return _listPredecessorStates.AsReadOnly(); }
        }
        
        /// <summary>
        /// Fügt dem Status Vorgängerstatus hinzu.    
        /// </summary>
        public StateDescriptor<TState, TData> WithPredecessorStates(params TState[] states)
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
        public virtual bool IsState(TData data)
        {
            return false;
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
