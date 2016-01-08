using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site.ViewModels
{
    public class WinkelmandVM
    {
        public List<WinkelmandRijVM> Producten { get; set; }
        public decimal? Totaalprijs { get { return Producten.Sum(rij => rij.Totaalprijs); } }
    }

    public class WinkelmandRijVM
    {
        public string Naam { get; set; }
        public decimal? Prijs { get; set; }
        public int Aantal { get; set; }
        public decimal? Totaalprijs { get { return Prijs * Aantal; } }
    }
}