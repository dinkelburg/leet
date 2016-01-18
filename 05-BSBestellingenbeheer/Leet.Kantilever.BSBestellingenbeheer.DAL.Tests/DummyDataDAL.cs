using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using System;
using System.Collections.Generic;

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
                Bestellingsregels = GetBestellingsRegels(),
                Bestelnummer = 2,
                Ingepakt = true,
                Klantnummer = "Client01",
            };
        }

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

                ID = 2,
                Besteldatum = new DateTime(2015,12,12),
                Bestellingsregels = GetBestellingsRegels(),
                Bestelnummer = 2,
                Ingepakt = true,
                Klantnummer = "Client01",
                },
                new Bestelling
                {
                ID = 3,
                Besteldatum = new DateTime(2015,01,10),
                Bestellingsregels = GetBestellingsRegels(),
                Bestelnummer = 2,
                Ingepakt = false,
                Klantnummer = "Client01",
                },
                    new Bestelling
                {
                ID = 4,
                Besteldatum = new DateTime(2015, 01, 11),
                Bestellingsregels = GetBestellingsRegels(),
                Bestelnummer = 3,
                Ingepakt = false,
                Klantnummer = "Client01",
                },
                };
            }

 
    }
    }
