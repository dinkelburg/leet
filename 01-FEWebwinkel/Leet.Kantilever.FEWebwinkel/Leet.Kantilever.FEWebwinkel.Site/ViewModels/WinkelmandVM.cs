using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site.ViewModels
{
    public class WinkelmandVM
    {
        public List<WinkelmandRijVM> Producten { get; set; }
        [DisplayName("Totaalprijs exclusief BTW")]
        public decimal? Totaalprijs { get { return Producten.Sum(rij => rij.Totaalprijs); } }
        [DisplayName("Totaalprijs inclusief BTW")]
        public decimal? TotaalprijsInclusiefBtw { get { return BtwHelper.CalculateBtw(Totaalprijs); } }
    }

    public class WinkelmandRijVM
    {
        public string Naam { get; set; }
        public decimal? Prijs { get; set; }
        public decimal? PrijsInclusiefBtw { get { return BtwHelper.CalculateBtw(Prijs); } }
        public int Aantal { get; set; }
        public decimal? Totaalprijs { get { return Prijs * Aantal; } }
        public decimal? TotaalprijsInclusiefBtw { get { return BtwHelper.CalculateBtw(Totaalprijs); } }
    }
}