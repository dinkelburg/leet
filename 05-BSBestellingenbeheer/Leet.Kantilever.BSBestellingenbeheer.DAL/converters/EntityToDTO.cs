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
            if (bestelling == null)
            {
                throw new ArgumentNullException("bestelling");
            }

            return new V1.Schema.Bestelling
            {
                ID = bestelling.ID,
                Besteldatum = bestelling.Besteldatum,
                Bestellingsregels = BestellingsregelsToCollection(bestelling.Bestellingsregels),
                Bestelnummer = bestelling.Bestelnummer,
                Status = (V1.Schema.Bestellingsstatus)bestelling.Status,
                Klantnummer = bestelling.Klantnummer
            };
        }

        public static V1.Schema.Bestellingsregel BestellingsregelToDto(Entities.BestellingsRegel regel)
        {
            if (regel == null)
            {
                throw new ArgumentNullException(paramName: "regel");
            }
            return new V1.Schema.Bestellingsregel
            {
                Aantal = regel.Aantal,
                Prijs = regel.Prijs,
                ProductID = regel.ProductID
            };
        }

        public static V1.Schema.BestellingsregelCollection BestellingsregelsToCollection(ICollection<Entities.BestellingsRegel> regels)
        {
            if (regels == null)
            {
                throw new ArgumentNullException(paramName: "regels");
            }

            var collection = new V1.Schema.BestellingsregelCollection();
            collection.AddRange(regels.Select(BestellingsregelToDto));
            return collection;
        }

        public static V1.Schema.BestellingCollection BestellingCollectionToDto(IEnumerable<Entities.Bestelling> bestellingen)
        {
            if (bestellingen == null)
            {
                throw new ArgumentNullException(paramName: "bestellingen");
            }

            var dtoCollection = new V1.Schema.BestellingCollection();

            foreach (var b in bestellingen)
            {
                dtoCollection.Add(new V1.Schema.Bestelling
                {
                    Besteldatum = b.Besteldatum,
                    Bestelnummer = b.Bestelnummer,
                    ID = b.ID,
                    Klantnummer = b.Klantnummer,
                    Status = (V1.Schema.BestellingStatus)b.Status
                });
            }

            return dtoCollection;
        }
    }
}