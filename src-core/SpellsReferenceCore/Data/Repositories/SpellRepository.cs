using SpellsReferenceCore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpellsReferenceCore.Data.Repositories
{
    public class SpellRepository : ISpellRepository
    {
        private readonly ISpellsReferenceContext _context;

        public SpellRepository(ISpellsReferenceContext context)
        {
            _context = context;
        }

        public int? Add(Spell entity)
        {
            try
            {
                _context.Spells.Add(entity);
                _context.SaveChanges();
                return entity.Id;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Spell Get(int id)
        {
            return _context.Spells.Find(id);
        }

        public List<Spell> List()
        {
            return _context.Spells.ToList();
        }

        public bool Update(Spell entity)
        {
            throw new NotImplementedException();
        }
    }
}
