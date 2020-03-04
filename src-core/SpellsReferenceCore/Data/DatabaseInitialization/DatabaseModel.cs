using SpellsReferenceCore.Data.Models;
using System.Collections.Generic;

namespace SpellsReferenceCore.Data.DatabaseInitialization
{
    public class DatabaseModel
    {
        public List<Spell> Spells { get; set; }
        public List<Spellbook> Spellbooks { get; set; }
        public List<SpellbookSpell> SpellbookSpells { get;set; }
    }
}
