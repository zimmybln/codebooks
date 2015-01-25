using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebAppReader
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadDataWithTask();


            Console.Write("Drücke eine Taste, um die Anwendung zu beenden");
            Console.ReadKey();
        }

        private static void LoadDataWithoutTask()
        {
            var web = new WebClient();
            web.Proxy = WebRequest.DefaultWebProxy;

            var strValue = web.DownloadString("http://localhost:1572/DefaultHandler.ashx");

            Console.WriteLine(String.Format("{0}: {1}", MethodBase.GetCurrentMethod().Name, strValue));
        }

        /// <summary>
        /// Führt eine Task aus und schreibt das Ergebnis 
        /// </summary>
        private static void LoadDataWithTask()
        {
            // Definition des Tasks
            var task = new Task<string>(() =>
                                {
                                    var web = new WebClient();

                                    var strValue = web.DownloadString("http://localhost:1572/DefaultHandler.ashx");

                                    return strValue;
                                });

            // Starten des Tasks
            task.Start();

            // Warten, bis der Task beendet ist
            task.Wait();

            // Ausgabe des Ergebnisses
            Console.WriteLine(String.Format("{0}: {1}", MethodBase.GetCurrentMethod().Name, task.Result));

        }


    }
}
