using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using SplashScreenCase2.Contracts;
using WPFArchitectureModel.Library.Commands;

namespace SplashScreenCase2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private UserControl[] _lstUserControls;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _lstUserControls = new UserControl[5];

            // Erstellung der für den Abbruch notwendigen Instanzen
            var cancelStartupSequence = new CancellationTokenSource();

            // Splashscreen erstellen, konfigurieren und anzeigen
            var wndSplashScreen = new AppSplashScreen();
            var objSplashScreenModel = new AppSplashScreenModel();

            objSplashScreenModel.CancelCommand = new MethodCommand((Command, O) => cancelStartupSequence.Cancel());

            wndSplashScreen.DataContext = objSplashScreenModel;
            wndSplashScreen.Show();

            var tskStartupSequence = new Task((parameter) =>
                {
                    var info = parameter as StartupParameters;

                    // Globales Initialisieren der Oberfläche
                    for (int i = 0; i < _lstUserControls.Length; i++)
                    {
                        // Ausgabe der Statusinformation
                        var strInfo = String.Format("Initialisiere {0}", i);

                        objSplashScreenModel.Status = strInfo;

                        // Die folgende Aktion wird synchron im Hauptthread aufgerufen, aber erst dann,
                        // wenn alle anderen Tätigkeiten des Threads abgeschlossen sind und sich der
                        // Thread im Leerlauf befindet. Somit wird sichergestellt, dass die Ausgabe der
                        // Information erfolgt und erst danach die Funktionalität, hier die Initialisierung
                        // der Steuerelemente, ausgeführt wird. 
                        int i1 = i;
                        this.Dispatcher.Invoke(new Action(() => InitializeUserControl(i1)), DispatcherPriority.ApplicationIdle);
                    }
                },
                new StartupParameters() { CancellationToken = cancelStartupSequence.Token, SplashScreenInfo = objSplashScreenModel });

            // abschließende Sequenz, dieser Code wird durch die Angabe eines SynchronizationContext
            // im UI Thread der Anwendung ausgeführt.
            tskStartupSequence.ContinueWith(t =>
                    {
                        if (!t.IsCanceled && (!t.IsFaulted))
                        {
                            // Anzeige des Hauptfensters, wenn die Initialisierung
                            // fehlerfrei durchgelaufen ist
                            this.MainWindow = new ShellWindow();
                            this.MainWindow.Show();
                        }
                        else
                        {
                            Debug.WriteLine("Die Startsequenz wurde abgebrochen");
                            // eventuelle Aufräumarbeiten
                        }

                        // Schließen des Splashscreens
                        wndSplashScreen.Close();

                    }, TaskScheduler.FromCurrentSynchronizationContext());

            // Ausführen
            tskStartupSequence.Start();

        }

        private void InitializeUserControl(int Index)
        {
            if (Index < 0 || Index >= _lstUserControls.Length)
                throw new IndexOutOfRangeException();

            Debug.WriteLine(String.Format("Initialisiere {0} von {1}", Index + 1, _lstUserControls.Length));

            var rnd = new Random();

            var ctl = new UserControl();

            // Initialisierung
            var pnl = new WrapPanel();
            pnl.Orientation = Orientation.Horizontal;

            for (int i = 0; i < rnd.Next(0, 20); i++)
            {
                var btt = new Button();
                btt.Margin = new Thickness(2);
                btt.Width = 30;
                btt.Height = 30;
                btt.Content = String.Format("{0}", i);

                pnl.Children.Add(btt);
            }

            ctl.Content = pnl;

            Thread.Sleep(10000);

            _lstUserControls[Index] = ctl;
        }

        public UserControl GetCommonControlInstance(int Index)
        {
            if (Index < 0 || Index >= _lstUserControls.Length)
                throw new IndexOutOfRangeException();

            return _lstUserControls[Index];
        }
    }

    internal class StartupParameters
    {
        internal CancellationToken CancellationToken { get; set; }

        internal ISplashScreenInfo SplashScreenInfo { get; set; }
    }
}
