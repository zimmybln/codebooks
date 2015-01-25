using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace _03_Behavior
{
    public static class DropBehavior
    {

        public static readonly DependencyProperty DropAdapterProperty =
            DependencyProperty.RegisterAttached("DropAdapter", typeof(DropAdapter), typeof(DropBehavior),
                                                new PropertyMetadata(null, PropertyChangedHandler));

        public static void SetDropAdapter(DependencyObject o, object value)
        {
            o.SetValue(DropAdapterProperty, value);
        }

        public static object GetDropAdapter(DependencyObject o)
        {
            return o.GetValue(DropAdapterProperty) as DropAdapter;
        }

        private static void PropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var element = sender as UIElement;
            if (element == null) { return; }

            if (e.OldValue != null)
            {
                var dropAdapter = (DropAdapter)e.OldValue;
                element.RemoveHandler(UIElement.DragEnterEvent, dropAdapter.DragEnter);
                element.RemoveHandler(UIElement.DragOverEvent, dropAdapter.DragOver);
                element.RemoveHandler(UIElement.DropEvent, dropAdapter.Drop);
            }

            if (e.NewValue != null)
            {
                var dropAdapter = (DropAdapter)e.NewValue;
                element.AddHandler(UIElement.DragEnterEvent, dropAdapter.DragEnter);
                element.AddHandler(UIElement.DragOverEvent, dropAdapter.DragOver);
                element.AddHandler(UIElement.DropEvent, dropAdapter.Drop);
            }
        }

    }
}
