using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var viewModel = new SpellListViewModel()
            {
                Spells = _spellRepo.List()
            };
            return View(viewModel);
        }

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
    }
}