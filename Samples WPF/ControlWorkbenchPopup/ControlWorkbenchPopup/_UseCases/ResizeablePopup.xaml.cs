using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace ControlWorkbenchPopup._UseCases
{
    /// <summary>
    /// Interaction logic for ResizeablePopup.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class ResizeablePopup : Page, IUseCaseView
    {
        private const int MaxSize = 500;
        private const int MinSize = 50;

        private Popup _MyPopup;

        public ResizeablePopup()
        {
            InitializeComponent();
            
            _MyPopup = Resources["myPopup"] as Popup;

        }

        private void ShowPopup(object sender, RoutedEventArgs e)
        {
            _MyPopup.IsOpen = true;
        }

        private void ThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            Thumb t = sender as Thumb;

            if (t.Cursor == Cursors.SizeWE
              || t.Cursor == Cursors.SizeNWSE)
            {
                _MyPopup.Width = Math.Min(MaxSize,
                  Math.Max(_MyPopup.Width + e.HorizontalChange,
                  MinSize));
            }

            if (t.Cursor == Cursors.SizeNS
              || t.Cursor == Cursors.SizeNWSE)
            {
                _MyPopup.Height = Math.Min(MaxSize,
                  Math.Max(_MyPopup.Height + e.VerticalChange,
                  MinSize));
            }
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

        public object View
        {
            get { return this; }
        }
    }
}
