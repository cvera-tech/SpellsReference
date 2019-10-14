using SpellsReference.Api;
using SpellsReference.Models;
using System.Collections.Generic;

namespace SpellsReference.Data.Repositories
{
    public interface ISpellbookRepository : IRepository<Spellbook>, IApiRepository<Spellbook>
    {
        List<Spell> GetNonmemberSpells(int id);
        bool AddSpellToSpellbook(int spellbookId, int spellId);
        bool RemoveSpellFromSpellbook(int spellbookId, int spellId);
    }
}
