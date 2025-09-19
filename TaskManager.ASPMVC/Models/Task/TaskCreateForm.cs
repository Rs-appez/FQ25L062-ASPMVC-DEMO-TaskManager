using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.ASPMVC.Models.Task
{
    public class TaskCreateForm
    {
        [DisplayName("Sujet : ")]
        [Required(ErrorMessage = "Le sujet est obligatoire.")]
        [MaxLength(256, ErrorMessage ="Le sujet doit être composé d'un maximum de 256 caractères")]
        public string Title { get; set; }

        [DisplayName("Description : ")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [DisplayName("Échéance : ")]
        [DataType("datetime-local")]    //Attention, le datatype DateTime n'est pas correct!
        public DateTime? DeadLine { get; set; }

        [DisplayName("Créateur de la tâche : ")]
        [Required(ErrorMessage = "Le créateur de la tâche est obligatoire.")]
        public Guid CreatorId { get; set; }
    }
}
