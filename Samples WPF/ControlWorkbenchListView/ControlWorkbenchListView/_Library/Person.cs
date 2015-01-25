using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ControlWorkbenchListView
{
    public class Person : DependencyObject 
    {
        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register("FirstName", typeof (string), typeof (Person), new UIPropertyMetadata(null));

        public static readonly DependencyProperty CityProperty =
            DependencyProperty.Register("City", typeof (string), typeof (Person), new UIPropertyMetadata(null));

        public static readonly DependencyProperty PortraitNameProperty =
            DependencyProperty.Register("PortraitName", typeof(string), typeof(Person), new UIPropertyMetadata(null));

        public static readonly DependencyProperty GroupProperty =
            DependencyProperty.Register("Group", typeof (int), typeof (Person), new UIPropertyMetadata(0));


        public string FirstName
        {
            get { return GetValue(FirstNameProperty) as string; }
            set { SetValue(FirstNameProperty, value);}
        }

        public string City
        {
            get { return GetValue(CityProperty) as string; }
            set { SetValue(CityProperty, value);}
        }

        public string PortraitName
        {
            get { return GetValue(PortraitNameProperty) as string;  }
            set { SetValue(PortraitNameProperty, value); }
        }

        public int Group
        {
            get { return (int)GetValue(GroupProperty); }
            set { SetValue(GroupProperty, value); }
        }
    }
}
