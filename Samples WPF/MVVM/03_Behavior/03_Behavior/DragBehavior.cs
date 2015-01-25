using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace _03_Behavior
{
    /// <summary>
    /// Hier wird eine Abhängigkeitseigenschaft zur Verfügung gestellt, die das Anbinden
    /// von angepassten Drag & Drop Verhalten erlaubt.
    /// </summary>
    public class DragBehavior
    {
        public static readonly DependencyProperty DragAdapterProperty =
             DependencyProperty.RegisterAttached("DragAdapter", typeof(DragAdapter), typeof(DragBehavior),
                                                new PropertyMetadata(null, PropertyChangedHandler));

        public static void SetDragAdapter(DependencyObject o, object value)
        {
            o.SetValue(DragAdapterProperty, value);
        }

        public static object GetDragAdapter(DependencyObject o)
        {
            return o.GetValue(DragAdapterProperty) as DragAdapter;
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn sich der Eigenschaftswert ändert. Dabei wird
        /// die Verbindung zwischen dem Ereignis Mousemove des Controls und dem Adapter
        /// hergestellt.
        /// </summary>
        private static void PropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element == null) { return; }

            if (e.OldValue != null)
            {
                DragAdapter dragAdapter = (DragAdapter)e.OldValue;
                element.RemoveHandler(UIElement.MouseMoveEvent, dragAdapter.MouseMoveEvent);
            }

            if (e.NewValue != null)
            {
                var dragAdapter = (DragAdapter)e.NewValue;
                element.AddHandler(UIElement.MouseMoveEvent, dragAdapter.MouseMoveEvent);
            }
        }

     }
}
