using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.converters
{
    public static class DTOToEntity
    {
        public static Entities.Bestelling BestellingToEntity(Leet.Kantilever.BSBestellingenbeheer.V1.Schema.Bestelling bestelling)
        {
            return new Entities.Bestelling
            {
                Besteldatum = bestelling.Besteldatum,
                Bestellingsregels = bestelling.Bestellingsregels.Select(r => BestellingsregelToEntity(r)).ToArray(),
                Bestelnummer = bestelling.Bestelnummer,
                Ingepakt = false,
                KlantID = bestelling.KlantID
            };
        }

        public static Entities.BestellingsRegel BestellingsregelToEntity(Leet.Kantilever.BSBestellingenbeheer.V1.Schema.Bestellingsregel regel)
        {
            return new Entities.BestellingsRegel {
                Aantal = regel.Aantal,
                ProductID = regel.ProductID,
                Prijs = regel.Prijs,
            };
        }
    }
}
