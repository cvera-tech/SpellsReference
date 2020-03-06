using SpellsReferenceCore.Data.Models;
using System.Collections.Generic;

namespace SpellsReferenceCore.Data.Repositories
{
    public interface ISpellbookRepository : IRepository<Spellbook>
    {
        List<Spell> GetNonmemberSpells(int id);
        bool AddSpellToSpellbook(int spellbookId, int spellId);
        bool RemoveSpellFromSpellbook(int spellbookId, int spellId);

        //Task<bool> AddSpellAsync(int spellbookId, int spellId);
        //Task<bool> ExistsAsync(int id);
        //Task<List<Spell>> GetNonmemberSpellsAsync(int spellbookId);
        //Task<Spellbook> GetSimpleAsync(int spellbookId);
        //Task<bool> RemoveSpellAsync(int spellbookId, int spellId);
    }
}
