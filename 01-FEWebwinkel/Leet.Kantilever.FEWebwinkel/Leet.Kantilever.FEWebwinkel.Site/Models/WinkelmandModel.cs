using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site.Models
{
    [Serializable]
    public class WinkelmandModel
    {
        public string ProductId { get; set; }
        public int Aantal { get; set; }
    }
}