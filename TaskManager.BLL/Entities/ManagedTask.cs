using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BLL.Entities
{
    public class ManagedTask
    {
        public Guid TaskId { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public User Creator { get; private set; }
        public DateTime? DeadLine { get; private set; }
        public DateTime CreationDate { get; private set; }

        private Guid _creatorId;

        public ManagedTask(Guid taskId, string title, string? description, DateTime? deadLine, DateTime creationDate, Guid creatorId)
        {
            TaskId = taskId;
            Title = title;
            Description = description;
            DeadLine = deadLine;
            CreationDate = creationDate;
            _creatorId = creatorId;
        }

        public ManagedTask(Guid taskId, string title, string? description, DateTime? deadLine, DateTime creationDate, User creator)
        {
            TaskId = taskId;
            Title = title;
            Description = description;
            DeadLine = deadLine;
            CreationDate = creationDate;
            Creator = creator;
            _creatorId = Creator.UserId;
        }
    }
}
