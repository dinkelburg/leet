using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.converters
{
    /// <summary>
    /// This class is responsible for converting all DTO's used in 
    /// request and response messages to entities as used by the database.
    /// </summary>
    public static class DTOToEntity
    {
        public static Entities.Bestelling BestellingToEntity(Leet.Kantilever.BSBestellingenbeheer.V1.Schema.Bestelling bestelling)
        {
            if (bestelling == null)
            {
                throw new ArgumentNullException(paramName:"bestelling");
            }

            return new Entities.Bestelling
            {
                Besteldatum = bestelling.Besteldatum,
                Bestellingsregels = bestelling.Bestellingsregels.Select(bestellingsregel => BestellingsregelToEntity(bestellingsregel)).ToArray(),
                Bestelnummer = bestelling.Bestelnummer,
                Ingepakt = false,
                Klantnummer = bestelling.Klantnummer,
                ID = bestelling.ID,
            };
        }

        public static Entities.BestellingsRegel BestellingsregelToEntity(V1.Schema.Bestellingsregel bestellingsregel)
        {
            if (bestellingsregel == null)
            {
                throw new ArgumentNullException(paramName:"bestellingsregel");
            }

            return new Entities.BestellingsRegel {
                Aantal = bestellingsregel.Aantal,
                ProductID = bestellingsregel.ProductID,
                Prijs = bestellingsregel.Prijs,
            };
        }
    }
}
