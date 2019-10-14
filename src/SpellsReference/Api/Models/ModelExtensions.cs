using SpellsReference.Models;
using System.Linq;

namespace SpellsReference.Api.Models
{
    public static class ModelExtensions
    {
        public static SpellInfo GetInfo(this Spell spell)
        {
            var info = new SpellInfo()
            {
                Id = spell.Id,
                Name = spell.Name,
                Level = spell.Level,
                School = spell.School.ToString(),
                CastingTime = spell.CastingTime,
                Range = spell.Range,
                Verbal = spell.Verbal,
                Somatic = spell.Somatic,
                Materials = spell.Materials,
                Duration = spell.Duration,
                Ritual = spell.Ritual,
                Description = spell.Description
            };
            return info;
        }

        public static SpellbookInfo GetInfo(this Spellbook spellbook)
        {
            var info = new SpellbookInfo()
            {
                Id = spellbook.Id,
                Name = spellbook.Name,
                NumberOfSpells = spellbook.Spells.Count(),
                Spells = spellbook.Spells.Select(s => s.GetInfo()).ToList()
            };
            return info;
        }

        public static ShortSpellbookInfo GetShortInfo(this Spellbook spellbook)
        {
            var info = new ShortSpellbookInfo()
            {
                Id = spellbook.Id,
                Name = spellbook.Name,
                NumberOfSpells = spellbook.Spells.Count()
            };
            return info;
        }
    }
}