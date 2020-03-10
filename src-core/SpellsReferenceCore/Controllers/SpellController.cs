using Microsoft.AspNetCore.Mvc;
using SpellsReferenceCore.Data.Models;
using SpellsReferenceCore.Data.Repositories;
using SpellsReferenceCore.Data.ViewModels;

namespace SpellsReferenceCore.Controllers
{
    public class SpellController : Controller
    {
        private readonly ISpellRepository _spellRepo;

        public SpellController(ISpellRepository spellRepo)
        {
            _spellRepo = spellRepo;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new SpellCreateViewModel();
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Create(SpellCreateViewModel viewModel)
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
                    ModelState.AddModelError("", "Unable to create spell.");
                }
            }

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var spell = _spellRepo.Get(id);
            var viewModel = new SpellDetailsViewModel()
            {
                Id = id,
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

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new SpellListViewModel()
            {
                Spells = _spellRepo.List()
            };
            return View(viewModel);
        }

    }
}