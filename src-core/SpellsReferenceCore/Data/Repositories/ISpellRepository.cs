using SpellsReferenceCore.Data.Models;

namespace SpellsReferenceCore.Data.Repositories
{
    public interface ISpellRepository : IRepository<Spell>
    {
        //List<Spell> List(SpellFilterViewModel filter);
        //Task<List<Spell>> ListAsync(SpellListFilter filter);
    }
}
