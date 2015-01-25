using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ControlWorkbenchRichTextBox
{
    public static class RichTextBoxExtender
    {

        /// <summary>
        /// Ermittelt das Textelement eines bestimmten Typs ausgehend von der aktuellen Cursorposition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="TextBox"></param>
        /// <returns></returns>
        public static T GetNearestFromCaret<T>(this RichTextBox TextBox) where T : TextElement
        {
            Type type = typeof (T);

            if (TextBox.CaretPosition == null)
                return null;

            object r = TextBox.CaretPosition.Parent;

            while (r != null)
            {
                if (r.GetType() == type)
                    break;

                r = r is TextElement ? ((TextElement) r).Parent : null;
            }

            return r as T;
        }

    }
}
