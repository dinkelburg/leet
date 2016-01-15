using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL
{
    public static class EntityToDTO
    {
        public static V1.Schema.Bestelling BestellingToDto(Entities.Bestelling bestelling)
        {
            if(bestelling == null)
            {
                throw new ArgumentNullException("bestelling");
            }

            return new V1.Schema.Bestelling
            {
                ID = bestelling.ID,
                Besteldatum = bestelling.Besteldatum,
                Bestellingsregels = BestellingsregelsToCollection(bestelling.Bestellingsregels),
                Bestelnummer = bestelling.Bestelnummer,
                Ingepakt = bestelling.Ingepakt,
                Klantnummer = bestelling.Klantnummer
            };
        }

        public static V1.Schema.Bestellingsregel BestellingsregelToDto(Entities.BestellingsRegel regel)
        {
            return new V1.Schema.Bestellingsregel
            {
                Aantal = regel.Aantal,
                Prijs = regel.Prijs,
                ProductID = regel.ProductID
            };
        }

        public static V1.Schema.BestellingsregelCollection BestellingsregelsToCollection(ICollection<Entities.BestellingsRegel> regels)
        {
            var collection = new V1.Schema.BestellingsregelCollection();
            collection.AddRange(regels.Select(BestellingsregelToDto));
            return collection;
        }
    }
}