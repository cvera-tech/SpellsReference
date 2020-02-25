using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpellsReferenceCore.Controllers
{
    public class SpellController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}