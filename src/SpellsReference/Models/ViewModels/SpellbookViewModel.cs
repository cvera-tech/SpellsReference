using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Models.ViewModels
{
    public class SpellbookViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Spell> Spells { get; set; }
    }
}