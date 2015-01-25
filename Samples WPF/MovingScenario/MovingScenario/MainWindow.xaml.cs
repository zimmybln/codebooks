using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovingScenario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NameScope.SetNameScope(this, new NameScope());
            RegisterName(border1.Name, border1);

            Storyboard sb = new Storyboard();

            DoubleAnimation da = new DoubleAnimation(border1.Width, border1.Width + 100, TimeSpan.FromMilliseconds(200));
            da.AutoReverse = true;
            da.SpeedRatio = 0.5;
            da.Completed += new EventHandler(OnCompleted);

            border1.BeginAnimation(FrameworkElement.WidthProperty, da);
            
            //Storyboard.SetTargetName(da, border1.Name);
            //Storyboard.SetTargetProperty(da, new PropertyPath(FrameworkElement.WidthProperty));

            //sb.Children.Add(da);

            //// sb.Begin(this);
            //sb.BeginAnimation(FrameworkElement.WidthProperty, da);
            
        }

        void OnCompleted(object sender, EventArgs e)
        {
            Trace.WriteLine("Completed");
        }
    }
}
