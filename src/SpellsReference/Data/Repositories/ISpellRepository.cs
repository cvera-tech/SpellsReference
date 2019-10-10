using SpellsReference.Models;
using SpellsReference.Models.ViewModels;
using System.Collections.Generic;

namespace SpellsReference.Data.Repositories
{
    public interface ISpellRepository : IRepository<Spell>
    {
        List<Spell> ListByLevel(int level);
        List<Spell> ListBySchool(SchoolOfMagic school);
        List<Spell> List(SpellFilterViewModel filter);
    }
}
