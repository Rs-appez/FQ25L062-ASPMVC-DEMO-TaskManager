using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using TaskManager.ASPMVC.Helpers;
using TaskManager.ASPMVC.Mapper;
using TaskManager.ASPMVC.Models.User;
using TaskManager.BLL.Services;
using TaskManager.Common.Repositories;

namespace TaskManager.ASPMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository<BLL.Entities.User> _userService;

        public UserController(IUserRepository<BLL.Entities.User> userRepository)
        {
            _userService = userRepository;
        }

        [ViewData]
        public string Title { get; set; }
        //Route : /User/Register
        public IActionResult Register()
        {
            Title = "Enregistrez-vous";
            //return View("RegisterScaffold");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterForm form)
        {
            Title = "Enregistrez-vous";
            try
            {
                ModelState.CheckIfNumbers(form.Password, nameof(form.Password));
                ModelState.CheckIfLowerChar(form.Password, nameof(form.Password));
                ModelState.CheckIfUpperChar(form.Password, nameof(form.Password));
                ModelState.CheckIfSymbolChar(form.Password, nameof(form.Password));
                if (!ModelState.IsValid) throw new Exception("Formulaire invalide");
                //Envoyer les infos du formulaire dans la DB
                Guid userId = _userService.Insert(form.ToBLL());
                TempData["successMessage"] = "Enregistrement réussi!";
                return RedirectToAction("Index", "Home");
                //return RedirectToAction("Details", "User", new { id = userId });
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                //return View("RegisterScaffold");
                return View();
            }
        }

        public IActionResult Index()
        {
            /*List<UserListItem> model = new List<UserListItem>() {
                new UserListItem(){
                    UserId = Guid.NewGuid(),
                    Email = "samuel.legrain@bstorm.be",
                    Role = "Admin"
                },
                new UserListItem(){
                    UserId = Guid.NewGuid(),
                    Email = "michael.person@bstorm.be",
                    Role = "Admin"
                },
                new UserListItem(){
                    UserId = Guid.NewGuid(),
                    Email = "thierry.morre@bstorm.be",
                    Role = "User"
                }
            };*/
            IEnumerable<UserListItem> model = _userService.Get().Select(bll => bll.ToListItem());
            return View(model);
        }

    }
}
