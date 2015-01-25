using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfiguration
{ 
    public class AppConfigurationSection : ConfigurationSection 
    {

        [ConfigurationProperty("Name")]
        public string Name
        {
            get { return this["Name"] as string; }
        }

        [ConfigurationProperty("Item")]
        public ItemElement SingleItem
        {
            get { return this["Item"] as ItemElement; }
        }

        [ConfigurationProperty("Servers")]
        public ServerElementCollection Servers
        {
            get { return this["Servers"] as ServerElementCollection; }
        }

        public static AppConfigurationSection Settings
        {
            get
            {
                return ConfigurationManager.GetSection("AppConfigurationSection") as AppConfigurationSection;
            }
        }
    }

    public class ItemElement : ConfigurationElement
    {
        [ConfigurationProperty("Value1")]
        public string Value1
        {
            get { return this["Value1"] as string; }
            set { this["Value1"] = value; }
        }
    }

    public class ServerElement : ConfigurationElement
    {
        [ConfigurationProperty("Name")]
        public string Name
        {
            get { return this["Name"] as string; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("Position")]
        public string Position
        {
            get { return this["Position"] as string; }
            set { this["Position"] = value; }
        }
    }

    [ConfigurationCollection(typeof(ServerElement), AddItemName = "Server", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ServerElementCollection : ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new ServerElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServerElement) element).Name;
        }

        public new IEnumerator<ServerElement> GetEnumerator()
        {
            int count = this.Count;
            for (int i = 0; i < count; i++)
            {
                yield return this.BaseGet(i) as ServerElement;
            }
        }
    }
}
