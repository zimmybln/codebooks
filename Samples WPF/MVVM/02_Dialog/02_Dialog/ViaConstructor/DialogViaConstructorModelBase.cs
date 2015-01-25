using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace UseCase_02_Dialog.ViaConstructor
{
    public class DialogViaConstructorModelBase : INotifyPropertyChanged 
    {
        private readonly IView mv_implView;

        protected DialogViaConstructorModelBase(IView View)
        {
            mv_implView = View;

            mv_implView.DataContext = this;

            OnOkCommand = new ActionCommand(ReceiveOnOk);
            OnCancelCommand = new ActionCommand(ReceiveOnCancel);
        }

        public bool? ShowDialog()
        {
            return mv_implView.ShowDialog();
        }

        /// <summary>
        /// Dieses Command schließt den Dialog nach einer erfolgreichen 
        /// Gültigkeitsüberprüfung der eingegebenen Daten.
        /// </summary>
        public ICommand OnOkCommand { get; private set; }

        /// <summary>
        /// Dieses Command schließt den Dialog.
        /// </summary>
        public ICommand OnCancelCommand { get; private set; }

        /// <summary>
        /// Wird aufgerufen, wenn der Dialog mit OK beendet werden soll.
        /// </summary>
        private void ReceiveOnOk(object Parameter)
        {
            // Prüfen der Eigenschaften
            if (this.ArePropertiesValid() == false)
                return;

            mv_implView.DialogResult = true;
        }

        /// <summary>
        /// Wird aufgerufen, wenn der Dialog mit Cancel beendet werden soll.
        /// </summary>
        private void ReceiveOnCancel(object Parameter)
        {
            mv_implView.DialogResult = false;
        }

        protected virtual bool ArePropertiesValid()
        {
            return true;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string Name)
        {
            PropertyChangedEventHandler h = this.PropertyChanged;

            if (h != null)
                h(this, new PropertyChangedEventArgs(Name));
        }
    }
}
