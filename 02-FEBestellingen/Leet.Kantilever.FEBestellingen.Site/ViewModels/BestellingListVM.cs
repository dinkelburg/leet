using Leet.Kantilever.FEWebwinkel.Site;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEBestellingen.Site.ViewModels
{
    public class BestellingListVM
    {
        [Display(Name = "Totale prijs")]
        public decimal TotaalPrijs { get; set; }
        [Display(Name = "Bestelnummer")]
        public long Bestelnummer { get; set; }
        [Display(Name = "Aantal producten")]
        public int AantalProducten { get; set; }
        /// <summary>
        /// Totaalprijs is defined as a string. This way, it can be displayed correctly in the view
        /// with proper localized currency formatting. 
        /// </summary>
        public string TotaalprijsInclusiefBtw
        {
            get
            {
                var totaalInclusiefBtw = BtwHelper.CalculateBtw(TotaalPrijs);
                return string.Format("{0:C}", totaalInclusiefBtw);
            }
        }

        [Display(Name = "Totale prijs")]
        public string Totaalprijs
        {
            get
            {
                return string.Format("{0:C}", TotaalPrijs);
            }
        }
    }
}