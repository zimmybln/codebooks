using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ControlWorkbenchListView
{
    public class PersonView : ViewBase 
    {
        protected override object DefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "PersonView"); }
        }

        protected override object ItemContainerDefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "PersonViewItem"); }
        }
    }
}
