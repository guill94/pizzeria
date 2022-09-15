using System.ComponentModel.DataAnnotations;

namespace pizzeria.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Adresse email")]
        [Required(ErrorMessage = "Veuillez entrer un Email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Veuillez entrer un mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
