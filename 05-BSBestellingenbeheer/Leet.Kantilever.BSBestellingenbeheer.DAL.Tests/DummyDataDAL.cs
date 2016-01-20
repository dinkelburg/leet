using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using System;
using System.Collections.Generic;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;
using Bestelling = Leet.Kantilever.BSBestellingenbeheer.DAL.Entities.Bestelling;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.Tests
{
    internal class DummyDataDAL
    {


        public static List<BestellingsRegel> GetBestellingsRegels()
        {
            return new List<BestellingsRegel>
            {
                new BestellingsRegel
                {
                    ID = 1,
                    Aantal = 3,
                    ProductID = 5,
                    Prijs = 5.5M,
                },
                new BestellingsRegel
                {
                    ID = 2,
                    Aantal = 3,
                    ProductID = 5,
                    Prijs = 10M,
                },
            };
        }

        internal static List<Bestelling> GetDummyBestellingen()
        {
            return new List<Bestelling>
            {
                new Bestelling
                {

                    Besteldatum = new DateTime(2015, 12, 12),
                    Bestellingsregels = GetBestellingsRegels(),
                    Ingepakt = true,
                    Klantnummer = "Client01",
                    Bestelnummer = 1,
                },
                new Bestelling
                {
                    Besteldatum = new DateTime(2015, 01, 10),
                    Bestellingsregels = GetBestellingsRegels(),
                    Ingepakt = false,
                    Klantnummer = "Client01",
                    Bestelnummer = 2,
                },
                new Bestelling
                {
                    Besteldatum = new DateTime(2015, 01, 11),
                    Bestellingsregels = GetBestellingsRegels(),
                    Ingepakt = false,
                    Klantnummer = "Client01",
                    Bestelnummer = 3,
                },
            };
        }

        internal static V1.Schema.Bestelling GetDummyDataDTOBestlling()
        {
            return new V1.Schema.Bestelling
            {
                Besteldatum = new DateTime(2015, 12, 12),
                Bestellingsregels = GetDummyDTOBestellinsregels(),
                Ingepakt = false,
                Bestelnummer = 123456,
                Klantnummer = "ANCD",
            };
        }

        internal static V1.Schema.BestellingsregelCollection GetDummyDTOBestellinsregels()
        {
            return new V1.Schema.BestellingsregelCollection
            {
                new Bestellingsregel()
                {
                    Aantal = 3,
                    ProductID = 5,
                    Prijs = 5.5M,
                },
            };
        }

    }
}