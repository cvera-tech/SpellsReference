using SpellsReference.Models;

namespace SpellsReference.Data.Repositories
{
    public interface ISpellRepository : IRepository<Spell>
    {
        bool Update(Spell entity);
    }
}
