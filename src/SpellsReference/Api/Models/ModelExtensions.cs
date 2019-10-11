using SpellsReference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}