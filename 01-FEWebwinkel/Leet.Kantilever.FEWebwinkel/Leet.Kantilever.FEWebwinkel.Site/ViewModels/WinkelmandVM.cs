﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site.ViewModels
{
    public class WinkelmandVM
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public int Aantal { get; set; }
        public decimal TotaalPrijs { get; set; }
    }
}