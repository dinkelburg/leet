using Leet.Kantilever.FEWebwinkel.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEBestellingen.Site.ViewModels
{
    public class BestellingsregelVM
    {
        public string ProductNaam { get; set; }
        public string Leverancierscode { get; set; }
        public string LeveranciersNaam { get; set; }
        public int Aantal { get; set; }
        public decimal? Prijs { get; set; }
        /// <summary>
        /// Made into strings to get nicely formatted currency amounts. 
        /// </summary>
        public string PrijsInclusiefBtw
        {
            get
            {
                if (Prijs.HasValue)
                {
                    return string.Format("{0:C}", BtwHelper.CalculateBtw(Prijs.Value));
                }
                else
                {
                    return null;
                }
            }
        }

        public string Totaalprijs
        {
            get
            {
                if (Prijs.HasValue)
                {
                    return string.Format("{0:C}", Aantal * BtwHelper.CalculateBtw(Prijs.Value));
                }
                else
                {
                    return null;
                }
            }
        }
    }
}