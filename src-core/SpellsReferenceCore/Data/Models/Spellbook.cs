using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsReferenceCore.Data.Models
{
    public class Spellbook
    {
        public Spellbook()
        {
            SpellbookSpells = new List<SpellbookSpell>();
        }

        public Spellbook(string name) : this()
        {
            Name = name;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // EF Core has no built-in support for many-to-many relationships 
        // outside of modeling a bridge table.
        public List<SpellbookSpell> SpellbookSpells { get; set; }
    }
}