using SpellsReference.Models.ViewModels;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }
    }
}