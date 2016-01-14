using minorcase3bsklantbeheer.v1.schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEBestellingen.Site.ViewModels
{
    public class FactuurVM
    {
        public BestellingVM Bestelling { get; set; }
        public Klant Klant { get; set; }
    }
}