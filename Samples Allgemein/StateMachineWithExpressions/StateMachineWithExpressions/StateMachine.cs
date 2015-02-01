using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
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
    public class StateMachine<TStates> : IStateMachine
    {
        private readonly List<StateDescriptor<TStates>> _states = new List<StateDescriptor<TStates>>();
        private readonly List<string> _listTriggerNames = new List<string>(); 
        private bool _deferRefresh = false;
        
        public StateMachine(TStates state)
        {
            Data = new ObservableDictionary<string, object>();
            Data.CollectionChanged += OnDataCollectionChanged;

            Current = state;
        }

        #region Ereignisse

        public event StateChangedHandler StateChanged;

        protected void RaiseStateChanged()
        {
            var evt = StateChanged;

            if (evt != null)
                StateChanged(this, EventArgs.Empty);
        }

        #endregion

        private void OnDataCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                // Es werden alle NotifyPropertyChanged gesucht und abboniert
                args.NewItems.OfType<INotifyPropertyChanged>().ToList().ForEach(
                    delegate(INotifyPropertyChanged changed)
                    {
                        ((INotifyPropertyChanged)changed).PropertyChanged += OnPropertyChanged;
                    });
            }
        }

        /// <summary>
        /// Diese Methode wird verwendet, um Änderungen an zugeordneten Eigenschaften
        /// zu ermitteln
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (_listTriggerNames.Contains(args.PropertyName))
                FindState();
        }

        public StateDescriptor<TStates> AddStateDescriptor(TStates state)
        {
            if (_states.FirstOrDefault(s => s.ItemState.Equals(state)) != null)
                throw new DuplicateNameException();

            var statedescriptor = new StateDescriptor<TStates>(state, this);

            _states.Add(statedescriptor);

            return statedescriptor;
        }

        /// <summary>
        /// Fügt eine Liste von Eigenschaftsnamen hinzu, bei deren Änderung das Finden des neuen Status
        /// ausgelöst wird.
        /// </summary>
        public StateMachine<TStates> WithTriggers(params string[] propertyTriggers)
        {
            propertyTriggers.ToList().ForEach(delegate(string s)
            {
                if (!_listTriggerNames.Contains(s))
                    _listTriggerNames.Add(s);
            });
            return this;
        }

        /// <summary>
        /// Überprüft, ob für einen Status bereits eine Beschreibung vorhanden ist.
        /// </summary>
        public bool Exists(TStates state)
        {
            return _states.FirstOrDefault(s => s.ItemState.Equals(state)) != null;
        }

        public InvalidStateChangeReasons TryToEnterState(TStates state)
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
                if (!stateTo.IsState())
                    return InvalidStateChangeReasons.DataDoesntMatch;
            }

            // Wenn alle Überprüfungen erfolgreich durchgeführt worden sind, kann der Status gewechselt werden
            Current = state;

            // Ereignis über Statusänderung auslösen
            RaiseStateChanged();

            return InvalidStateChangeReasons.Ok;
        }

        /// <summary>
        /// Wechselt den Status. Kann der Status nicht gewechselt werden, wird eine Ausnahme ausgelöst.
        /// </summary>
        public void EnterState(TStates state)
        {
            var reason = TryToEnterState(state);

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

        public void FindState()
        {
            if (_deferRefresh)
                return;

            StateDescriptor<TStates> detectedState = null;

            foreach (StateDescriptor<TStates> state in _states)
            {
                if (state.IsState())
                {
                    if (detectedState != null)
                    {
                        throw new AmbiguousStatesException();
                    }

                    detectedState = state;
                }
            }

            if (detectedState != null)
            {
                Current = detectedState.ItemState;

                RaiseStateChanged();
            }
        }

        public ObservableDictionary<string, object> Data { get; private set; } 

        public TStates Current { get; private set; }

        public StateDescriptor<TStates> this[TStates state]
        {
            get { return _states.FirstOrDefault(s => s.ItemState.Equals(state)); }
        }
        
        protected class DeferRefreshEnvelope : IDisposable
        {
            private readonly StateMachine<TStates> _parentMachine;
 
            internal DeferRefreshEnvelope(StateMachine<TStates> parentMachine)
            {
                _parentMachine = parentMachine;
            }

            public void Dispose()
            {
                if (_parentMachine != null)
                {
                    _parentMachine._deferRefresh = false;
                    _parentMachine.FindState();
                }
            }
        }

    }
}
