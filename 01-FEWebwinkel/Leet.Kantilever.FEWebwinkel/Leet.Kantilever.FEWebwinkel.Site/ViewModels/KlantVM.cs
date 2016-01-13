using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site.ViewModels
{
    public class KlantVM
    {
        public int ID { get; set; }
        [Required]
        public string Gebruikersnaam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        public string Adresregel1 { get; set; }
        public string Adresregel2 { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string Woonplaats { get; set; }
        [Required]
        public string Telefoonnummer { get; set; }
        public string Email { get; set; }
    }
}