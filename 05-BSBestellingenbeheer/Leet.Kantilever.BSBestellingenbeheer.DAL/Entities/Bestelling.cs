using System;
using System.Collections.Generic;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.entities
{
    public class Bestelling
    {
        public long ID { get; set; }
        public long Bestelnummer { get; set; }
        public virtual ICollection<BestellingsRegel> Bestellingsregels { get; set; }
        public DateTime Besteldatum { get; set; }
        public long KlantID { get; set; }
        public bool Ingepakt { get; set; }

    }
}