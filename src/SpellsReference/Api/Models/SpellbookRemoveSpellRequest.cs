using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Api.Models
{
    public class SpellbookRemoveSpellRequest
    {
        [Required]
        public int? SpellId { get; set; }
    }
}