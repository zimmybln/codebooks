using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Threading;

namespace CommandSample
{
    public static class MyCommands
    {
        private static RoutedUICommand msv_cmdSimpleCommand;
        private static SampleCommand msv_cmdSample;
        private static readonly RoutedUICommand msv_cmdRoutedCommand;

        static MyCommands()
        {
            msv_cmdSimpleCommand = new RoutedUICommand("Einfacher Befehl - verändert", "SimpleCommand", typeof(MyCommands));
            msv_cmdSample = new SampleCommand();
            msv_cmdRoutedCommand = new RoutedUICommand("Befehl mit Route", "RouteCommand", typeof(MyCommands));
        }

        public static RoutedUICommand SimpleCommand
        {
            get { return msv_cmdSimpleCommand; }
        }

        public static SampleCommand SampleCommand
        {
            get { return msv_cmdSample; }
        }

        public static RoutedUICommand RouteCommand
        {
            get { return msv_cmdRoutedCommand; }
        }
    }

    public class SampleCommand : ICommand
    {
        private DispatcherTimer mv_tmrTrackChanges = null;
        private bool mv_fCanExecute = true;

        public SampleCommand()
        {
            mv_tmrTrackChanges = new DispatcherTimer();
            mv_tmrTrackChanges.Interval = new TimeSpan(0, 0, 5); // alle 5 Sekunden soll sich das ändern.
            mv_tmrTrackChanges.Tick += new EventHandler(OnTick);
            mv_tmrTrackChanges.IsEnabled = false;
        }

        void OnTick(object sender, EventArgs e)
        {
            mv_fCanExecute = !mv_fCanExecute;

            // Ereignis auslösen, dass sich etwas geändert hat.
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            if (mv_tmrTrackChanges.IsEnabled == false)
                mv_tmrTrackChanges.IsEnabled = true;

            return mv_fCanExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Debug.WriteLine("Das ist jetzt ein anderes Beispiel" + parameter.ToString());
        }

    }

}
    

