using AutoMapper;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using SpellsReference.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    public class SpellController : Controller
    {
        private ISpellRepository _spellRepo;

        public SpellController(ISpellRepository spellRepo)
        {
            _spellRepo = spellRepo;
        }

        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            List<Spell> spells = await _spellRepo.List();

            return View(spells);
        }

        // Selects a single spell from a list of spells. This might later be moved 
        // to a functionality from spellbook. The Spell Edit and Delete will be tied into this view. 
        // Also, maybe [Authorize], not sure.
        [AllowAnonymous]
        public async Task<ActionResult> Select(int id)
        {
            Spell spell = await _spellRepo.Get(id);

            // Maybe eventually set up Mapper DI.
            //var mapper = new Mapper(config);
            //SpellViewModel viewModel = mapper.Map<SpellViewModel>(spell);

            var viewModel = new SpellViewModel();
            viewModel.Id = spell.Id;
            viewModel.Name = spell.Name;
            viewModel.Level = spell.Level;
            viewModel.School = spell.School;
            viewModel.CastingTime = spell.CastingTime;
            viewModel.Range = spell.Range;
            viewModel.Verbal = spell.Verbal;
            viewModel.Somatic = spell.Somatic;
            viewModel.Materials = spell.Materials;
            viewModel.Duration = spell.Duration;
            viewModel.Ritual = spell.Ritual;
            viewModel.Description = spell.Description; 

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new SpellViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SpellViewModel viewModel)
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

                var success = await _spellRepo.Add(spell);
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

        public async Task<ActionResult> Edit(int id)
        {
            var spell = await _spellRepo.Get(id);
            var viewModel = new SpellViewModel()
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
        public async Task<ActionResult> Edit(int id, SpellViewModel viewModel)
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

            if (await _spellRepo.Update(spell))
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

        public async Task<ActionResult> Delete(int id)
        {
            Spell spell = await _spellRepo.Get(id);

            var viewModel = new SpellViewModel();
            viewModel.Id = spell.Id;
            viewModel.Name = spell.Name;
            viewModel.Level = spell.Level;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, SpellViewModel viewModel)
        {
            bool success = await _spellRepo.Delete(id);

            if (success)
            {
                return RedirectToAction("Index", "Spell");
            } 
            else
            {
                ModelState.AddModelError("", "Unable to delete Spell");
                return View(viewModel);
            }
        }
    }
}