using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.PcSBestellen.Host.ConfigSections
{
    /// <summary>
    ///  
    /// </summary>
    public class OrderLimietConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("limiet", DefaultValue = 0, IsRequired = true)]
        public int Limiet
        {
            get
            {
                return (int)this["limiet"];
            }
            set
            {
                this["limiet"] = value;
            }
        }
    }
}