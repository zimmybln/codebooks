﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SelfhostingWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUri = "http://localhost:8080";

            

            Console.WriteLine("Starting web Server...");
            using (var webapp = WebApp.Start<StartupWithInfoOnlyServices>(baseUri))
            {
                Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
                Console.ReadLine();
            }
        }
    }
}
