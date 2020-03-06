using SpellsReferenceCore.Data.Models;
using System;
using System.Collections.Generic;

namespace SpellsReferenceCore.Data.Repositories
{
    public class SpellRepository : ISpellRepository
    {
        private ISpellsReferenceContext _context;

        public SpellRepository(ISpellsReferenceContext context)
        {
            _context = context;
        }

        public int? Add(Spell entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Spell Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Spell> List()
        {
            throw new NotImplementedException();
        }

        public bool Update(Spell entity)
        {
            throw new NotImplementedException();
        }
    }
}
