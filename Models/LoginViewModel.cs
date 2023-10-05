using System.ComponentModel.DataAnnotations;

namespace AST1.Models

    // Classe ayant les attributs du login 
{           
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email de l'utilisateur erroné ")]
        [Display(Name = "Email de l'utilisateur ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mot de Passe incorrecte")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de Passe")]
        public string Password { get; set; }

        [Display(Name = "Sauvgarder les parametres d'authentifications?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
