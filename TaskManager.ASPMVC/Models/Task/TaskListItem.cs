using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.ASPMVC.Models.Task
{
    public class TaskListItem
    {
        [ScaffoldColumn(false)]
        [DisplayName("Identifiant : ")]
        public Guid TaskId { get; set; }

        [DisplayName("Sujet : ")]
        public string Title { get; set; }

        [DisplayName("Date de création : ")]
        [DataType("datetime-local")]    //Attention, le datatype DateTime n'est pas correct!
        public DateTime CreationDate { get; set; }

        [DisplayName("Créateur de la tâche : ")]
        [EmailAddress]
        public string CreatorEmail { get; set; }

        [DisplayName("Identifiant du créateur de la tâche : ")]
        [ScaffoldColumn(false)]
        public Guid CreatorId { get; set; }
    }
}
