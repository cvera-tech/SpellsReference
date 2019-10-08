using SpellsReference.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SpellsReference.Data
{
    public class Context : DbContext, IContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Spellbook> Spellbooks { get; set; }
        public DbSet<Spell> Spells { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}