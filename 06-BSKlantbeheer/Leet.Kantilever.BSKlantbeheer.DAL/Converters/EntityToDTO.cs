using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSKlantbeheer.DAL.Converters
{
    public static class EntityToDTO
    {
        public static V1.Schema.Klant ConvertKlant(Entities.Klant klant)
        {
            return new V1.Schema.Klant
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
