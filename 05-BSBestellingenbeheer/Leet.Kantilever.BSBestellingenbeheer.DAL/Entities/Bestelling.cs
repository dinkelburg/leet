using System;
using System.Collections.Generic;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.Entities
{
    public class Bestelling
    {
        public long ID { get; set; }
        public long Bestelnummer { get; set; }
        public virtual ICollection<BestellingsRegel> Bestellingsregels { get; set; }
        public DateTime Besteldatum { get; set; }
        public string Klantnummer { get; set; }
        public bool Ingepakt { get; set; }

    }
}