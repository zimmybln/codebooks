using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace ControlWorkbenchRichTextBox
{
    public static class TextSelectionExtender
    {
        /// <summary>
        /// Wechselt die Textformatierung Fett des ausgewählten Textes.
        /// </summary>
        public static void ToggleBold(this TextSelection Selection)
        {
            if (String.IsNullOrEmpty(Selection.Text))
                return;

            FontWeight fwValue = FontWeights.Bold;

            object objPropertyValue = Selection.GetPropertyValue(TextElement.FontWeightProperty);

            if (objPropertyValue == DependencyProperty.UnsetValue)
                fwValue = FontWeights.Bold;
            else if (objPropertyValue is FontWeight)
            {
                var fwTemp = (FontWeight)objPropertyValue;

                fwValue = fwTemp == FontWeights.Bold ? FontWeights.Normal : FontWeights.Bold;
            }

            Selection.ApplyPropertyValue(TextElement.FontWeightProperty, fwValue);
        }

        public static void ToggleItalic(this TextSelection Selection)
        {
            bool? fIsItalic = Selection.IsItalic();

            Selection.ApplyPropertyValue(TextElement.FontStyleProperty, fIsItalic == true ? FontStyles.Normal : FontStyles.Italic);
        }

        public static void ToggleUnderline(this TextSelection Selection)
        {
            TextDecorationCollection colTextDecoration = null;   

            object objValue = Selection.GetPropertyValue(Inline.TextDecorationsProperty);

            if (objValue != DependencyProperty.UnsetValue)
                colTextDecoration = (TextDecorationCollection) objValue;
            else
                colTextDecoration = new TextDecorationCollection();

            if (colTextDecoration.Contains(TextDecorations.Underline[0]))
                colTextDecoration.Remove(TextDecorations.Underline[0]);
            else
                colTextDecoration.Add(TextDecorations.Underline[0]);

            Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, colTextDecoration);
        }

        /// <summary>
        /// Ermittelt, ob es sich bei der Auswahl um Textformatierung Fett handelt.
        /// </summary>
        /// <param name="Selection"></param>
        /// <returns></returns>
        public static bool? IsBold(this TextSelection Selection)
        {
            bool? fIsBold = null;

            object objPropertyValue = Selection.GetPropertyValue(TextElement.FontWeightProperty);

            if (objPropertyValue != DependencyProperty.UnsetValue && objPropertyValue is FontWeight)
                fIsBold = (FontWeight) objPropertyValue == FontWeights.Bold ? true : false;
            
            return fIsBold;
        }

        /// <summary>
        /// Ermittelt, ob es sich bei der Auswahl um Textformatierung Kursiv handelt.
        /// </summary>
        public static bool? IsItalic(this TextSelection Selection)
        {
            bool? fIsItalic = null;

            object objValue = Selection.GetPropertyValue(TextElement.FontStyleProperty);

            if (objValue != DependencyProperty.UnsetValue && objValue is FontStyle)
                fIsItalic = (FontStyle) objValue == FontStyles.Italic ? true : false;

            return fIsItalic;
        }

        /// <summary>
        /// Ermittelt, ob der ausgewählte Text unterstrichen formatiert ist.
        /// </summary>
        public static bool? IsUnderline(this TextSelection Selection)
        {
            bool? fIsUnderline = null;

            object objValue = Selection.GetPropertyValue(Inline.TextDecorationsProperty);

            if (objValue != DependencyProperty.UnsetValue)
            {
                var fntUnderline = (TextDecorationCollection)objValue;
                fIsUnderline = fntUnderline.Contains(TextDecorations.Underline[0]);
            }

            return fIsUnderline;
        }

        /// <summary>
        /// Ermittelt die Ausrichtung eines ausgewählten Textes.
        /// </summary>
        public static TextAlignment GetAlignment(this TextSelection Selection)
        {
            TextAlignment enmAlignment = TextAlignment.Left;

            object objValue = Selection.GetPropertyValue(Block.TextAlignmentProperty);

            if (objValue != DependencyProperty.UnsetValue)
                enmAlignment = (TextAlignment) objValue;

            return enmAlignment;
        }

        /// <summary>
        /// Ermittelt die Schriftart des Textes.
        /// </summary>
        public static string GetFontFamily(this TextSelection Selection)
        {
            string strFontFamily = null;

            object objValue = Selection.GetPropertyValue(TextElement.FontFamilyProperty);

            if (objValue != DependencyProperty.UnsetValue)
            {
                var font = (System.Windows.Media.FontFamily)objValue;
                strFontFamily = font.ToString();
            }

            return strFontFamily;
        }


    }
}
