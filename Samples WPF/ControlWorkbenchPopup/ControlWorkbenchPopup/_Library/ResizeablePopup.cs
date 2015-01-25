using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlWorkbenchPopup
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ControlWorkbenchPopup._Library"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ControlWorkbenchPopup._Library;assembly=ControlWorkbenchPopup._Library"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ResizeablePopup/>
    ///
    /// </summary>
    public class ResizeablePopup : Control
    {
        static ResizeablePopup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResizeablePopup), new FrameworkPropertyMetadata(typeof(ResizeablePopup)));
        }

        private void ThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            //Thumb t = sender as Thumb;

            //if (t.Cursor == Cursors.SizeWE
            //  || t.Cursor == Cursors.SizeNWSE)
            //{
            //    _MyPopup.Width = Math.Min(MaxSize,
            //      Math.Max(_MyPopup.Width + e.HorizontalChange,
            //      MinSize));
            //}

            //if (t.Cursor == Cursors.SizeNS
            //  || t.Cursor == Cursors.SizeNWSE)
            //{
            //    _MyPopup.Height = Math.Min(MaxSize,
            //      Math.Max(_MyPopup.Height + e.VerticalChange,
            //      MinSize));
            //}
        }

        private void ThumbDragStarted(object sender,
          DragStartedEventArgs e)
        {
            //This is called when the user
            //starts dragging the thumb
        }

        private void ThumbDragCompleted(object sender,
          DragCompletedEventArgs e)
        {
            //This is called when the user
            //finishes dragging the thumb
        }
    }
}
