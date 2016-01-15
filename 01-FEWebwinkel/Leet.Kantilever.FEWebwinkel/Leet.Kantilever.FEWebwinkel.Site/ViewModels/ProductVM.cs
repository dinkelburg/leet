using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site.ViewModels
{
    /// <summary>
    /// A product that is shown in the catalogus.
    /// </summary>
    public class ProductVM
    {
        public long? ID { get; set; }
        public string Naam { get; set; }
        public decimal? Prijs { get; set; }
        public decimal? PrijsInclusiefBtw
        {
            get { return BtwHelper.CalculateBtw(Prijs); }
        }
        public string LeverancierNaam { get; set; }
        public string AfbeeldingPad { get; set; }

    }
}