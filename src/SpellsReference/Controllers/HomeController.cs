using SpellsReference.Data;
using SpellsReference.Models;
using SpellsReference.Data.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Index()
        {
            List<Spell> spells = await _spellRepo.List();

            return View(spells);
        }
    }
}