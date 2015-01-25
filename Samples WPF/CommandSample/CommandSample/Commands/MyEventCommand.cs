using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace CommandSample
{
    public class MyEventCommand : ICommand
    {
        public static readonly RoutedEvent ExecuteEvent = EventManager.RegisterRoutedEvent("Execute",
                                                                RoutingStrategy.Bubble,
                                                                typeof(RoutedEventHandler),
                                                                typeof(MyEventCommand));



        public static void AddExecuteHandler(DependencyObject o, RoutedEventHandler handler)
        {
            ((UIElement)o).AddHandler(MyEventCommand.ExecuteEvent, handler);
        }

        public static void RemoveExecuteHandler(DependencyObject o, RoutedEventHandler handler)
        {
            ((UIElement)o).RemoveHandler(MyEventCommand.ExecuteEvent, handler);
        }

        #region ICommand Member

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            RoutedEventArgs e = new RoutedEventArgs(ExecuteEvent, Keyboard.FocusedElement);
            Keyboard.FocusedElement.RaiseEvent(e);
        }

        #endregion
    }
}
