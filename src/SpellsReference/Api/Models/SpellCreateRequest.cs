using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Api.Models
{
    public class SpellCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int? Level { get; set; }

        [Required]
        public string School { get; set; }

        [Required]
        public string CastingTime { get; set; }

        [Required]
        public string Range { get; set; }

        [Required]
        public bool? Verbal { get; set; }

        [Required]
        public bool? Somatic { get; set; }

        public string Materials { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public bool? Ritual { get; set; }

        [Required]
        public string Description { get; set; }

        // We can add extra things here, such as whether or not 
        // this spell should be added to a spellbook after creation.
    }
}