using System.ComponentModel.DataAnnotations;

namespace pizzeria.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le nom est recquis")]
        public string LastName { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le nom est recquis")]
        public string FirstName { get; set; }

        [Display(Name = "Adresse email")]
        [Required(ErrorMessage = "L'email est recquis")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Le mot de passe est recquis")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmation mot de passe")]
        [Required(ErrorMessage = "Le confirmation est recquise")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; }
    }
}
