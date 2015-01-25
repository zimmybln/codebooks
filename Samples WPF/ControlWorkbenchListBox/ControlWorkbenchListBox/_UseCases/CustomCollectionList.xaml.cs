using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace ControlWorkbenchListBox
{
    // http://stackoverflow.com/questions/1232610/wpf-icollectionview-refresh

    /// <summary>
    /// Interaction logic for GroupedList.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class CustomCollection : Page, IUseCaseView
    {
        private readonly DecadeGroupDescription mv_objDecadeGroupView;
        private readonly FirstLetterDescription mv_objFirstLetterGroupView;

        public CustomCollection()
        {
            InitializeComponent();

            mv_objDecadeGroupView = new DecadeGroupDescription();
            mv_objFirstLetterGroupView = new FirstLetterDescription();

            ICollectionView colView = CollectionViewSource.GetDefaultView(Person.CommonPersons);

            colView.GroupDescriptions.Add(mv_objDecadeGroupView);
            colView.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
            colView.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));

            lsbWithGrouping.ItemsSource = colView;
        }

        public object View
        {
            get { return this; }
        }

        private void OnApplyGrouping(object sender, RoutedEventArgs e)
        {
            cmdShowPopup.IsChecked = false;

            if (rbGroupByAge.IsChecked == true)
            {
                ICollectionView colView = lsbWithGrouping.ItemsSource as ICollectionView;

                if (colView == null) return;

                if (!colView.GroupDescriptions.Contains(mv_objDecadeGroupView))
                {
                    using (colView.DeferRefresh())
                    {
                        colView.GroupDescriptions.Clear();
                        colView.SortDescriptions.Clear();
                        colView.GroupDescriptions.Add(mv_objDecadeGroupView);
                        colView.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
                        colView.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));
                    }
                }
            }
            else if (rbGroupByFirstLetter.IsChecked == true)
            {
                ICollectionView colView = lsbWithGrouping.ItemsSource as ICollectionView;

                if (colView == null) return;

                if (!colView.GroupDescriptions.Contains(mv_objFirstLetterGroupView))
                {
                    using (colView.DeferRefresh())
                    {
                        colView.GroupDescriptions.Clear();
                        colView.SortDescriptions.Clear();
                        colView.GroupDescriptions.Add(mv_objFirstLetterGroupView);
                        colView.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));
                    }
                }
            }
            else
            {
                ICollectionView colView = lsbWithGrouping.ItemsSource as ICollectionView;

                if (colView == null) return;

                using (colView.DeferRefresh())
                {

                    if (colView.GroupDescriptions.Count > 0)
                        colView.GroupDescriptions.Clear();

                    colView.SortDescriptions.Clear();
                    colView.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));
                }
            }
        }

        private void OnPopupOpened(object sender, EventArgs e)
        {
            ICollectionView colView = lsbWithGrouping.ItemsSource as ICollectionView;

            if (colView == null) return;

            if (colView.GroupDescriptions.Contains(mv_objFirstLetterGroupView))
                rbGroupByFirstLetter.IsChecked = true;
            else if (colView.GroupDescriptions.Contains(mv_objDecadeGroupView))
                rbGroupByAge.IsChecked = true;
            else
                rbGroupNone.IsChecked = true;
        }

        private void OnFilterKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string strFilterText = (sender as TextBox).Text;

                ICollectionView colView = lsbWithGrouping.ItemsSource as ICollectionView;

                if (colView == null)
                    return;

                if (String.IsNullOrWhiteSpace(strFilterText))
                    colView.Filter = null;
                else
                    using (colView.DeferRefresh())
                    {
                        colView.Filter = delegate(object o)
                                             {
                                                 if (String.IsNullOrWhiteSpace(strFilterText))
                                                     return true;

                                                 Person p = o as Person;

                                                 if (p == null)
                                                     return true;

                                                 return
                                                     p.FirstName.IndexOf(strFilterText, 0,
                                                                         StringComparison.InvariantCulture) >
                                                     -1;
                                             };
                    }
            }
        }
    }
}
