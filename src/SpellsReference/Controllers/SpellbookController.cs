using SpellsReference.Data;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    public class SpellbookController : Controller
    {
        private IContext _context;
        private ISpellbookRepository _spellbookRepo;

        public SpellbookController(IContext context, ISpellbookRepository spellbookRepo)
        {
            _context = context;
            _spellbookRepo = spellbookRepo;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Spellbook> spellbooks = _spellbookRepo.List();
            var spells = _spellbookRepo.GetNonmemberSpells(1);

            return View(spellbooks);
        }

        // Maybe [Authorize]?
        [AllowAnonymous]
        public ActionResult Select(int id)
        {
            Spellbook spellbook = _spellbookRepo.Get(id);

            return View(spellbook);
        }

        public ActionResult AddSpell(int id)
        {
            var spells = _spellbookRepo.GetNonmemberSpells(id);

            return View();
        }
    }
}