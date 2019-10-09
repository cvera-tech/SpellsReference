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
            List<Spell> spells = spellRepo.GetSpells();

            return View(spells);
        }
    }
}