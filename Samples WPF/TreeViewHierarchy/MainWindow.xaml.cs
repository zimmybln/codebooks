using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using TreeViewHierarchy.Types;

namespace TreeViewHierarchy
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HierarchyBranch _selecteditem;

        public MainWindow()
        {
            InitializeComponent();

            // Ausgangshierarchie aufbauen
            var r = new HierarchyRoot() { Name = "Basisknoten" };

            var r1 = new HierarchyBranch() {Name = "Erster Unterknoten"};
            var r2 = new HierarchyBranchExtended() {Name = "1.1", SomeMoreProperty = "Eine zusätzliche Eigenschaft"};
            r1.Branches.Add(r2);

            r.Branches.Add(r1);

            _selecteditem = r2;

            trvHierarchy.ItemsSource = new List<HierarchyRoot>(new HierarchyRoot[] {r});
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SetSelected(trvHierarchy, _selecteditem, 1);
        }

        private bool SetSelected(ItemsControl parent, object child, int Level)
        {
            if (parent == null || child == null)
                return false;

            Debug.WriteLine(String.Format("{0}. Parent: {1}", Level, parent.GetType().ToString()));

            foreach (object childItem in parent.Items)
            {
                Debug.WriteLine(String.Format("\t{0}. Child: {1}", Level, childItem.GetType().ToString()));
                
                if (childItem.Equals(child))
                {
                    if (parent.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
                    {
                        parent.ItemContainerGenerator.StatusChanged += delegate(object Sender, EventArgs Args)
                        {
                            var c = parent.ItemContainerGenerator.ContainerFromItem(childItem) as ItemsControl;

                            var container = c as TreeViewItem;

                            if (container != null)
                            {
                                container.IsExpanded = true;
                                container.IsSelected = true;
                                container.BringIntoView();
                            }

                        };
                    }
                    else
                    {
                        var c = parent.ItemContainerGenerator.ContainerFromItem(childItem) as ItemsControl;
                        
                        var container = c as TreeViewItem;

                        if (container != null)
                        {
                            container.IsExpanded = true;
                            container.IsSelected = true;
                            container.BringIntoView();
                        }
                    }

                    return true;
                }

                var childControl = parent.ItemContainerGenerator.ContainerFromItem(childItem) as ItemsControl;

                if (childControl == null)
                {
                    Debug.WriteLine(String.Format("\t{0}. hat keine untergeordneten Elemente, Status: {1}", Level, parent.ItemContainerGenerator.Status));
                    // Debugger.Break();

                    (parent as TreeViewItem).IsExpanded = true;
                    childControl = parent.ItemContainerGenerator.ContainerFromItem(childItem) as ItemsControl;
                }

                if (SetSelected(childControl, child, Level + 1))
                {
                    if (parent is TreeViewItem)
                        ((TreeViewItem)parent).IsExpanded = true;

                    return true;
                }
            }

            return false;


            //var container = parent.ItemContainerGenerator.ContainerFromItem(child);

            //var childNode = container as TreeViewItem;

            //if (childNode != null)
            //{
            //    childNode.Focus();
            //    childNode.IsExpanded = true;
            //    childNode.IsSelected = true;
            //    childNode.BringIntoView();
            //    return true;
            //}

            //if (parent.Items.Count > 0)
            //{
            //    foreach (object childItem in parent.Items)
            //    {
            //        var childControl = parent.ItemContainerGenerator.ContainerFromItem(childItem) as ItemsControl;

            //        if (SetSelected(childControl, child)) 
            //            return true;
            //    }
            //}

            //return false;
        }


    }
}
