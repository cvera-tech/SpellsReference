using SpellsReference.Api;
using SpellsReference.Models;
using SpellsReference.Models.ViewModels;
using System.Collections.Generic;

namespace SpellsReference.Data.Repositories
{
    public interface ISpellRepository : IRepository<Spell>, IApiRepository<Spell>
    {
        List<Spell> List(SpellFilterViewModel filter);
    }
}
