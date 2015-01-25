using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using Pen = System.Windows.Media.Pen;
using Point = System.Windows.Point;

namespace AttachedAdorner
{
    public static class AttachedAdornerBehavior 
    {
        public static readonly DependencyProperty ReorderProperty =
            DependencyProperty.RegisterAttached("Reorder", typeof(ReorderAdapter), typeof (AttachedAdornerBehavior), 
            new PropertyMetadata(null, OnPropertyChanged));


        static AttachedAdornerBehavior()
        {
            
        }

        public static void SetReorder(UIElement element, ReorderAdapter Resizer)
        {
            element.SetValue(ReorderProperty, Resizer);
        }

        public static ReorderAdapter GetReorder(UIElement element)
        {
            return (ReorderAdapter) element.GetValue(ReorderProperty);
        }

        public static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var element = sender as UIElement;

            if (element == null) return;

            if (e.OldValue != null)
            {
                var oldValue = e.OldValue as ReorderAdapter;
                element.RemoveHandler(UIElement.PreviewMouseDownEvent, new MouseButtonEventHandler(oldValue.OnPreviewMouseDown));
                element.RemoveHandler(UIElement.PreviewMouseMoveEvent, new MouseEventHandler(oldValue.OnPreviewMouseMove));
            }

            if (e.NewValue != null)
            {
                var newValue = e.NewValue as ReorderAdapter;
                element.AddHandler(UIElement.PreviewMouseDownEvent, new MouseButtonEventHandler(newValue.OnPreviewMouseDown));
                element.AddHandler(UIElement.PreviewMouseMoveEvent, new MouseEventHandler(newValue.OnPreviewMouseMove));
            }
        }
    }

    public class ReorderAdapter
    {
        private Point mv_ptStartPoint;
        private bool mv_fIsReordering;

        public ReorderAdapter()
        {
            this.ReOrderColor = Colors.IndianRed;
            this.ReOrderWidth = 2d;
        }

        #region Eigenschaften

        public Color ReOrderColor { get; set; }

        public double ReOrderWidth { get; set; }

        #endregion

        internal void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mv_ptStartPoint = e.GetPosition(null);
        }

        internal void OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed ||
                e.RightButton == MouseButtonState.Pressed && !mv_fIsReordering)
            {
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - mv_ptStartPoint.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(position.Y - mv_ptStartPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    var element = sender as UIElement;
                    
                    AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(element);
                    if (adornerLayer != null)
                    {
                        Point? pt = e.GetPosition(element);

                        var adorner = new ReorderAdorner(element, ReOrderColor, ReOrderWidth, pt);
                        adornerLayer.Add(adorner);
                    }
                }
            }
        }
    }

    public class ReorderAdorner : Adorner
    {
        private Point? mv_ptCurrentPoint;
        private Pen mv_pen;
        private System.Windows.Media.Brush mv_brush;
        private bool mv_fIsAllowed = false;
        private TreeViewItem mv_objCurrentTreeViewItem = null;
        private TreeViewItem mv_tiItemToDrag = null;

        public ReorderAdorner(UIElement AdornedElement, Color ReOrderColor, double ReOrderWidth, Point? StartPoint) : base(AdornedElement)
        {
            mv_ptCurrentPoint = StartPoint;

            mv_brush = new SolidColorBrush(ReOrderColor);
            mv_pen = new Pen(mv_brush, ReOrderWidth);

            // Ermittle den Knoten, der verschoben werden soll
            if (AdornedElement is TreeView && mv_ptCurrentPoint.HasValue)
            {
                var trv = AdornedElement as TreeView;
                var pt = trv.TranslatePoint(mv_ptCurrentPoint.Value, trv);
                var item = trv.InputHitTest(pt) as FrameworkElement;
                
                while (!(item is TreeViewItem) && item != null)
                    item = VisualTreeHelper.GetParent(item) as FrameworkElement;

                mv_tiItemToDrag = item as TreeViewItem;
            }
        }

        protected override void OnMouseUp(System.Windows.Input.MouseButtonEventArgs e)
        {
            // release mouse capture
            if (this.IsMouseCaptured) this.ReleaseMouseCapture();

            // remove this adorner from adorner layer
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(AdornedElement);
            if (adornerLayer != null)
                adornerLayer.Remove(this);

            if (mv_tiItemToDrag == null || mv_fIsAllowed == false)
                Debug.WriteLine("Es wird nichts verschoben");
            else
            {
                if (mv_tiItemToDrag.Parent != null)
                {
                    if (mv_tiItemToDrag.Parent is TreeViewItem)
                    {
                        var prnt = mv_tiItemToDrag.Parent as TreeViewItem;
                        prnt.Items.Remove(mv_tiItemToDrag);
                    }
                    else if (mv_tiItemToDrag.Parent is TreeView)
                    {
                        var prnt = mv_tiItemToDrag.Parent as TreeView;
                        prnt.Items.Remove(mv_tiItemToDrag);
                    }
                }

                mv_objCurrentTreeViewItem.Items.Add(mv_tiItemToDrag);
                mv_objCurrentTreeViewItem.IsExpanded = true;

                // Debug.WriteLine(String.Format("'{0}' wird dem Element '{1}' untergeordnet.", mv_tiItemToDrag.Header, mv_objCurrentTreeViewItem.Header));
            }

            e.Handled = true;
        }

        protected override void OnMouseMove(System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!this.IsMouseCaptured)
                    this.CaptureMouse();

                mv_ptCurrentPoint = e.GetPosition(this);


                // Knoten unter dem Mauszeiger ermitteln
                var trv = AdornedElement as TreeView;
                if (trv != null)
                {
                    var pt = trv.TranslatePoint(mv_ptCurrentPoint.Value, trv);
                    var item = trv.InputHitTest(pt) as FrameworkElement;

                    while (!(item is TreeViewItem) && item != null)
                        item = VisualTreeHelper.GetParent(item) as FrameworkElement;
                    
                    if (item is TreeViewItem)
                    {
                        var it = item as TreeViewItem;

                        mv_objCurrentTreeViewItem = it;

                        // Hier kann die Beziehung zum Ausgangsobjekt bestimmt werden.

                    //    Rect r = GetBoundingBox(it, trv);
                        
                    //    Debug.WriteLine(String.Format("Element gefunden: {0} (X: {1}, Y: {2}, Width: {3}, Height: {4}), {5}", ((TreeViewItem)item).Header, r.Left, r.Top, it.ActualWidth, it.ActualHeight, it.RenderSize.Width));
                        mv_fIsAllowed = IsMovingAllowed(mv_objCurrentTreeViewItem);
                    }
                    else
                    {
                        mv_fIsAllowed = false;
                        mv_objCurrentTreeViewItem = null;
                    }

                    
                }

                this.InvalidateVisual();
            }
            else
            {
                if (this.IsMouseCaptured) this.ReleaseMouseCapture();
            }

            e.Handled = true;
        }

        private Rect GetBoundingBox(FrameworkElement element, FrameworkElement containerWindow)
        {
            GeneralTransform transform = element.TransformToAncestor(containerWindow);
            Point topLeft = transform.Transform(new Point(0, 0));
            Point bottomRight = transform.Transform(new Point(element.ActualWidth, element.ActualHeight));
            return new Rect(topLeft, bottomRight);
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(RenderSize));

            if (mv_ptCurrentPoint.HasValue)
            {
                Rect itemRect = VisualTreeHelper.GetDescendantBounds(AdornedElement);

                if (mv_objCurrentTreeViewItem != null)
                {
                    Rect r = GetBoundingBox(mv_objCurrentTreeViewItem, AdornedElement as TreeView);
                    
                    Point start = new Point(r.Left, r.Top + mv_objCurrentTreeViewItem.ActualHeight - 5);
                    LineSegment[] segments = new LineSegment[]
                                                 {
                                                     new LineSegment(new Point(r.Left, r.Top + mv_objCurrentTreeViewItem.ActualHeight + 5), true), 
                                                     new LineSegment(new Point(r.Left + 5, r.Top + mv_objCurrentTreeViewItem.ActualHeight), true)
                                                 };
                    PathFigure figure = new PathFigure(start, segments, true);

                    PathGeometry geo = new PathGeometry(new PathFigure[] { figure });

                    System.Windows.Media.Brush br = mv_fIsAllowed ? Brushes.Transparent : Brushes.Red;
                    drawingContext.DrawEllipse(br, mv_pen, new Point(r.Left + 1.5, r.Top + mv_objCurrentTreeViewItem.ActualHeight), 8, 8);
                    drawingContext.DrawGeometry(mv_brush, null, geo);

                }

                //drawingContext.DrawLine(mv_pen, new Point(mv_ptStartPoint.Value.X, 0),
                //                        new Point(mv_ptStartPoint.Value.X, itemRect.Height));
                //drawingContext.DrawLine(mv_pen, new Point(0, mv_ptStartPoint.Value.Y),
                //                        new Point(itemRect.Width, mv_ptStartPoint.Value.Y));
            }
        }

        /// <summary>
        /// Ermittelt, ob das zu verschiebene Element dem aktuellen Element untergeordnet 
        /// werden kann.
        /// </summary>
        private bool IsMovingAllowed(TreeViewItem Item)
        {
            // Gültigkeitsüberprüfungen
            if (Item == null)
                return false;

            // Es werden die Bedingungen gesucht, die ein Verschieben verhindern
            if (mv_tiItemToDrag == Item)
                return false;

            if (Item == mv_tiItemToDrag.Parent)
                return false;
            
            // TODO: Das zu verschiebene Element ist dem aktuellen untergeordnet

            TreeViewItem objParent = Item.Parent as TreeViewItem;

            while(objParent != null)
            {
                if (objParent == mv_tiItemToDrag)
                    return false;

                objParent = objParent.Parent as TreeViewItem;
            }

            
            return true;
        }

    }


}
