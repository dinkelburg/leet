using Leet.Kantilever.BSBestellingenbeheer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Leet.Kantilever.BSBestellingenbeheer.V1.Messages;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;

namespace Leet.Kantilever.BSBestellingenbeheer.Implementation
{
    public class BestellingenbeheerServiceHandler : IBestellingenbeheerService
    {
        public BestellingenResponseMessage FindAllBestelling()
        {
            var bestellingen = new BestellingCollection();

            return new BestellingenResponseMessage { Result = bestellingen, ResultCount = bestellingen.Count() };
        }

        public BestellingenResponseMessage FindBestelling(BestellingenRequestMessage m)
        {
            var bestellingen = new BestellingCollection();

            var regels = new BestellingsregelCollection();
            regels.AddRange(new List<Bestellingsregel> {
                new Bestellingsregel { ProductId = 1, Aantal = 5, Prijs = 15.00M },
                new Bestellingsregel { ProductId = 5, Aantal = 3, Prijs = 102.00M },
                new Bestellingsregel { ProductId = 8, Aantal = 15, Prijs = 33.20M },
                new Bestellingsregel { ProductId = 4, Aantal = 1, Prijs = 19.99M },
            });

            bestellingen.Add(new Bestelling {
                Besteldatum = DateTime.Now,
                Bestellingsregels = regels,
                ID = m.BestellingId,
                KlantID = 61015
            });

            return new BestellingenResponseMessage
            {
                Result = bestellingen,
                ResultCount = bestellingen.Count()
            };
        }
        
    }
}
