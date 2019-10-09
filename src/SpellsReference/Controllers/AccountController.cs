using SpellsReference.Data.Repositories;
using SpellsReference.Models.ViewModels;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository repository;

        public AccountController(IAccountRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (repository.Authenticate(viewModel.EmailAddress, viewModel.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(viewModel);
        }
    }
}