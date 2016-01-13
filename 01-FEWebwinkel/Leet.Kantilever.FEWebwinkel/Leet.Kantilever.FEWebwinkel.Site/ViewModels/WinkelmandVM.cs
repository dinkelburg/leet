using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site.ViewModels
{
    /// <summary>
    /// The object used to show the customer the contents of his winkelmand.
    /// </summary>
    public class WinkelmandVM
    {
        public List<WinkelmandRijVM> Producten { get; set; }
        public decimal? Totaalprijs { get { return Producten.Sum(rij => rij.Totaalprijs); } }
    }

    /// <summary>
    /// An individual row of the customer's winkelmand.
    /// </summary>
    public class WinkelmandRijVM
    {
        public string Naam { get; set; }
        public decimal? Prijs { get; set; }
        public int Aantal { get; set; }
        public decimal? Totaalprijs { get { return Prijs * Aantal; } }
    }
}