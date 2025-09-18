using TaskManager.BLL.Entities;
using TaskManager.BLL.Services;

namespace TaskManager.ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService service = new UserService();

            User u1 = new User("samuel.legrain@bstorm.be", "Test1234=");

            Guid id = service.Insert(u1);

            u1 = service.Get(id);

            u1 = service.CheckPassword(u1.Email, "Test1234=");

            List<User> users = service.Get().ToList();
        }
    }
}
