using TaskManager.DAL.Entities;
using TaskManager.DAL.Services;

namespace TaskManager.ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService service = new UserService();

            User u1 = new User() { 
                Email = "samuel.legrain@bstorm.be", 
                Password = "Test1234="
            };

            u1.UserId = service.Insert(u1);

            u1 = service.Get(u1.UserId);

            u1 = service.CheckPassword(u1.Email, "Test1234=");

            List<User> users = service.Get().ToList();
        }
    }
}
