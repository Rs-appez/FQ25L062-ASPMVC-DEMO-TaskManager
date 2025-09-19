using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.ASPMVC.Models.Task
{
    public class TaskDetails
    {
        [ScaffoldColumn(false)]
        [DisplayName("Identifiant : ")]
        public Guid TaskId { get; set; }

        [DisplayName("Sujet : ")]
        public string Title { get; set; }

        [DisplayName("Description : ")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [DisplayName("Date de création : ")]
        [DataType("datetime-local")]    //Attention, le datatype DateTime n'est pas correct!
        public DateTime CreationDate { get; set; }

        [DisplayName("Échéance : ")]
        [DataType("datetime-local")]    //Attention, le datatype DateTime n'est pas correct!
        public DateTime? DeadLine { get; set; }

        [DisplayName("Créateur de la tâche : ")]
        [EmailAddress]
        public string CreatorEmail { get; set; }

        [DisplayName("Identifiant du créateur de la tâche : ")]
        [ScaffoldColumn(false)]
        public Guid CreatorId { get; set; }
    }
}
