using SpellsReference.Data;
using SpellsReference.Models;
using SpellsReference.Data.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    public class HomeController : Controller
    {
        private ISpellRepository _spellRepo;

        public HomeController(ISpellRepository spellRepo)
        {
            _spellRepo = spellRepo;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Spell> spells = _spellRepo.List();

            return View(spells);
        }
    }
}