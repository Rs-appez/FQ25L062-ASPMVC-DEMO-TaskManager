using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using TaskManager.ASPMVC.Helpers;
using TaskManager.ASPMVC.Models.User;

namespace TaskManager.ASPMVC.Controllers
{
    public class UserController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        //Route : /User/Register
        public IActionResult Register()
        {
            Title = "Enregistrez-vous";
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
                TempData["successMessage"] = "Enregistrement réussi!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                return View();
            }
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
