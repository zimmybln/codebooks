using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ControlWorkbenchListView
{
    public class SimpleDataTemplateSelector : DataTemplateSelector 
    {
        public DataTemplate FirstTemplate { get; set; }
        public DataTemplate SecondTemplate { get; set; }

        private bool mv_fToggle = false;

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Debug.WriteLine(item.GetType().ToString());


            mv_fToggle = !mv_fToggle;

            if (mv_fToggle)
                return FirstTemplate;

            return SecondTemplate;
        }

    }
}
