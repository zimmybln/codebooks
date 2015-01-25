using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;


namespace MEFConsole
{

    public enum ExtensionType
    {
        Client = 0,

        Server = 1,

        Comunication = 2
    }


    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ExtensionInfoAttribute : Attribute 
    {
        private readonly ExtensionType mv_enmExtensionType;

        public ExtensionInfoAttribute(ExtensionType ExtensionType)
        {
            mv_enmExtensionType = ExtensionType;
        }

        public string Name { get; set; }

        public ExtensionType ExtensionType
        {
            get { return mv_enmExtensionType;  }
        }
    }

    public interface IExtensionInfo
    {
        string Name { get; }
        ExtensionType ExtensionType { get; }
    }
}
