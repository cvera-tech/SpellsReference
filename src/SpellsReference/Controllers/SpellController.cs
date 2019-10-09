using SpellsReference.Data;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    [Authorize]
    public class SpellController : Controller
    {
        private ISpellRepository repository;

        public SpellController(ISpellRepository repository)
        {
            this.repository = repository;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Spell> spells = repository.List();

            return View(spells);
        }

        // Selects a single spell from a list of spells. This might later be moved 
        // to a functionality from spellbook. The Spell Edit and Delete will be tied into this view. 
        // Also, maybe [Authorize], not sure.
        [AllowAnonymous]
        public ActionResult Select(int id)
        {
            Spell spell = repository.Get(id);

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

                var success = repository.Add(spell);
                if (success.HasValue)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to add spell.");
                }
            }

            return View(viewModel);
        }
    }
}