using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace UseCase_02_Dialog.ViaComposition
{

    /// <summary>
    /// Basisklasse für Modelle zur Verwendung mit Dialogen.
    /// </summary>
    public abstract class DialogViaCompositionModelBase : INotifyPropertyChanged
    {
        private Window mv_viewCorospondingView = null;

        /// <summary>
        /// Initialisiert eine neue Instanz dieser Klasse
        /// </summary>
        protected DialogViaCompositionModelBase()
        {
            OnOkCommand = new ActionCommand(ReceiveOnOk);
            OnCancelCommand = new ActionCommand(ReceiveOnCancel);
        }

        #region Eigenschaften

        /// <summary>
        /// Dieses Command schließt den Dialog nach einer erfolgreichen 
        /// Gültigkeitsüberprüfung der eingegebenen Daten.
        /// </summary>
        public ICommand OnOkCommand { get; private set; }

        /// <summary>
        /// Dieses Command schließt den Dialog.
        /// </summary>
        public ICommand OnCancelCommand { get; private set; }

        #endregion

        /// <summary>
        /// Wird aufgerufen, wenn der Dialog mit OK beendet werden soll.
        /// </summary>
        private void ReceiveOnOk(object Parameter)
        {
            // Prüfen der Eigenschaften
            if (this.ArePropertiesValid() == false)
                return;

            mv_viewCorospondingView.DialogResult = true;
        }

        /// <summary>
        /// Wird aufgerufen, wenn der Dialog mit Cancel beendet werden soll.
        /// </summary>
        private void ReceiveOnCancel(object Parameter )
        {
            mv_viewCorospondingView.DialogResult = false;
        }

        /// <summary>
        /// Methode zur Gültigkeitsüberprüfung der Eigenschaften des Models. Sollte
        /// in Ableitungen überschrieben werden.
        /// </summary>
        protected virtual bool ArePropertiesValid()
        {
            return true;
        }

        /// <summary>
        /// Zeigt den Dialog mit einer Ressource an, die durch den Aufrufparameter 
        /// übergeben wird.
        /// </summary>
        public bool? ShowDialog(string ResourceName)
        {
            return this.ShowDialog(new Uri(ResourceName, UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Zeigt den Dialog mit einer Ressource an, die durch den Aufrufparameter 
        /// übergeben wird.
        /// </summary>
        public bool? ShowDialog(Uri UriDialog)
        {
            // Laden der Resource
            object obj = Application.LoadComponent(UriDialog);

            // Diverse Gültigkeitsüberprüfungen
            if (obj == null && !(obj.GetType() is Window))
                return false;

            var viewCorospondingView = obj as Window;

            if (viewCorospondingView == null)
                return false;

            // Setzen von Eigenschaften
            viewCorospondingView.DataContext = this;
            viewCorospondingView.ResizeMode = ResizeMode.NoResize;
            viewCorospondingView.ShowInTaskbar = false;
            viewCorospondingView.WindowStyle = WindowStyle.SingleBorderWindow;

            mv_viewCorospondingView = viewCorospondingView;

            // Anzeige des Dialoges
            bool? dlgResult = viewCorospondingView.ShowDialog();

            mv_viewCorospondingView = null;

            return dlgResult;
        }

        #region INotifyPropertyChanged
        
        /// <summary>
        /// Benachrichtigung über Änderungen an den Eigenschaften
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string Name)
        {
            PropertyChangedEventHandler h = this.PropertyChanged;

            if (h != null)
                h(this, new PropertyChangedEventArgs(Name));
        }

        #endregion
    }
}
