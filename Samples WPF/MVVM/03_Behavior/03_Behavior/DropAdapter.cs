using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace _03_Behavior
{

    // http://blogs.msdn.com/b/marcelolr/archive/2007/06/09/basics-of-data-bound-drag-drop-in-wpf.aspx
    // Drag & Drop How-to Topics: http://msdn.microsoft.com/de-de/library/ms746687.aspx
    public abstract class DropAdapter
    {
        private readonly DragEventHandler mv_dlgReceiveDragEnter;
        private readonly DragEventHandler mv_dlgReceiveDragOver;
        private readonly DragEventHandler mv_dlgReceiveDrop;
        private readonly DragEventHandler mv_dlgReceiveDragLeave;

        protected DropAdapter()
        {
            mv_dlgReceiveDragEnter = new DragEventHandler(ReceiveDragEnter);
            mv_dlgReceiveDragOver = new DragEventHandler(ReceiveDragOver);
            mv_dlgReceiveDrop = new DragEventHandler(ReceiveDrop);
            mv_dlgReceiveDragLeave = new DragEventHandler(ReceiveDragLeave);
        }

        internal DragEventHandler DragEnter
        {
            get { return mv_dlgReceiveDragEnter; }
        }

        internal DragEventHandler DragOver
        {
            get { return mv_dlgReceiveDragOver; }
        }

        internal DragEventHandler Drop
        {
            get { return mv_dlgReceiveDrop; }
        }

        internal DragEventHandler DragLeave
        {
            get { return mv_dlgReceiveDragLeave; }
        }

        private void ReceiveDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = GetAllowedDragEnterEffects(e.Data, e.AllowedEffects, e.KeyStates);
        }

        private void ReceiveDragOver(object sender, DragEventArgs e)
        {
            IInputElement implInput = null;
            Point ptDropPoint;

            if (sender is IInputElement)
                ptDropPoint = e.GetPosition((IInputElement)sender);
            else
            {
                ptDropPoint = new Point();
            }

            object objHitTestItem = null;

            if (sender is ListBox)
            {
                objHitTestItem = GetBoundItemFromPoint((ListBox)sender, ptDropPoint);
            }

            e.Effects = this.GetAllowedDragOverEffects(objHitTestItem, e.Data, e.AllowedEffects, e.KeyStates);
        }

        private void ReceiveDrop(object sender, DragEventArgs e)
        {
            IInputElement implInput = null;
            Point ptDropPoint;

            if (sender is IInputElement)
                ptDropPoint = e.GetPosition((IInputElement) sender);
            else
            {
                ptDropPoint = new Point();
            }

            object objHitTestItem = null;

            if (sender is ListBox)
            {
                objHitTestItem = GetBoundItemFromPoint((ListBox) sender, ptDropPoint);
            }

            this.OnDrop(objHitTestItem, e.Data);
        }

        private static object GetBoundItemFromPoint(ItemsControl ItemsControl, Point point)
        {

            var element = ItemsControl.InputHitTest(point) as UIElement;
            while (element != null)
            {
                if (element == ItemsControl)
                {
                    return null;
                }
                object item = ItemsControl.ItemContainerGenerator.ItemFromContainer(element);
                bool itemFound = !object.ReferenceEquals(item, DependencyProperty.UnsetValue);
                if (itemFound)
                {
                    return item;
                }
                else
                {
                    element = VisualTreeHelper.GetParent(element) as UIElement;
                }
            }
            return null;
        }

        private void ReceiveDragLeave(object sender, DragEventArgs e)
        {

        }

        protected virtual DragDropEffects GetAllowedDragEnterEffects(IDataObject DataObject, DragDropEffects AllowedEffects, DragDropKeyStates KeyStates)
        {
            return DragDropEffects.None;
        }

        protected virtual DragDropEffects GetAllowedDragOverEffects(object HitTestElement, IDataObject DataObject, DragDropEffects AllowedEffects, DragDropKeyStates KeyStates)
        {
            return DragDropEffects.None;
        }

        protected virtual void OnDrop(object HitTestElement, IDataObject DataObject)
        {

        }


    }
}
