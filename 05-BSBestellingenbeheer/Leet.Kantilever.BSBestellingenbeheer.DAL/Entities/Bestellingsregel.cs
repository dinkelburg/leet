﻿namespace Leet.Kantilever.BSBestellingenbeheer.DAL.Entities
{
    public class BestellingsRegel
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public int Aantal { get; set; }
        public decimal Prijs { get; set; }
    }
}