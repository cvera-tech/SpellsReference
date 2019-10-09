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



    }
}