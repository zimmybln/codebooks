using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace FlowDocumentEditor.Extensions
{
    [ContentProperty("Content")]
    public class Fragment : FrameworkElement
    {
        private static readonly DependencyProperty ContentProperty = 
            DependencyProperty.Register("Content", typeof(FrameworkContentElement), typeof(Fragment));

        public FrameworkContentElement Content
        {
            get
            {
                return (FrameworkContentElement)GetValue(ContentProperty);
            }
            set
            {
                SetValue(ContentProperty, value);
            }
        }
    }
}
