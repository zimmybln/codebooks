using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StateMachineWithExpressions.Guards;

namespace StateMachineWithExpressions.Tests
{
    [TestFixture]
    public class PropertyChangedGuardTests
    {

        [Test]
        public void RaiseStateChangeOnPropertyChanged()
        {
            // Konfiguration der StateMachine und der relevanten Status
            var machine = new StateMachine<ItemStates, SampleContainer>(ItemStates.Zero);
            var state = new StateDescriptorWithExpressions<ItemStates, SampleContainer>(ItemStates.Between10And19)
                .WithEnterCondition(d => d.X >= 10 && d.X < 20);

            machine.States.Add(state);

            // Erstellen des Datencontainers
            var data = new SampleContainer();

            // Erstellen und Konfiguration des Datenquards
            var guard = new PropertyChangedGuard<ItemStates, SampleContainer>(machine, data);

            guard.PropertyNames.Add("X");

            // Ändern der Daten 
            data.X = 15;

            // Überprüfen des aktuellen Status
            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Es liegt der erwartete Status vor");



        }


    }

    public class SampleContainer : INotifyPropertyChanged
    {

        private int _x = 0;

        public int X
        {
            get { return _x; }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _y = 0;

        public int Y
        {
            get { return _y; }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    RaisePropertyChanged();
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            var p = PropertyChanged;

            if (p != null && !String.IsNullOrWhiteSpace(name))
                p(this, new PropertyChangedEventArgs(name));
        }
    }


}
