using SpellsReference.Data;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using SpellsReference.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    [Authorize]
    public class SpellbookController : Controller
    {
        private IContext _context;
        private ISpellbookRepository _spellbookRepo;

        public SpellbookController(IContext context, ISpellbookRepository spellbookRepo)
        {
            _context = context;
            _spellbookRepo = spellbookRepo;
        }

        public ActionResult Index()
        {
            List<Spellbook> spellbooks = _spellbookRepo.List();

            return View(spellbooks);
        }

        public ActionResult Select(int id)
        {
            Spellbook spellbook = _spellbookRepo.Get(id);

            return View(spellbook);
        }

        public ActionResult Create()
        {
            var viewModel = new SpellbookViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(SpellbookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var spellbook = new Spellbook()
                {
                    Name = viewModel.Name
                };

                var success = _spellbookRepo.Add(spellbook);
                if (success.HasValue)
                {
                    return RedirectToAction("Index", "Spellbook");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to add spellbook.");
                }
            }

            return View(viewModel);
        }
    }
}