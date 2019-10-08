using SpellsReference.Data;
using SpellsReference.Models;
using SpellsReference.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpellsReference.Controllers
{
    public class HomeController : Controller
    {
        private Context context;

        public HomeController()
        {
            context = new Context();
        }

        public ActionResult Index()
        {
            SpellRepository spellRepo = new SpellRepository(context);
            List<Spell> spells = spellRepo.GetSpells();

            return View(spells);
        }
    }
}