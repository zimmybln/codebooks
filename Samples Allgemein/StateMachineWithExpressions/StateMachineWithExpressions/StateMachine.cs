using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StateMachineWithExpressions.Events;
using StateMachineWithExpressions.Exceptions;

namespace StateMachineWithExpressions
{

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Eine Statusbeschreibung ist die Zuordnung von Gültigkeiten zu einem Status. 
    /// </remarks>
    public class StateMachine<TStates, TData>
    {
        // private readonly List<StateDescriptor<TStates, TData>> _states = new List<StateDescriptor<TStates, TData>>();
        private readonly List<string> _listTriggerNames = new List<string>(); 
        private bool _deferRefresh = false;

        private readonly StateCollection _stateDescriptors;
        
        public StateMachine(TStates state)
        {
            Current = state;

            _stateDescriptors = new StateCollection(this);
        }

        private void OnStatesCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (StateDescriptor<TStates, TData> item in args.NewItems)
                {
                    if (_stateDescriptors.FirstOrDefault(sd => Equals(sd.ItemState, item.ItemState)) != null)
                    {
                        throw new DuplicateNameException(item.ItemState.ToString());
                    }
                }
            }

        }

        #region Ereignisse

        public delegate void StateChangedHandler(object sender, StateChangedArgs args);

        public class StateChangedArgs : EventArgs
        {
            internal StateChangedArgs(TStates formerState, TStates newState)
            {
                FormerState = formerState;
                NewState = newState;
            }

            public TStates FormerState { get; private set; }

            public TStates NewState { get; private set; }

        }

        public event StateChangedHandler StateChanged;

        protected void RaiseStateChanged(TStates formerState, TStates newState)
        {
            var evt = StateChanged;

            if (evt != null)
                StateChanged(this, new StateChangedArgs(formerState, newState));
        }

        #endregion

        #region Eigenschaften

        public StateCollection States
        {
            get { return _stateDescriptors; }
        }

        #endregion


        ///// <summary>
        ///// Fügt die Beschreibung eines Zustandes hinzu.
        ///// </summary>
        //public void AddStateDescriptor(StateDescriptor<TStates, TData> stateDescriptor)
        //{
        //    if (stateDescriptor == null)
        //        throw new ArgumentNullException("stateDescriptor");

        //    if (_stateDescriptors.FirstOrDefault(s => s.ItemState.Equals(stateDescriptor.ItemState)) != null)
        //        throw new DuplicateNameException();

        //    _states.Add(stateDescriptor);
        //}

        /// <summary>
        /// Fügt eine Liste von Eigenschaftsnamen hinzu, bei deren Änderung das Finden des neuen Status
        /// ausgelöst wird.
        /// </summary>
        //public StateMachine<TStates> WithTriggers(params string[] propertyTriggers)
        //{
        //    propertyTriggers.ToList().ForEach(delegate(string s)
        //    {
        //        if (!_listTriggerNames.Contains(s))
        //            _listTriggerNames.Add(s);
        //    });
        //    return this;
        //}

        /// <summary>
        /// Überprüft, ob für einen Status bereits eine Beschreibung vorhanden ist.
        /// </summary>

        public InvalidStateChangeReasons TryToEnterState(TStates state, TData data)
        {
            // Wenn der Status bereits aktuell ist, erfolgt kein Wechsel
            if (state.Equals(Current))
                return InvalidStateChangeReasons.Ok;

            // Darf der aktuelle Status verlassen werden?
            var stateFrom = this[Current];

            if (stateFrom != null)
            {
                // Momentan kann ein Status immer verlassen werden
            }

            var stateTo = this[state];
           
            if (stateTo != null)
            {
                // Überprüfen, ob von diesem Status in den anderes gewechselt werden kann: ist gültiger Vorgängerstatus
                var lst = stateTo.PredecessorStates;

                if (lst.Any() && !lst.Contains(Current))
                    return InvalidStateChangeReasons.InvalidPredecessor;

                // Überprüfen, ob die Daten gültig sind
                if (!stateTo.IsState(data))
                    return InvalidStateChangeReasons.DataDoesntMatch;
            }

            var formerstate = Current;

            // Wenn alle Überprüfungen erfolgreich durchgeführt worden sind, kann der Status gewechselt werden
            Current = state;

            // Ereignis über Statusänderung auslösen
            RaiseStateChanged(formerstate, Current);

            return InvalidStateChangeReasons.Ok;
        }

        /// <summary>
        /// Wechselt den Status. Kann der Status nicht gewechselt werden, wird eine Ausnahme ausgelöst.
        /// </summary>
        public void EnterState(TStates state, TData data)
        {
            var reason = TryToEnterState(state, data);

            if (reason != InvalidStateChangeReasons.Ok)
                throw new InvalidStateChangeException(reason);
        }

        

        /// <summary>
        /// Unterbindet die fortlaufende Aktualisierung des Status, die erst dann wieder aufgenommen 
        /// wird, wenn das zurückgegebene Objekt freigegeben wurde.
        /// </summary>
        public IDisposable DeferRefresh()
        {
            _deferRefresh = true;
            return new DeferRefreshEnvelope(this);
        }


        /// <summary>
        /// Löst die Suche nach dem aktuellen Zustand aus.
        /// </summary>
        /// <remarks>
        /// Wenn sich die Instanz aktuell in einem Verzögerungszustand befindet,
        /// wird die Suche nicht ausgeführt.
        /// </remarks>
        /// <returns>
        /// Liefert True, wenn ein neuer Zustand erreicht worden ist
        /// </returns>
        public TStates FindState(TData data)
        {
            if (_deferRefresh)
                return default(TStates);

            StateDescriptor<TStates, TData> detectedState = null;

            foreach (StateDescriptor<TStates, TData> state in _stateDescriptors)
            {
                if (state.IsState(data))
                {
                    if (detectedState != null)
                    {
                        throw new AmbiguousStatesException();
                    }

                    detectedState = state;
                }
            }

            if (detectedState != null && !Equals(detectedState.ItemState, Current))
            {
                var formerstate = Current;

                Current = detectedState.ItemState;

                RaiseStateChanged(formerstate, Current);

                return Current;
            }

            return Current;
        }
        

        public TStates Current { get; private set; }

        public StateDescriptor<TStates, TData> this[TStates state]
        {
            get { return _stateDescriptors.FirstOrDefault(s => s.ItemState.Equals(state)); }
        }
        
        protected class DeferRefreshEnvelope : IDisposable
        {
            private readonly StateMachine<TStates, TData> _parentMachine;
 
            internal DeferRefreshEnvelope(StateMachine<TStates, TData> parentMachine)
            {
                _parentMachine = parentMachine;
            }

            public void Dispose()
            {
                if (_parentMachine != null)
                {
                    _parentMachine._deferRefresh = false;
                   // _parentMachine.FindState();
                }
            }
        }

        public class StateCollection : ICollection<StateDescriptor<TStates, TData>>
        {
            private readonly List<StateDescriptor<TStates, TData>> _lstItems = new List<StateDescriptor<TStates, TData>>();
            private readonly StateMachine<TStates, TData> _host;

            internal StateCollection(StateMachine<TStates, TData> host)
            {
                _host = host;
            }

            public void Add(StateDescriptor<TStates, TData> item)
            {
                if (item == null)
                    throw new ArgumentNullException("stateDescriptor");

                if (_lstItems.FirstOrDefault(s => s.ItemState.Equals(item.ItemState)) != null)
                    throw new DuplicateNameException();
                
                _lstItems.Add(item);
            }

            public void Clear()
            {
                _lstItems.Clear();
            }

            public bool Contains(StateDescriptor<TStates, TData> item)
            {
                return _lstItems.Contains(item);
            }

            public void CopyTo(StateDescriptor<TStates, TData>[] array, int arrayIndex)
            {
                _lstItems.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return _lstItems.Count; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public bool Remove(StateDescriptor<TStates, TData> item)
            {
                return _lstItems.Remove(item);
            }

            public IEnumerator<StateDescriptor<TStates, TData>> GetEnumerator()
            {
                return _lstItems.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _lstItems.GetEnumerator();
            }
        }

    }
}
