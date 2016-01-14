using System;
using System.Collections.Generic;

namespace Leet.Kantilever.FEBestellingen.Site.ViewModels
{
    public class BestellingVM
    {
        public long Bestelnummer { get; set; }
        public List<BestellingsRegelVM> Bestellingsregels { get; set; }
        public DateTime Besteldatum { get; set; }
        public decimal? Totaalprijs { get; }

    }
}