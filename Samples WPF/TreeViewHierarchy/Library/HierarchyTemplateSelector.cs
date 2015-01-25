using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TreeViewHierarchy.Types;

namespace TreeViewHierarchy.Library
{
    class HierarchyTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Liefert die Instanz des DataTemplates in Abhängigkeit vom Typ.
        /// </summary>
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item is HierarchyBranchExtended)
                return ((FrameworkElement) container).FindResource("HierarchyBranchExtendedTemplate") as DataTemplate;
            
            return ((FrameworkElement) container).FindResource("HierarchyBranchTemplate") as DataTemplate;
        }
    }
}
