using TaskManager.ASPMVC.Models.Task;
using TaskManager.ASPMVC.Models.User;
using TaskManager.BLL.Entities;

namespace TaskManager.ASPMVC.Mapper
{
    internal static class Mapper
    {
        #region User
        public static UserListItem ToListItem(this User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new UserListItem()
            {
                UserId = entity.UserId,
                Email = entity.Email,
                Role = entity.Role.ToString()
            };
        }

        public static User ToBLL(this UserRegisterForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new User(entity.Email, entity.Password);
        }
        #endregion
        #region Task
        public static ManagedTask ToBLL(this TaskCreateForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new ManagedTask(entity.Title, entity.Description, entity.DeadLine, entity.CreatorId);
        }
        public static ManagedTask ToBLL(this TaskEditForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new ManagedTask(entity.Title, entity.Description, entity.DeadLine);
        }

        public static TaskDetails ToDetails(this ManagedTask entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new TaskDetails()
            {
                TaskId = entity.TaskId,
                Title = entity.Title,
                Description = entity.Description,
                DeadLine = entity.DeadLine,
                CreationDate = entity.CreationDate,
                CreatorId = entity.Creator.UserId,
                CreatorEmail = entity.Creator.Email
            };
        }
        public static TaskListItem ToListItem(this ManagedTask entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new TaskListItem()
            {
                TaskId = entity.TaskId,
                Title = entity.Title,
                CreationDate = entity.CreationDate,
                CreatorId = entity.Creator.UserId,
                CreatorEmail = entity.Creator.Email
            };
        }
        public static TaskDelete ToDelete(this ManagedTask entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new TaskDelete()
            {
                Title = entity.Title,
                CreationDate = entity.CreationDate,
                CreatorId = entity.Creator.UserId,
                CreatorEmail = entity.Creator.Email
            };
        }
        public static TaskEditForm ToEditForm(this ManagedTask entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new TaskEditForm()
            {
                Title = entity.Title,
                Description = entity.Description,
                DeadLine = entity.DeadLine
            };
        }
        #endregion
    }
}
