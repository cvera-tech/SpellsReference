using SpellsReference.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpellsReference.Data.Repositories
{
    public interface ISpellbookRepository : IRepository<Spellbook>
    {
        Task<List<Spell>> GetNonmemberSpells(int id);
        Task<bool> AddSpellToSpellbook(int spellbookId, int spellId);
        Task<bool> RemoveSpellFromSpellbook(int spellbookId, int spellId);
    }
}
