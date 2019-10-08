using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Models
{
    public class Spellbook
    {
        public Spellbook()
        {
            List<Spell> Spells = new List<Spell>();
        }

        public Spellbook(string name)
        {
            Name = name;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Spell> Spells { get; set; }

        // addSpell()

        // removeSpell()

        // containsSpell()

        // compareTo()

        // equals()

        // toString()
    }
}