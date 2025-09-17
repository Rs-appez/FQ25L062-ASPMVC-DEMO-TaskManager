using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.ASPMVC.Models.User
{
    public class UserListItem
    {
        [ScaffoldColumn(false)]
        [DisplayName("Identifiant")]
        public Guid UserId { get; set; }
        [DisplayName("Adresse e-mail")]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Rôle")]
        public string Role { get; set; }
    }
}
