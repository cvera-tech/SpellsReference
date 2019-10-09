using SpellsReference.Data;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using SpellsReference.Models.ViewModels;
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
            var spellbook = _spellbookRepo.Get(id);
            var spells = _spellbookRepo.GetNonmemberSpells(id);
            var viewModel = new AddSpellToSpellbookViewModel()
            {
                SpellbookId = spellbook.Id,
                SpellbookName = spellbook.Name,
                Spells = spells
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddSpell(int id, int spellId, AddSpellToSpellbookViewModel viewModel)
        {
            if (_spellbookRepo.AddSpellToSpellbook(id, spellId))
            {
                return RedirectToAction("Select", "Spellbook", routeValues: new { id = id });
            }
            return View(viewModel);
        }
    }
}