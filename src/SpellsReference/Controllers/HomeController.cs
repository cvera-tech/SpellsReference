using SpellsReference.Data;
using SpellsReference.Models;
using SpellsReference.Data.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    public class HomeController : Controller
    {
        private IContext _context;
        private ISpellRepository _spellRepo;

        public HomeController(IContext context, ISpellRepository spellRepo)
        {
            _context = context;
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