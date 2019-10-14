using SpellsReference.Api;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpellsReference.Data.Repositories
{
    public interface ISpellbookRepository : IRepository<Spellbook>, IApiRepository<Spellbook>
    {
        List<Spell> GetNonmemberSpells(int id);
        bool AddSpellToSpellbook(int spellbookId, int spellId);
        bool RemoveSpellFromSpellbook(int spellbookId, int spellId);

        Task<bool> AddSpellAsync(int spellbookId, int spellId);
        Task<bool> RemoveSpellAsync(int spellbookId, int spellId);
    }
}
