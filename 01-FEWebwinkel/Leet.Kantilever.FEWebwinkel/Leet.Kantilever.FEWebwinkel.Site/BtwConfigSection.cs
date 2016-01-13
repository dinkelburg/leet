using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site
{
    /// <summary>
    /// A representation of the btw element in the web.config file.
    /// Is used to calculate the btw rate of products. Can contain 
    /// multiple btw rates. 
    /// </summary>
    public class BtwConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(TariefElement), AddItemName = "tarief")]
        public TariefCollection Tarieven
        {
            get { return (TariefCollection)this[""]; }
            set { this[""] = value; }
        }
    }

    public class TariefElement : ConfigurationElement
    {
        [ConfigurationProperty("mode", IsKey = true, IsRequired = true)]
        public string Mode
        {
            get { return (string)this["mode"]; }
            set { this["mode"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }

    public class TariefCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TariefElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TariefElement)element).Mode;
        }
    }
}