using Leet.Kantilever.FEWebwinkel.Site;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leet.Kantilever.FEBestellingen.Site.ViewModels
{
    public class BestellingVM
    {
        public BestellingVM()
        {
            Bestellingsregels = new List<BestellingsregelVM>();
        }

        public BestellingVM(List<BestellingsregelVM> bestellingList)
        {
            Bestellingsregels = bestellingList;
        }

        public long Bestelnummer { get; set; }
        public List<BestellingsregelVM> Bestellingsregels { get; private set; }
        public DateTime Besteldatum { get; set; }
        public BestellingStatusVM Status { get; set; }

        public enum BestellingStatusVM
        {
            Nieuw = 1,
            Betaald = 2,
            Geweigerd = 4,
            Goedgekeurd = 8,
            Inpakken = 16,
            Ingepakt = 32,
        }

        /// <summary>
        /// Totaalprijs is defined as a string. This way, it can be displayed correctly in the view
        /// with proper localized currency formatting. 
        /// </summary>
        public string TotaalprijsInclusiefBtw
        {
            get
            {
                decimal totaalprijs = Bestellingsregels.Sum(b => b.Prijs * b.Aantal).Value;
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