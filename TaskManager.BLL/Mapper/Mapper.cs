using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B = TaskManager.BLL.Entities;
using D = TaskManager.DAL.Entities;

namespace TaskManager.BLL.Mapper
{
    internal static class Mapper
    {
        public static D.User ToDAL (this B.User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new D.User() { 
                UserId = entity.UserId,
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role.ToString(),
                CreationDate = entity.CreationDate,
                DisableDate = entity.DisableDate
            };
        }
        public static B.User ToBLL(this D.User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new B.User(
                entity.UserId,
                entity.Email,
                entity.Password,
                entity.Role,
                entity.CreationDate,
                entity.DisableDate
                );
        }
    }
}
