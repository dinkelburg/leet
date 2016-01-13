using Leet.Kantilever.BSBestellingenbeheer.DAL.entities;
using System;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.Tests
{
    class DummyDataDAL
    {
        internal static Bestelling GetBestelling()
        {
            return new Bestelling
            {
                ID = 1,
                Besteldatum = DateTime.Now,
                Bestellingsregels = null,
                Bestelnummer = 2,
                Ingepakt = false,
                KlantID = 1,
            };
        }
    }
}