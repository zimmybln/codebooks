using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace CommandSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MyTestClass mv_objTestClass;

        public App()
        {
            mv_objTestClass = new MyTestClass("Das ist jetzt eine globale Klasse");
        }

        public string Test
        {
            get { return "Das ist ein Wert aus der globalen Anwendungsklasse"; }
        }

        public MyTestClass TestClass
        {
            get { return mv_objTestClass; }
        }

        
    }

    public class MyTestClass
    {
        private string mv_strMyClassName;

        public MyTestClass(string Name)
        {
            mv_strMyClassName = Name;
        }

        public override string ToString()
        {
            return "Global: " + mv_strMyClassName + " " + DateTime.Now.ToString();
        }
    }
}
