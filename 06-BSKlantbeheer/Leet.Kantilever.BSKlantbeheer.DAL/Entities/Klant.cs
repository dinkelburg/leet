namespace Leet.Kantilever.BSKlantbeheer.DAL.Entities
{
    public class Klant
    {
        public int ID { get; set; }
        public string Klantnummer { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Adresregel1 { get; set; }
        public string Adresregel2 { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public string Telefoonnummer { get; set; }
        public string Email { get; set; }
    }
}