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
        public BestellingStatus Status { get; set; }

        public enum BestellingStatus
        {
            Nieuw = 0,
            Geweigerd = 1,
            Goedgekeurd = 2,
            Inpakken = 3,
            Ingepakt = 4,
            Betaald = 5
        }
    }


}