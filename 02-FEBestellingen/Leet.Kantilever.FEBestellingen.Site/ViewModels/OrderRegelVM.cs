using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEBestellingen.Site.ViewModels
{
    public class OrderRegelVM
    {
        public string Naam { get; set; }
        public string Leverancier { get; set; }
        public long Leverancierscode { get; set; }
        public int Aantal { get; set; }

    }
}