using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Models.ViewModels
{
    public class AddSpellToSpellbookViewModel
    {
        public int SpellbookId { get; set; }
        [Display(Name = "Spellbook Name:")]
        public string SpellbookName { get; set; }
        public List<Spell> Spells { get; set; }
    }
}