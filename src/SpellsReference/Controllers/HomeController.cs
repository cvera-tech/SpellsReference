using SpellsReference.Data;
using SpellsReference.Models;
using SpellsReference.Data.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    public class HomeController : Controller
    {
        private IContext context;

        public HomeController(IContext context)
        {
            this.context = context;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            SpellRepository spellRepo = new SpellRepository(context);
            List<Spell> spells = spellRepo.GetSpells();

            return View(spells);
        }
    }
}