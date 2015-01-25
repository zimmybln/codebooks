using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ControlsWorkbench
{
    
    public static class ListBoxExtensions
    {
        public static readonly DependencyProperty IsHighlightableProperty = DependencyProperty.RegisterAttached(
            "IsHighlightable",
            typeof(Boolean),
            typeof(ListBox), 
            new FrameworkPropertyMetadata(IsHighlightableChanged)
            );

        public static readonly DependencyProperty HighlightedStyleProperty = DependencyProperty.RegisterAttached(
            "HighlightedStyle",
            typeof (Style),
            typeof (ListBox), new FrameworkPropertyMetadata());

        public static readonly DependencyPropertyKey HighlightedItemProperty = DependencyProperty.RegisterAttachedReadOnly(
            "HighlightedItem",
            typeof (object),
            typeof (ListBox),
            new FrameworkPropertyMetadata());
        
        private static ListBoxItem msv_lbiLatestHighlightedItem;
        private static Style msv_stlLatestStyle;

        [AttachedPropertyBrowsableForTypeAttribute(typeof(ListBox))]
        public static Boolean GetIsHighlightable(UIElement element)
        {
            return (Boolean)element.GetValue(IsHighlightableProperty);
        }

        [AttachedPropertyBrowsableForTypeAttribute(typeof(ListBox))]
        public static void SetIsHighlightable(UIElement element, Boolean value)
        {
            element.SetValue(IsHighlightableProperty, value);
        }

        [AttachedPropertyBrowsableForTypeAttribute(typeof(ListBox))]
        public static Style GetHighlightedStyle(UIElement element)
        {
            return element.GetValue(HighlightedStyleProperty) as Style;            
        }

        [AttachedPropertyBrowsableForTypeAttribute(typeof(ListBox))]
        public static object GetHighlightedItem(UIElement element)
        {
            return msv_lbiLatestHighlightedItem; 
        }

        [AttachedPropertyBrowsableForTypeAttribute(typeof(ListBox))]
        public static void SetHighlightedStyle(UIElement element, Style value)
        {
            element.SetValue(HighlightedStyleProperty, value);
        }

        public static void IsHighlightableChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if ((bool)args.NewValue)
            {
                ListBox lstBox = (ListBox) obj;

                lstBox.PreviewMouseRightButtonDown += OnRightButtonDown;
                lstBox.PreviewMouseRightButtonUp += OnRightButtonUp;
            }
        }

        public static void OnRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox lstContainer = sender as ListBox;

            if (lstContainer == null) return;

            if (msv_lbiLatestHighlightedItem != null)
                msv_lbiLatestHighlightedItem.Style = msv_stlLatestStyle;

            msv_lbiLatestHighlightedItem = null;
            msv_stlLatestStyle = null;

                msv_lbiLatestHighlightedItem = (ListBoxItem)e.Source;

                msv_stlLatestStyle = msv_lbiLatestHighlightedItem.Style;        

                Style stlHighlighted = GetHighlightedStyle(lstContainer);

                if (stlHighlighted != null)
                {
                    Style s = new Style(typeof (ListBoxItem));

                    if (msv_lbiLatestHighlightedItem.Style != null)
                        MergeStyles(s, msv_lbiLatestHighlightedItem.Style);
                    
                    MergeStyles(s, stlHighlighted);

                    msv_lbiLatestHighlightedItem.Style = s;
                }
                
                ContextMenu xm = lstContainer.ContextMenu;

                if (xm != null)
                {
                    xm.Closed += ContextMenuClosed;
                    xm.IsOpen = true;
                }
            
            e.Handled = true;
        }

        static void ContextMenuClosed(object sender, RoutedEventArgs e)
        {
            ((ContextMenu)sender).Closed -= ContextMenuClosed;

            if (msv_lbiLatestHighlightedItem != null)
                msv_lbiLatestHighlightedItem.Style = msv_stlLatestStyle;
        }

        public static void OnRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (msv_lbiLatestHighlightedItem != null)
                msv_lbiLatestHighlightedItem.Style = msv_stlLatestStyle;
        }

        static void MergeStyles(Style style, Style mergeStyle)
        {
            // Recursively merge with any Styles this Style
            // might be BasedOn.
            if (mergeStyle.BasedOn != null)
                MergeStyles(style, mergeStyle.BasedOn);
            
            // Merge the Setters...
            foreach (var setter in mergeStyle.Setters)
                style.Setters.Add(setter);
    
            // Merge the Triggers...
            foreach (var trigger in mergeStyle.Triggers)
                style.Triggers.Add(trigger);
        }

    }
}
