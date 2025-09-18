using TaskManager.ASPMVC.Models.User;
using TaskManager.BLL.Entities;

namespace TaskManager.ASPMVC.Mapper
{
    internal static class Mapper
    {
        public static UserListItem ToListItem(this User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new UserListItem() { 
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
    }
}
