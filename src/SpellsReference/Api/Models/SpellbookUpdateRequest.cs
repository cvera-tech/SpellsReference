using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Api.Models
{
    public class SpellbookUpdateRequest
    {
        [Required]
        public string Name { get; set; }
    }
}