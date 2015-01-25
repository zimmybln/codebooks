using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ImageExplorer.Presentation.Controls
{
    /// <summary>
    /// Interaction logic for Directory.xaml
    /// </summary>
    public partial class Directory : UserControl
    {
        public static readonly DependencyProperty PathProperty = DependencyProperty.Register(
                "Path", typeof(string), typeof(Directory), new FrameworkPropertyMetadata(String.Empty, FrameworkPropertyMetadataOptions.None, OnPathChanged));


        public Directory()
        {
            InitializeComponent();

            // Ausgangsinitialisierung
            foreach(var strDrive in System.IO.Directory.GetLogicalDrives())
            {
                var tviDrive = new TreeViewItem();
                tviDrive.Header = strDrive;
                tviDrive.Tag = strDrive;
                if (HasChildren(strDrive))
                    tviDrive.Items.Add(null);
                tviDrive.Expanded += new RoutedEventHandler(OnNodeExpanded);
                trvDirectories.Items.Add(tviDrive);
            }
        }

        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { this.SetValue(PathProperty, value); }
        }

        private static bool HasChildren(string Directory)
        {
            bool fHasChildren = false;

            try
            {
                string[] strSubDirectories = System.IO.Directory.GetDirectories(Directory);

                fHasChildren = strSubDirectories != null && strSubDirectories.Length > 0;
            }
            catch (Exception ex) 
            {
            }

            return fHasChildren;
        }

        private void OnNodeExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == null)
            {
                item.Items.Clear();
                try
                {
                    foreach (string s in System.IO.Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.Tag = s;
                        subitem.FontWeight = FontWeights.Normal;
                        if (HasChildren(s))
                            subitem.Items.Add(null);
                        subitem.Expanded += new RoutedEventHandler(OnNodeExpanded);
                        item.Items.Add(subitem);
                    }
                }
                catch (Exception) { }
            }

        }

        private static void OnPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctl = d as Directory;

            if (ctl == null) return;

            // Aufbereiten der Daten
            string strDirectory = e.NewValue as string;

            if (String.IsNullOrEmpty(strDirectory))
                return;

            TreeViewItem tviParent = null;
            ItemCollection tviItems;

            string[] strPathSegments = strDirectory.Split('\\');

            if (strPathSegments.Length == 0)
                return;

            // Initialisierung der Ausgangswerte
            tviItems = ctl.trvDirectories.Items;

            for(int i = 0; i < strPathSegments.Length; i++)
            {
                string strFind = strPathSegments[i];
                
                if (i == 0 && !strFind.EndsWith("\\"))
                    strFind = strFind + "\\";

                var tviFound = tviItems.OfType<TreeViewItem>().FirstOrDefault(x => (string)x.Header == strFind);

                if (tviFound != null)
                {
                    tviFound.IsExpanded = true;
                    tviParent = tviFound;
                    tviItems = tviParent.Items;
                }
            }

            if (tviParent != null)
            {
                tviParent.IsSelected = true;
                tviParent.Focus();
                tviParent.BringIntoView();
            }

        }

        private void OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue != null && e.NewValue is TreeViewItem)
            {
                this.Path = ((TreeViewItem) e.NewValue).Tag.ToString();
            }
        }

    }
}
