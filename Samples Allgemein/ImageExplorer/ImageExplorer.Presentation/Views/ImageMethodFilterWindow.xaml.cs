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
using ImageExplorer.Base;

namespace ImageExplorer.Presentation.Views
{
    /// <summary>
    /// Interaction logic for ImageMethodFilterWindow.xaml
    /// </summary>
    [Export(typeof(IImageMethodFilterView))]
    public partial class ImageMethodFilterWindow : UserControl, IImageMethodFilterView
    {
        public ImageMethodFilterWindow()
        {
            InitializeComponent();
        }
    }
}
