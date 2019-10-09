using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}