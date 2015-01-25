using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;


namespace ControlsWorkbench
{
    public static class GlobalCommands
    {
        private static RoutedUICommand msv_cmdSetStatusText;

        static GlobalCommands()
        {
            msv_cmdSetStatusText = new RoutedUICommand("Set Status Text", "SetStatusText", typeof(GlobalCommands));
        }

        public static RoutedUICommand SetStatusTextCommand
        {
            get { return msv_cmdSetStatusText; }
        }

    }
}
