using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BLL.Entities;
using TaskManager.Common.Repositories;

namespace TaskManager.BLL.Services
{
    public class ManagedTaskService : ITaskRepository<ManagedTask>
    {
        private ITaskRepository<DAL.Entities.ManagedTask> _dalService;
        private IUserRepository<User> _userService;

        public ManagedTaskService(
            ITaskRepository<DAL.Entities.ManagedTask> dalService, 
            IUserRepository<User> userService)
        {
            _dalService = dalService;
            _userService = userService;
        }

        public bool Delete(Guid taskId)
        {
            return _dalService.Delete(taskId);
        }

        public IEnumerable<ManagedTask> Get()
        {
            return _dalService.Get();
        }

        public ManagedTask Get(Guid taskId)
        {
            return _dalService.Get(taskId);
        }

        public Guid Insert(ManagedTask entity)
        {
            return _dalService.Insert(entity);
        }

        public bool Update(Guid taskId, ManagedTask entity)
        {
            return _dalService.Update(taskId, entity);
        }
    }
}
