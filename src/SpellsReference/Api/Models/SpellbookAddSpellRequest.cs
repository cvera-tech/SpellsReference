using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Api.Models
{
    public class SpellbookAddSpellRequest
    {
        [Required]
        public int? SpellId { get; set; }
    }
}