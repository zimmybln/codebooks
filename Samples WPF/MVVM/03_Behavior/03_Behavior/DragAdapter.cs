using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace _03_Behavior
{
    /// <summary>
    /// Diese Klasse überführt das Event MouseMove
    /// in den Anfang eines Drag/Drop Vorganges
    /// </summary>
    public class DragAdapter
    {
        private readonly MouseEventHandler mv_dlgPreviewMouseMove;

        public DragAdapter()
        {
            mv_dlgPreviewMouseMove = new MouseEventHandler(OnMouseMove);
        }

        public MouseEventHandler MouseMoveEvent
        {
            get { return mv_dlgPreviewMouseMove; }
        }

        /// <summary>
        /// Eventhandler für das MouseMove Event
        /// </summary>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            // Wenn der Ursprung von Selector abgeleitet und 
            // der linke Mausbutton gedrückt worden ist
            if (sender is Selector && e.LeftButton == MouseButtonState.Pressed)
            {
                var lst = (Selector) sender;
                var objSelectedItem = lst.SelectedItem;

                var enmDragDropEffect = GetAllowedEffects(objSelectedItem);

                if (enmDragDropEffect != DragDropEffects.None)
                {
                    DragDropEffects enmEffect = DragDrop.DoDragDrop(sender as DependencyObject, objSelectedItem, enmDragDropEffect);

                    if (enmEffect != DragDropEffects.None)
                        Dragged(objSelectedItem, enmEffect);
                }
            }
        }

        /// <summary>
        /// Diese Methode erlaubt die Bestimmung der zulässigen DragDropEffects
        /// </summary>
        protected virtual DragDropEffects GetAllowedEffects(object SelectedItem)
        { 
            return DragDropEffects.None;
        }

        protected  virtual void Dragged(object DraggedItem, DragDropEffects ActionEffect)
        {
            
        }




    }
}
