using Leet.Kantilever.FEWebwinkel.Site;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leet.Kantilever.FEBestellingen.Site.ViewModels
{
    public class BestellingVM
    {
        public long Bestelnummer { get; set; }
        public List<BestellingsRegelVM> Bestellingsregels { get; set; }
        public DateTime Besteldatum { get; set; }
        //Totaalprijs is defined as a string. This way, it can be displayed correctly in the view
        //with proper localized currency formatting. 
        public string TotaalprijsInclusiefBtw {
            get
            {
                var totaalprijs = Bestellingsregels.Sum(b => b.Prijs * b.Aantal);
                var totaalInclusiefBtw = BtwHelper.CalculateBtw(totaalprijs);
                return string.Format("{0:C}", totaalInclusiefBtw);
            }
        }
        public string Totaalprijs
        {
            get
            {
                var totaalprijs = Bestellingsregels.Sum(b => b.Prijs * b.Aantal);
                return string.Format("{0:C}", totaalprijs);
            }
        }

    }
}