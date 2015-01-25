using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UseCase_02_Dialog.ViaComposition;
using UseCase_02_Dialog.ViaConstructor;

namespace UseCase_02_Dialog
{
    /// <summary>
    /// Hauptfenster der Anwendung
    /// </summary>
    public class MainWindowModel : INotifyPropertyChanged
    {
        private string mv_strFooValue;

        public MainWindowModel()
        {
            // Der Aufruf wird an einen Delegate weitergeleitet
            RunDialogViaCompositionCommand = new ActionCommand(ShowInputDialogViaComposition);
            RunDialogViaConstructorCommand = new ActionCommand(ShowInputDialogViaConstructor);
        }

        public ICommand RunDialogViaCompositionCommand { get; private set; }

        public ICommand RunDialogViaConstructorCommand { get; private set; }

        public string FooValue
        {
            get { return mv_strFooValue; }
            set
            {
                if (String.Compare(mv_strFooValue, value) != 0)
                {
                    mv_strFooValue = value;
                    RaisePropertyChanged("FooValue");
                }
            }
        }

        private void ShowInputDialogViaComposition(object Parameter)
        {
            // Instanz des Models erstellen
            var dlgInputDialog = new InputDialogViaCompositionModel();

            // Werte zuordnen
            dlgInputDialog.InputValue = this.FooValue;

            // Aufrufen und Ergebnis auswerten
            if (dlgInputDialog.ShowDialog("ViaComposition\\InputDialogViaComposition.xaml") == true)
            {
                this.FooValue = dlgInputDialog.InputValue;
            }
        }

        private void ShowInputDialogViaConstructor(object Parameter)
        {
            // Erstellen eines Kataloges mit dem ausführenden Assembly
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            // Ermitteln des exportierten Dialoges
            var dlg = container.GetExportedValue<InputDialogViaConstructorModel>();

            // Und Verwendung
            dlg.InputValue = this.FooValue;

            if (dlg.ShowDialog() == true)
            {
                this.FooValue = dlg.InputValue;
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler h = this.PropertyChanged;

            if (h != null)
                h(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
