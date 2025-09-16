using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using TaskManager.ASPMVC.Helpers;
using TaskManager.ASPMVC.Models.User;

namespace TaskManager.ASPMVC.Controllers
{
    public class UserController : Controller
    {
        //Route : /User/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterForm form)
        {
            try
            {
                ModelState.CheckIfNumbers(form.Password, nameof(form.Password));
                ModelState.CheckIfLowerChar(form.Password, nameof(form.Password));
                ModelState.CheckIfUpperChar(form.Password, nameof(form.Password));
                ModelState.CheckIfSymbolChar(form.Password, nameof(form.Password));
                if (!ModelState.IsValid) throw new Exception("Formulaire invalide");
                //Envoyer les infos du formulaire dans la DB
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
