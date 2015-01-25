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
using System.Windows.Shapes;

namespace ControlWorkbenchRichTextBox
{
    /// <summary>
    /// Interaction logic for HyperlinkDialog.xaml
    /// </summary>
    public partial class HyperlinkDialog : Window
    {

        private string mv_strHyperlinkTarget;
        private string mv_strHyperlinkText;
        
        public HyperlinkDialog()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(OnDialogLoaded);
        }

        void OnDialogLoaded(object sender, RoutedEventArgs e)
        {
            txtHyperlinkText.Text = mv_strHyperlinkText;
            txtHyperlinkTarget.Text = mv_strHyperlinkTarget;
        }

        #region Eigenschaften


        public string HyperlinkTarget
        {
            get { return mv_strHyperlinkTarget; }
            set { mv_strHyperlinkTarget = value; }
        }

        public string HyperlinkText
        {
            get { return mv_strHyperlinkText; }
            set { mv_strHyperlinkText = value; }
        }
        
        #endregion
        
        private void OnDialogResult(object sender, RoutedEventArgs e)
        {
            if (sender == cmdOK)
            {

                mv_strHyperlinkTarget = txtHyperlinkTarget.Text;
                mv_strHyperlinkText = txtHyperlinkText.Text;

                DialogResult = true;
            }
            else if (sender == cmdCancel)
            {
                DialogResult = false;
            }
        }
    }
}
