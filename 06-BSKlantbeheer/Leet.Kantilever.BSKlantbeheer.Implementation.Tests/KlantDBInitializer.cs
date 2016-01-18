using Leet.Kantilever.BSKlantbeheer.DAL;
using Leet.Kantilever.BSKlantbeheer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSKlantbeheer.Implementation.Tests
{
    class KlantDBInitializer : DropCreateDatabaseAlways<KlantenContext>
    {
        protected override void Seed(KlantenContext context)
        {
            ICollection<Klant> klanten = new List<Klant>
            {
                new Klant
                {
                    ID = 1,
                    Klantnummer = "ABCDEFG",
                    Gebruikersnaam = "John Doe",
                    Voornaam = "John",
                    Tussenvoegsel = null,
                    Achternaam = "Doe",
                    Adresregel1 = "Hoofdweg 6",
                    Adresregel2 = null,
                    Woonplaats = "Lutjebroek",
                    Email = "johndoe@example.com",
                    Postcode = "1234AB",
                    Telefoonnummer = "0612345678"
                },
                new Klant
                {
                    ID = 1,
                    Klantnummer = "KLJLKJSFD12314",
                    Gebruikersnaam = "jandevries123",
                    Voornaam = "Jan",
                    Tussenvoegsel = "de",
                    Achternaam = "Vries",
                    Adresregel1 = "Molenstraat 13",
                    Adresregel2 = "tegenover de bakker",
                    Woonplaats = "Beetsterzwaag",
                    Email = "jdevries@hotmail.com",
                    Postcode = "7352HJ",
                    Telefoonnummer = "+3109876543"
                }
            };

            context.Klanten.AddRange(klanten);

            base.Seed(context);
        }
    }
}
