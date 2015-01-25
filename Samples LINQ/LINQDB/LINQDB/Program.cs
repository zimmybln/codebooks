using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using LINQDB.Data;

namespace LINQDB
{
    class Program
    {
        static void Main(string[] args)
        {

            var objQueries = new SampleQueries();

            // Analyse 
            MethodInfo[] methodInfos = objQueries.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            while(true)
            {
                // Ausgabe des Menüs
                for (int i = 0; i < methodInfos.Count(); i++)
                {
                    string strTitle = methodInfos[i].Name;

                    object[] attributes = methodInfos[i].GetCustomAttributes(typeof (DescriptionAttribute), false);

                    if (attributes.Any())
                    {
                        strTitle = ((DescriptionAttribute) attributes[0]).Description;
                    }

                    Console.WriteLine(" {0}.\t{1}", i + 1, strTitle);
                }

                // Erfragen des Indexes
                Console.WriteLine();
                Console.Write("Methode: ");

                string strNumber = Console.ReadLine();

                if (String.IsNullOrEmpty(strNumber))
                    break;

                int nNumber = -1;

                if (!Int32.TryParse(strNumber, out nNumber))
                    break;

                if (nNumber < 0 || nNumber >= methodInfos.Count())
                    break;

                methodInfos[nNumber - 1].Invoke(objQueries, null);

                Console.WriteLine();
            }

        }


    }
}
