using SpellsReference.Data;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SpellsReference.Data.Repositories
{
    public class SpellRepository : ISpellRepository
    {
        private IContext _context;

        public SpellRepository(IContext context)
        {
            _context = context;
        }

        public int? Add(Spell entity)
        {
            throw new NotImplementedException();
        }

        public Spell Get(int id)
        {
            return _context.Spells.SingleOrDefault(s => s.Id == id);
        }

        public List<Spell> GetSpells()
        {
            return _context.Spells.ToList();
        }

        public List<Spell> List()
        {
            return _context.Spells.ToList();
        }
    }
}