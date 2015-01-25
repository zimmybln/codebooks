using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
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

namespace ControlWorkbenchListView._Pages
{
    /// <summary>
    /// Interaktionslogik für CustomStateView.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class CustomStateView : Page, IUseCaseView, INotifyPropertyChanged 
    {
        public CustomStateView()
        {
            InitializeComponent();

            LocalData = new ObservableCollection<SampleData>();

            LocalData.Add(new SampleData() {Name = "Eins", Description = "Beschreibung für eins"});
            LocalData.Add(new SampleData() { Name = "Zwei", Description = "Beschreibung für zwei" });
            LocalData.Add(new SampleData() { Name = "Drei", Description = "Beschreibung für drei" });
            LocalData.Add(new SampleData() { Name = "Vier", Description = "Beschreibung für vier" });

            this.DataContext = this;
        }

        public ObservableCollection<SampleData> LocalData { get; private set; }
        
        public object View
        {
            get { return this; }
        }

        public string Description { get { return "Demonstriert die Darstellung eines Objektes."; } }

        private void RaisePropertyChanged(string PropertyName)
        {
            var p = this.PropertyChanged;

            if (p != null)
                p(this, new PropertyChangedEventArgs(PropertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           // ((SampleData)lvItems.SelectedItem).IsTest = !((SampleData)lvItems.SelectedItem).IsTest;

            //lvItems.InvalidateVisual();
            //lvItems.UpdateLayout();
            
        }
    }

    public class SampleData : INotifyPropertyChanged
    {
        private bool mv_fIsTest = false;

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsTest
        {
            get { return mv_fIsTest; }
            set
            {
                if (mv_fIsTest == value)
                    return;

                mv_fIsTest = value;

                RaisePropertyChanged("IsTest");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string PropertyName)
        {
            var p = PropertyChanged;

            if (p != null)
                p(this, new PropertyChangedEventArgs(PropertyName));
        }
    }

    public class PlainView : ViewBase
    {

        public static readonly DependencyProperty
          ItemContainerStyleProperty =
          ItemsControl.ItemContainerStyleProperty.AddOwner(typeof(PlainView));

        public Style ItemContainerStyle
        {
            get { return (Style)GetValue(ItemContainerStyleProperty); }
            set { SetValue(ItemContainerStyleProperty, value); }
        }

        public static readonly DependencyProperty ItemTemplateProperty =
            ItemsControl.ItemTemplateProperty.AddOwner(typeof(PlainView));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly DependencyProperty ItemWidthProperty =
            WrapPanel.ItemWidthProperty.AddOwner(typeof(PlainView));

        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }


        public static readonly DependencyProperty ItemHeightProperty =
            WrapPanel.ItemHeightProperty.AddOwner(typeof(PlainView));

        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }


        protected override object DefaultStyleKey
        {
            get
            {
                return new ComponentResourceKey(GetType(), "myPlainViewDSK");
            }
        }

    }
}
