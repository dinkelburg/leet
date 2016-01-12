using System.ComponentModel.DataAnnotations;

namespace Leet.Kantilever.FEWebwinkel.Site.ViewModels
{
    public class LoginModel
    {
        [Display(Name = "Onthoud mij")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string Username { get; set; }
    }
}