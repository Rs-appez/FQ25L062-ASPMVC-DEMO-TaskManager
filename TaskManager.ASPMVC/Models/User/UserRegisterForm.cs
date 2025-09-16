using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.ASPMVC.Models.User
{
    public class UserRegisterForm
    {
        [Required(ErrorMessage = "L'adresse e-mail est obligatoire.")]
        [DisplayName("L'adresse e-mail : ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [DisplayName("Le mot de passe : ")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Le mot de passe doit contenir un minimum de 8 caractères.")]
        [MaxLength(128, ErrorMessage = "Le mot de passe doit contenir un maximum de 128 caractères.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmation du mot de passe est obligatoire.")]
        [DisplayName("Veuillez confirmer le mot de passe : ")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }
}
