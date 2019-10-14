using SpellsReference.Models;

namespace SpellsReference.Api.Models
{
    public class SpellListFilter
    {
        public string Name { get; set; }
        public int? Level { get; set; }
        public SchoolOfMagic? School { get; set; }
    }
}