using System.Collections.Generic;

namespace SpellsReference.Models.ViewModels
{
    public class AddSpellToSpellbookViewModel
    {
        public int SpellbookId { get; set; }
        public string SpellbookName { get; set; }
        public List<Spell> Spells { get; set; }
    }
}