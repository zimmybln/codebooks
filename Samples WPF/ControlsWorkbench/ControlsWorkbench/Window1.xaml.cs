using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Reflection;
using System.Windows.Markup;
using System.IO;

namespace ControlsWorkbench
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public static readonly DependencyProperty PageNameProperty = DependencyProperty.RegisterAttached(
            "PageName",
            typeof(String),
            typeof(ListBoxItem),
            new FrameworkPropertyMetadata()
        );


        Timer msv_tmrResetStatusBar;
        
        public Window1()
        {
            InitializeComponent();

            TimerCallback tmrCallback = new TimerCallback(this.OnTimer);

            msv_tmrResetStatusBar = new Timer(tmrCallback);

            msv_tmrResetStatusBar.Change(Timeout.Infinite, Timeout.Infinite);

            try
            {
                //Type t = typeof(FrameworkElement);

                //FieldInfo f = t.GetField("DefaultStyleKeyProperty", BindingFlags.Static | BindingFlags.NonPublic);

                //ToolBar tb = new ToolBar();

                

                //DependencyProperty dp = (DependencyProperty)f.GetValue(tb);

                //object o = tb.GetValue(dp);

                //if (o == null)
                //    MessageBox.Show("Die Resource konnte nicht geladen werden.");

                //Style s = (Style)Application.Current.FindResource(ToolBar.ButtonStyleKey);


                //string strXaml = XamlWriter.Save(s);

                //FileStream fs = new FileStream("D:\\test.xaml", FileMode.OpenOrCreate);

                //StreamWriter sw = new StreamWriter(fs);

                //sw.Write(strXaml);

                //sw.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            
        }


        public static String GetPageName(UIElement element)
        {
            return (String)element.GetValue(PageNameProperty);
        }

        public static void SetPageName(UIElement element, object value)
        {
            element.SetValue(PageNameProperty, value);
        }

        public string ActiveFrameName
        {
            get; set; 
        }


        private void OnTimer(object state)
        {
            if (this.Dispatcher.Thread != Thread.CurrentThread)
            {
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, (Action)delegate() { tbStatusInfo.Text = String.Empty;}); 
            }
            else
            {
                tbStatusInfo.Text = String.Empty;
            }
        }

        private void OnSetStatusText(object sender, ExecutedRoutedEventArgs e)
        {

            if (e.Parameter != null)
                tbStatusInfo.Text = e.Parameter.ToString();

            // Das Signal zum Zurücksetzen des Textes wird in 5 Sek. ausgelöst und nicht wiederholt.
            msv_tmrResetStatusBar.Change(5000, Timeout.Infinite);
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 1) return;

            string strPageName = Window1.GetPageName(e.AddedItems[0] as UIElement);

            if (!String.IsNullOrEmpty(strPageName))
                frmControls.Navigate(new Uri(String.Format("../Pages/{0}.xaml", strPageName), UriKind.RelativeOrAbsolute));
        }
    }
}
