using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BLL.Entities;
using TaskManager.BLL.Mapper;
using TaskManager.Common.Repositories;
using D = TaskManager.DAL.Services;

namespace TaskManager.BLL.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly IUserRepository<DAL.Entities.User> _dalService;

        public UserService(IUserRepository<DAL.Entities.User> userRepository)
        {
            _dalService = userRepository;
        }

        /* Constructeur pour les tests en console
        public UserService()
        {
            _dalService = new DAL.Services.UserService();
        }*/

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

        public User GetCreator(Guid taskId)
        {
            return _dalService.GetCreator(taskId).ToBLL();
        }
    }
}
