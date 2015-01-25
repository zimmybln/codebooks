using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlsWorkbench.Pages
{
    /// <summary>
    /// Interaktionslogik für ListBoxPage.xaml
    /// </summary>
    public partial class ListBoxPage : Page
    {

        public ListBoxPage()
        {
            InitializeComponent();

            for (int i = 1000; i < 1100; i++)
            {
                ListBoxItem lb = new ListBoxItem();
                lb.Content = String.Format("Entry {0:00000}", i);                
                
                lstRightMouseSupport.Items.Add(lb);
            }
                
        }

    //    private void OnRightButtonDown(object sender, MouseButtonEventArgs e)
    //    {
    //        if (sender == lstRightMouseSupport)
    //        {
    //            if (mv_objSelectedItem != null)
    //                mv_objSelectedItem.Style = mv_stlPreviousItemStyle;
                
    //            if (e.Source != null)
    //            {
    //                string strMessage;
    //                mv_objSelectedItem = null;

    //                if (e.Source is ListBoxItem)
    //                {
    //                    strMessage = e.Source.ToString();

    //                    mv_objSelectedItem = (ListBoxItem) e.Source;

                        
    //                    System.Windows.Style s = new Style(typeof(ListBoxItem));

    //                    MergeWithStyle(s, mv_objSelectedItem.Style);
    //                    MergeWithStyle(s, (System.Windows.Style)FindResource("Highlighted"));

    //                    mv_stlPreviousItemStyle = mv_objSelectedItem.Style;
                        
    //                    mv_objSelectedItem.Style = s;
                        
    //                    // Statustext verschicken
    //                    GlobalCommands.SetStatusTextCommand.Execute(strMessage, null);

    //                    ContextMenu xm = lstRightMouseSupport.ContextMenu;
                        
    //                    if (xm != null)
    //                    {
    //                        xm.Closed += new RoutedEventHandler(xm_Closed);
    //                        xm.IsOpen = true;
    //                    }


    //                }
    //                else
    //                {
    //                    strMessage = "Die Liste selbst hat die Nachricht verschickt";
    //                }
    //                e.Handled = true;

    //            }
    //        }
    //    }

    //    void xm_Closed(object sender, RoutedEventArgs e)
    //    {
    //        ((ContextMenu)sender).Closed -= new RoutedEventHandler(xm_Closed);

    //        if (mv_objSelectedItem != null)
    //            mv_objSelectedItem.Style = mv_stlPreviousItemStyle;

    //    }

    //    private void OnRightButtonUp(object sender, MouseButtonEventArgs e)
    //    {
    //        if (mv_objSelectedItem != null)
    //        {
    //            mv_objSelectedItem.Style = mv_stlPreviousItemStyle;
    //            mv_objSelectedItem = null;
    //        }
    //    }

    //    private static void MergeWithStyle(Style style, Style mergeStyle)
    //    {
    //        // Recursively merge with any Styles this Style
    //        // might be BasedOn.
    //        if (mergeStyle.BasedOn != null)
    //            MergeWithStyle(style, mergeStyle.BasedOn);
            
    //        // Merge the Setters...
    //        foreach (var setter in mergeStyle.Setters)
    //            style.Setters.Add(setter);
    
    //        // Merge the Triggers...
    //        foreach (var trigger in mergeStyle.Triggers)
    //            style.Triggers.Add(trigger);
    //}

    
    }

    public class UserInfo
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
