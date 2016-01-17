using Leet.Kantilever.FEWebwinkel.Site;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEBestellingen.Site.ViewModels
{
    public class BestellingsRegelVM
    {
        [Display(Name = "Productnaam")]
        public string ProductNaam { get; set; }
        [Display(Name = "Leverancierscode")]
        public string Leverancierscode { get; set; }
        [Display(Name = "Leverancier")]
        public string LeveranciersNaam { get; set; }
        [Display(Name = "Aantal")]
        public int Aantal { get; set; }
        [Display(Name = "Prijs")]
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