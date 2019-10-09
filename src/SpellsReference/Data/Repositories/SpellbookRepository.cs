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
        private ISpellRepository _spellRepo;

        public SpellbookRepository(IContext context, ISpellRepository spellRepo)
        {
            _context = context;
            _spellRepo = spellRepo;
        }

        public int? Add(Spellbook entity)
        {
            throw new NotImplementedException();
        }

        public bool AddSpellToSpellbook(int spellbookId, int spellId)
        {
            try
            {
                var spellbook = Get(spellbookId);
                var spell = _spellRepo.Get(spellId);
                spellbook.Spells.Add(spell);
                _context.UpdateEntity(spellbook);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Spellbook Get(int id)
        {
            return _context.Spellbooks.Include(sb => sb.Spells).SingleOrDefault(sb => sb.Id == id);
        }

        public List<Spell> GetNonmemberSpells(int id)
        {
            var spellbook = _context.Spellbooks
                .Include(sb => sb.Spells)
                .SingleOrDefault(sb => sb.Id == id);
            var memberSpellIds = spellbook.Spells.Select(s => s.Id);
            var nonmemberSpells = _context.Spells
                .Where(s => !memberSpellIds.Contains(s.Id))
                .ToList();

            return nonmemberSpells;
        }

        public List<Spellbook> List()
        {
            return _context.Spellbooks.ToList();
        }

        public bool Update(Spellbook entity)
        {
            throw new NotImplementedException();
        }
    }
}