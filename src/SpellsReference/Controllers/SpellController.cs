using SpellsReference.Data;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    public class SpellController : Controller
    {
        private IContext _context;
        private ISpellRepository _spellRepo;

        public SpellController(IContext context, ISpellRepository spellRepo)
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

        // Selects a single spell from a list of spells. This might later be moved 
        // to a functionality from spellbook. The Spell Edit and Delete will be tied into this view. 
        // Also, maybe [Authorize], not sure.
        [AllowAnonymous]
        public ActionResult Select(int id)
        {
            Spell spell = _spellRepo.Get(id);

            return View(spell);
        }

        public ActionResult Create()
        {
            var viewModel = new SpellViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpellViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var spell = new Spell()
                {
                    Name = viewModel.Name,
                    Level = viewModel.Level,
                    School = viewModel.School,
                    CastingTime = viewModel.CastingTime,
                    Range = viewModel.Range,
                    Verbal = viewModel.Verbal,
                    Somatic = viewModel.Somatic,
                    Materials = viewModel.Materials,
                    Duration = viewModel.Duration,
                    Ritual = viewModel.Ritual,
                    Description = viewModel.Description
                };

                var success = _spellRepo.Add(spell);
                if (success.HasValue)
                {
                    return RedirectToAction("Index", "Spell");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to add spell.");
                }
            }

            return View(viewModel);
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}