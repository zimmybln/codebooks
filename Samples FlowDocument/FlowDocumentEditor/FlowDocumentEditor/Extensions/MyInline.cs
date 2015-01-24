using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace FlowDocumentEditor.Extensions
{
    public class MyInline : Run
    {
        public MyInline()
        {
            this.TextDecorations = System.Windows.TextDecorations.Strikethrough;
        }
    }
}
