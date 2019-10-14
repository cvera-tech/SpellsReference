using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Api.Models
{
    public class SpellbookCreateRequest
    {
        [Required]
        public string Name { get; set; }
    }
}