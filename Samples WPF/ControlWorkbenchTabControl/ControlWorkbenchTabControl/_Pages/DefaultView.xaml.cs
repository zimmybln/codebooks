﻿using System;
using System.Collections.Generic;
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

namespace ControlWorkbenchTabControl
{
    /// <summary>
    /// Interaction logic for DefaultView.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class DefaultView : Page, IUseCaseView
    {
        public DefaultView()
        {
            InitializeComponent();
        }

        public object View
        {
            get { return this; }
        }
    }
}
