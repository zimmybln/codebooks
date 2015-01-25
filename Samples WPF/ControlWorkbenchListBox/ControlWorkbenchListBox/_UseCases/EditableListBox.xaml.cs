using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
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

namespace ControlWorkbenchListBox._UseCases
{
    /// <summary>
    /// Interaktionslogik für EditableListBox.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class EditableListBox : Page, IUseCaseView
    {
        public EditableListBox()
        {
            InitializeComponent();

           


            //var c1 = new ContentItem("Eins, 2");
            //((INotifyPropertyChanged) c1).PropertyChanged += OnNotifyPropertyChanged;

            //var c2 = new ContentItem("Zwei");
            //((INotifyPropertyChanged)c2).PropertyChanged += OnNotifyPropertyChanged;

            //var c3 = new ContentItem("Drei");
            //((INotifyPropertyChanged)c3).PropertyChanged += OnNotifyPropertyChanged;

            //lbItems.AddItem("Eins");
            //lbItems.AddItem("Zwei");
            //lbItems.AddItem("Drei");
        }




        public object View
        {
            get { return this; }
        }
    }


}
