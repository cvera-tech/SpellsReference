using System.Data.Entity;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

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

        public async Task<int?> Add(Spellbook entity)
        {
            try
            {
                _context.Spellbooks.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AddSpellToSpellbook(int spellbookId, int spellId)
        {
            try
            {
                var spellbook = await Get(spellbookId);
                var spell = await _spellRepo.Get(spellId);
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

        public async Task<bool> RemoveSpellFromSpellbook(int spellbookId, int spellId)
        {
            try
            {
                var spellbook = await Get(spellbookId);
                var spell = await _spellRepo.Get(spellId);
                spellbook.Spells.Remove(spell);
                _context.UpdateEntity(spellbook);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<Spellbook> Get(int id)
        {
            return _context.Spellbooks.Include(sb => sb.Spells).FirstOrDefaultAsync(sb => sb.Id == id); //.Include(sb => sb.Spells);
        }

        public Task<List<Spell>> GetNonmemberSpells(int id)
        {
            var spellbook = _context.Spellbooks
                .Include(sb => sb.Spells)
                .SingleOrDefault(sb => sb.Id == id);
            var memberSpellIds = spellbook.Spells.Select(s => s.Id);
            var nonmemberSpells = _context.Spells
                .Where(s => !memberSpellIds.Contains(s.Id))
                .ToListAsync();

            return nonmemberSpells;
        }

        public Task<List<Spellbook>> List()
        {
            return _context.Spellbooks.ToListAsync();
        }

        public Task<bool> Update(Spellbook entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var goner = new Spellbook() { Id = id };
            _context.Entry(goner).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}