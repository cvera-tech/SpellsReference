using SpellsReference.Data;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpellsReference.Repositories
{
    public class SpellRepository
    {
        private Context _context;

        public SpellRepository(Context context)
        {
            _context = context;
        }

        public List<Spell> GetSpells()
        {
            return _context.Spells.ToList();
        }
    }
}