using System.Data.Entity;
using SpellsReference.Data;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SpellsReference.Data.Repositories
{
    public class SpellbookRepository : ISpellbookRepository
    {
        private IContext _context;

        public SpellbookRepository(IContext context)
        {
            _context = context;
        }

        public int? Add(Spellbook entity)
        {
            throw new NotImplementedException();
        }

        public Spellbook Get(int id)
        {
            return _context.Spellbooks.Include(sb => sb.Spells).SingleOrDefault(sb => sb.Id == id);
        }

        public List<Spellbook> List()
        {
            return _context.Spellbooks.ToList();
        }
    }
}