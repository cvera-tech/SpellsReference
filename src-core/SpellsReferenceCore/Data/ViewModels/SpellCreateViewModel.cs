using SpellsReferenceCore.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace SpellsReferenceCore.Data.ViewModels
{
    public class SpellCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public SchoolOfMagic School { get; set; }
        [Required, Display(Name = "Casting Time")]
        public string CastingTime { get; set; }
        [Required]
        public string Range { get; set; }
        [Required]
        public bool Verbal { get; set; }
        [Required]
        public bool Somatic { get; set; }
        public string Materials { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public bool Ritual { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
