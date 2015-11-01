using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProgramming.SeparationOfConcern.Components
{
    public class ImportData
    {
        public string Import(Stream content)
        {
            var sbResult = new StringBuilder();

            // Textparser 
            TextFieldParser parser = new TextFieldParser(content, Encoding.UTF8);





             
            return sbResult.ToString();
        }



    }
}
