using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ControlWorkbenchButton.Contracts;
using ControlWorkbenchButton.Services;
using WPFArchitectureModel.Library;
using WPFArchitectureModel.Library.Behaviors;
using WPFArchitectureModel.Library.Models;

namespace ControlWorkbenchButton.Models
{
    [Export(typeof(IMainWindowModel))]
    public class MainWindowModel : ViewModelBase, IMainWindowModel
    {
        private int _nMessageCounter = 0;

        public MainWindowModel()
        {
            // Initialisierung der Variablen
            Modules = new ObservableCollection<IApplicationItemFactory>(ApplicationServices.GetItems<IApplicationItemFactory>());
            Messages = new ObservableCollection<string>();
            LoadedAdapter = new LoadedAdapter(OnLoaded);

            // Auch das Model selbst muss auf Eigenschaftsänderungen reagieren
            PropertyChanged += OnMyPropertyChanged;

            // Reaktion auf Benachrichtigungen
            var implNotificationService = ApplicationServices.GetService<IViewSelectorNotificationService>();

            if (implNotificationService != null)
                implNotificationService.OnNotify += ReceiveNotification;
        }

        private void ReceiveNotification(object Sender, IViewSelectorNotification Notification)
        {
            _nMessageCounter++;

            if (Notification is ModuleShowedNotification)
                Messages.Add(String.Format("{0:0000}: Modul wurde angezeigt: {1}", _nMessageCounter, ((ModuleShowedNotification)Notification).ModuleName));
            else if (Notification is ModuleHiddenNotification)
                Messages.Add(String.Format("{0:0000} Modul wurde verborgen: {1}", _nMessageCounter, ((ModuleHiddenNotification)Notification).ModuleName));
        }

        private void OnLoaded()
        {
            var i = Modules.FirstOrDefault(x => x.Name == "Ein erstes Modul");

            if (i != null)
                SelectedModule = i;
        }

        private void OnMyPropertyChanged(object Sender, PropertyChangedEventArgs PropertyChangedEventArgs)
        {
            if (PropertyChangedEventArgs.PropertyName == "SelectedModule")
            {
                if (SelectedModule != null)
                    ApplicationServices.Regions.FillRegionWithInstance("MainContent", SelectedModule.Item, null);
            }
        }

        #region Eigenschaften

        public ObservableCollection<IApplicationItemFactory> Modules { get; private set; }

        public ObservableCollection<string> Messages { get; private set; }

        public IApplicationItemFactory SelectedModule
        {
            get { return GetValue<IApplicationItemFactory>("SelectedModule", null); }
            set { SetValue("SelectedModule", value); }
        }

        public LoadedAdapter LoadedAdapter { get; private set; }

        #endregion

    }
}
