using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Models
{
    public class Spellbook
    {
        public Spellbook()
        {
            Spells = new List<Spell>();
        }

        public Spellbook(string name) : this()
        {
            Name = name;
        }

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