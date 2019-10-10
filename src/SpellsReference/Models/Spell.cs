using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Models
{
    public class Spell
    {
        public Spell() { }

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

        public List<Spellbook> Spellbooks { get; set; }

        // compareTo()

        // equals()

        //toString()
    }
}