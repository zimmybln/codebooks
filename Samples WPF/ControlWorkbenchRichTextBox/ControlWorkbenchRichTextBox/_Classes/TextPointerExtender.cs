using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Diagnostics;
using System.Windows.Input;

namespace ControlWorkbenchRichTextBox
{
    public static class TextPointerExtender
    {
        /// <summary>
        /// Listet alle Inhaltedokumente ausgehend von einer Position aufwärts auf.
        /// </summary>
        public static void ListElementHierarchie(this TextPointer Item, TextWriter Writer)
        {
            object r = Item.Parent;

            while (r != null)
            {
                Writer.Write(String.Format("..{0} ", r.ToString()));

                r = r is TextElement ? ((TextElement)r).Parent : null;
            }

            Writer.WriteLine();
        }
    }
}
