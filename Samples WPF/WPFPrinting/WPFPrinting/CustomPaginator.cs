using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPFPrinting
{
    public class CustomPaginator : DocumentPaginator 
    {
        public CustomPaginator()
        {
            this.PageSize = new Size(600, 600);
        }


        public override DocumentPage GetPage(int pageNumber)
        {
            var panel = new StackPanel();

            var txt = new Label();
            txt.Margin = new Thickness(2);
            txt.Background = Brushes.Aqua;
            txt.Content = "Hallo, ich bin ein Label";
            
            panel.Children.Add(txt);
            panel.Measure(PageSize);
            panel.Arrange(new Rect(PageSize));
            
            return new DocumentPage(panel);
        }

        public override bool IsPageCountValid
        {
            get { return true; }
        }

        public override int PageCount
        {
            get { return 1; }
        }

        public override System.Windows.Size PageSize
        {
            get; set;
        }

        public override IDocumentPaginatorSource Source
        {
            get { return null; }
        }
    }
}
