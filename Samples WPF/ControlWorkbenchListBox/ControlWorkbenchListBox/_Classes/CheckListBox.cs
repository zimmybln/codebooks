using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace ControlWorkbenchListBox
{

    public class CheckedListItem : ListBoxItem 
    {
        public bool IsChecked { get; set; }
    }


    class CheckListBox : ListBox
    {

        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new CheckedListItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is CheckedListItem;
        }
    }
}
