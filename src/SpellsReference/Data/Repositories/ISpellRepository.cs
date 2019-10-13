using SpellsReference.Api;
using SpellsReference.Api.Models;
using SpellsReference.Models;
using SpellsReference.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpellsReference.Data.Repositories
{
    public interface ISpellRepository : IRepository<Spell>, IApiRepository<Spell>
    {
        List<Spell> List(SpellFilterViewModel filter);
        Task<List<Spell>> ListAsync(SpellListFilter filter);
    }
}
