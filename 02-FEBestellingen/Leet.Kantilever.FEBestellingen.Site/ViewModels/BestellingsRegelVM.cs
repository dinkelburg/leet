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
        public decimal? Prijs { get;  set; }
        public string Totaalprijs { get { return string.Format("{0:C}", Aantal * Prijs); } }
    }
}