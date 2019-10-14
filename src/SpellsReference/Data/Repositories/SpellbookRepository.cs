using System.Data.Entity;
using SpellsReference.Data;
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

        public int? Add(Spellbook entity)
        {
            try
            {
                _context.Spellbooks.Add(entity);
                _context.SaveChanges();
                return entity.Id;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int?> AddAsync(Spellbook entity)
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

        public bool RemoveSpellFromSpellbook(int spellbookId, int spellId)
        {
            try
            {
                var spellbook = Get(spellbookId);
                var spell = _spellRepo.Get(spellId);
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

        public bool Delete(int id)
        {
            var goner = new Spellbook() { Id = id };
            _context.Entry(goner).State = EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var spellbook = new Spellbook() { Id = id };
                _context.Spellbooks.Attach(spellbook);
                _context.Spellbooks.Remove(spellbook);
                await _context.SaveChangesAsync();
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

        public async Task<Spellbook> GetAsync(int id)
        {
            return await _context.Spellbooks.Include(sb => sb.Spells).SingleOrDefaultAsync(sb => sb.Id == id);
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

        public async Task<List<Spellbook>> ListAsync()
        {
            var spellbooks = await _context.Spellbooks
                .Include(sb => sb.Spells)
                .ToListAsync();
            return spellbooks;
        }

        public bool Update(Spellbook entity)
        {
            try
            {
                _context.UpdateEntity(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Spellbook entity)
        {
            try
            {
                // Need the old spellbook record to get its spell list
                var spellbook = await _context.Spellbooks
                    .Include(sb => sb.Spells)
                    .SingleOrDefaultAsync(sb => sb.Id == entity.Id);

                // Update the spellbook
                spellbook.Name = entity.Name;
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}