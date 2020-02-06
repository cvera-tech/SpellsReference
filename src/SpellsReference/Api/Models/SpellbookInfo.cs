using System.Collections.Generic;

namespace SpellsReference.Api.Models
{
    public class SpellbookInfo : ISpellbookInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSpells { get; set; }
        public List<SpellInfo> Spells { get; set; }

        public SpellbookInfo()
        {
            Spells = new List<SpellInfo>();
        }
    }
}