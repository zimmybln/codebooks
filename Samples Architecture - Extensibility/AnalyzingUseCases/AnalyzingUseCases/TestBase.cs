using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzingUseCases
{
    public abstract class TestBase
    {
        protected string LoadCodeFromSamples(string fileName)
        {
            string code = String.Empty;

            using (var content = this.GetType().Assembly.GetManifestResourceStream($"AnalyzingUseCases.Samples.{fileName}.cs"))
            using (var reader = new StreamReader(content))
            {
                code = reader.ReadToEnd();
            }

            return code;
        }

    }
}
