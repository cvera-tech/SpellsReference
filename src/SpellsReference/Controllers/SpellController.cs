using SpellsReference.Data;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using SpellsReference.Models.ViewModels;
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



        // Definately [Authorize].
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(Spell spell)
        {
            // TODO

            return View(spell);
        }


        public ActionResult Edit(int id)
        {
            var spell = _spellRepo.Get(id);
            var viewModel = new EditSpellViewModel()
            {
                Name = spell.Name,
                Level = spell.Level,
                School = spell.School,
                CastingTime = spell.CastingTime,
                Range = spell.Range,
                Verbal = spell.Verbal,
                Somatic = spell.Somatic,
                Materials = spell.Materials,
                Duration = spell.Duration,
                Ritual = spell.Ritual,
                Description = spell.Description
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditSpellViewModel viewModel)
        {
            var spell = new Spell()
            {
                Id = id,
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

            if (_spellRepo.Update(spell))
            {
                return RedirectToAction("Select", "Spell",
                    routeValues: new { id = spell.Id });
            }
            else
            {
                ModelState.AddModelError("", "Unable to update Spell");
                return View(viewModel);
            }
        }

    }
}