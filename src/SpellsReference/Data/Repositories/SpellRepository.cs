using SpellsReference.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SpellsReference.Data.Repositories
{
    public class SpellRepository : ISpellRepository
    {
        private IContext _context;

        public SpellRepository(IContext context)
        {
            _context = context;
        }

        public async Task<int?> Add(Spell entity)
        {
            try
            {
                _context.Spells.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch
            {
                return null;
            }
        }

        public Task<Spell> Get(int id)
        {
            return _context.Spells.FindAsync(id);
        }

        public Task<List<Spell>> List()
        {
            return _context.Spells.ToListAsync();
        }

        public async Task<bool> Update(Spell entity)
        {
            try
            {
                _context.UpdateEntity(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var goner = new Spell() { Id = id };
            _context.Entry(goner).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}