using System;
using System.Collections.Generic;
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

namespace ControlWorkbenchExpander
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            App myapp = (App) Application.Current;

            foreach (object objKey in myapp.Resources.Keys)
                cboStyles.Items.Add(new ComboBoxItem() { Content = objKey });

            foreach(ResourceDictionary dic in myapp.Resources.MergedDictionaries)
            {
                foreach (object objKey in dic.Keys)
                {
                    if (dic[objKey] is Style && ((Style)dic[objKey]).TargetType == typeof(Expander))
                    {
                        cboStyles.Items.Add(new ComboBoxItem() {Content = objKey});
                    }
                }
            }


        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboStyles.SelectedItem is ComboBoxItem)
            {
                ComboBoxItem cbi = cboStyles.SelectedItem as ComboBoxItem;

                if (cbi == null) return;

                string strStyleName = cbi.Content as string;
                
                System.Windows.Style s = this.TryFindResource(strStyleName) as Style;

                if (s != null)
                    expander1.Style = s;
                else
                {
                    
                }


            }


            
        }
    }
}
