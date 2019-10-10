using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SpellsReference.Models.ViewModels
{
    public class SpellListViewModel
    {
        public bool Filtered { get; set; }
        public List<Spell> Spells { get; set; }
    }
}