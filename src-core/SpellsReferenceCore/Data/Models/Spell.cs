using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsReferenceCore.Data.Models
{
    public class Spell
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Level { get; set; }
        [Required]
        public SchoolOfMagic School { get; set; }
        [Required]
        public string CastingTime { get; set; }
        [Required]
        public string Range { get; set; }
        [Required]
        public bool Verbal { get; set; }
        [Required]
        public bool Somatic { get; set; }
        public string Materials { get; set; } // Could make a Many:Many relationship and a seperate table.
        [Required]
        public string Duration { get; set; }
        [Required]
        public bool Ritual { get; set; }
        [Required]
        public string Description { get; set; }

        // EF Core has no built-in support for many-to-many relationships 
        // outside of modeling a bridge table.
        public List<SpellbookSpell> SpellbookSpells { get; set; }
    }
}
