using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ControlWorkbenchListBox._Library
{
    /// <summary>
    /// Interaktionslogik für EditableListBox.xaml
    /// </summary>
    public partial class EditableListBox : UserControl
    {
        public static DependencyProperty IsEditableProperty = DependencyProperty.Register("IsEditable", typeof (bool),
                                                                                            typeof (EditableListBox),
                                                                                            new PropertyMetadata(false));

        public EditableListBox()
        {
            InitializeComponent();
        }

        public bool IsEditable
        {
            get { return (bool) GetValue(IsEditableProperty); }
            set { SetValue(IsEditableProperty, value); }
        }
        
        public void AddItem(string Value)
        {
            var c1 = new ContentItem(Value);
            ((INotifyPropertyChanged) c1).PropertyChanged += OnNotifyPropertyChanged;

            lbItems.Items.Add(c1);
        }

        private void OnNotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var c = sender as ContentItem;

            if (c == null) return;

            Debug.WriteLine(String.Format("Die Eigenschaft hat sich geändert: {0}", c.Value));
        }

        private void OnEditorPreviewKeyDown(object Sender, KeyEventArgs Args)
        {
            if (Args.Key == Key.Enter)
            {
                Debug.WriteLine("Es wurde <Enter> gedrückt.");
                Args.Handled = true;
            }
        }

        private void OnContentKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                IsEditable = true;
                e.Handled = true;
            }
        }
    }

    public class ContentItem : INotifyPropertyChanged
    {
        private string mv_strContentValue;

        public ContentItem(string ContentValue)
        {
            this.Value = ContentValue;
        }

        public bool IsNew { get; set; }

        public string Value
        {
            get { return mv_strContentValue; }
            set
            {
                if (String.Compare(mv_strContentValue, value) == 0)
                    return;

                mv_strContentValue = value;
                RaisePropertyChanged("Value");
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
}
