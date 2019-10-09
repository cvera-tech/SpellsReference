using SpellsReference.Data;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    [Authorize]
    public class SpellbookController : Controller
    {
        private IContext context;

        public SpellbookController(IContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            SpellbookRepository spellbookRepo = new SpellbookRepository(context);
            List<Spellbook> spellbooks = spellbookRepo.List();

            return View(spellbooks);
        }

        public ActionResult Select(int id)
        {
            SpellbookRepository spellbookRepo = new SpellbookRepository(context);
            Spellbook spellbook = spellbookRepo.Get(id);

            return View(spellbook);
        }
    }
}