using Leet.Kantilever.FEWebwinkel.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEBestellingen.Site.ViewModels
{
    public class BestellingsRegelVM
    {
        public string ProductNaam { get; set; }
        public string Leverancierscode { get; set; }
        public string LeveranciersNaam { get; set; }
        public int Aantal { get; set; }
        public decimal? Prijs { get; set; }
        //Made into strings to get nicely formatted currency amounts. 
        public string PrijsInclusiefBtw
        {
            get
            {
                return string.Format("{0:C}", BtwHelper.CalculateBtw(Prijs));
            }
        }
        public string Totaalprijs
        {
            get
            {
                return string.Format("{0:C}", Aantal * BtwHelper.CalculateBtw(Prijs));
            }
        }
    }
}