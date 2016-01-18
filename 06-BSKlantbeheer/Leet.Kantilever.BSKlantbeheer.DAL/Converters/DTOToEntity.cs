using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSKlantbeheer.DAL.Converters
{
    public static class DTOToEntity
    {
        /// <summary>
        /// Transforms a klant DTO to an entity used by the database.
        /// </summary>
        /// <param name="klant">The klant DTO to transform.</param>
        /// <returns></returns>
        public static Entities.Klant ConvertKlant(V1.Schema.Klant klant)
        {
            return new Entities.Klant
            {
                ID = klant.ID,
                Klantnummer = klant.Klantnummer,
                Gebruikersnaam = klant.Gebruikersnaam,
                Voornaam = klant.Voornaam,
                Tussenvoegsel = klant.Tussenvoegsel,
                Achternaam = klant.Achternaam,
                Adresregel1 = klant.Adresregel1,
                Adresregel2 = klant.Adresregel2,
                Postcode = klant.Postcode,
                Woonplaats = klant.Woonplaats,
                Telefoonnummer = klant.Telefoonnummer,
                Email = klant.Email
            };
        }
    }
}
