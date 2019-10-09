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
        private IContext context;

        public SpellController(IContext context)
        {
            this.context = context;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            SpellRepository spellRepo = new SpellRepository(context);
            List<Spell> spells = spellRepo.List();

            return View(spells);
        }

        // Selects a single spell from a list of spells. This might later be moved 
        // to a functionality from spellbook. The Spell Edit and Delete will be tied into this view. 
        // Also, maybe [Authorize], not sure.
        [AllowAnonymous]
        public ActionResult Select(int id)
        {
            SpellRepository spellRepo = new SpellRepository(context);
            Spell spell = spellRepo.Get(id);

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