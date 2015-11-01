using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzingUseCases.Samples
{

    /// <summary>
    /// Das ist die erste Klasse
    /// </summary>
    public class MyFirstClass
    {
        public string FirstProperty { get; set; }


        public string ThisIsReadOnlyProperty { get; }

        public void AddItemsToFirstClass()
        {

        }

        public int AddItemsToFirstClassWithReturnValue(int item)
        {
            return 0;
        }
    }

    /// <summary>
    /// Das ist die zweite Klasse
    /// </summary>
    public class MySecondClass
    {

    }

    public enum SomeConstants
    {
        First = 1,

        Second = 2
    }


}
