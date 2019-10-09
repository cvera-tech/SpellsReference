using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Models.ViewModels
{
    public class EditSpellViewModel
    {
        [Required]
        public string Name { get; set; }

        public int Level { get; set; }

        public SchoolOfMagic School { get; set; }

        [Required]
        [Display(Name = "Casting Time")]
        public string CastingTime { get; set; }

        [Required]
        public string Range { get; set; }

        public bool Verbal { get; set; }

        public bool Somatic { get; set; }

        public string Materials { get; set; } // Could make a Many:Many relationship and a seperate table.

        [Required]
        public string Duration { get; set; }

        public bool Ritual { get; set; }

        [Required]
        public string Description { get; set; }
    }
}