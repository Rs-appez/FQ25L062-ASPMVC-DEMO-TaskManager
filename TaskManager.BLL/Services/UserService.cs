using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BLL.Entities;
using TaskManager.BLL.Mapper;
using D = TaskManager.DAL.Services;

namespace TaskManager.BLL.Services
{
    public class UserService
    {
        private D.UserService _dalService = new D.UserService();

        public IEnumerable<User> Get()
        {
            return _dalService.Get().Select(dal => dal.ToBLL());
        }

        public User Get(Guid userId) 
        { 
            return _dalService.Get(userId).ToBLL();
        }

        public Guid Insert(User entity)
        {
            return _dalService.Insert(entity.ToDAL());
        }

        public bool Delete(Guid userId) 
        {
            return _dalService.Delete(userId);
        }

        public User CheckPassword(string email, string password)
        {
            return _dalService.CheckPassword(email, password).ToBLL();
        }
    }
}
