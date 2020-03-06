using SpellsReferenceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpellsReferenceCore.Data.Repositories
{
    public interface ISpellRepository : IRepository<Spell>
    {
        //List<Spell> List(SpellFilterViewModel filter);
        //Task<List<Spell>> ListAsync(SpellListFilter filter);
    }
}
