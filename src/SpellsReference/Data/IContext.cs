using System.Data.Entity;
using SpellsReference.Models;

namespace SpellsReference.Data
{
    public interface IContext
    {
        DbSet<Spellbook> Spellbooks { get; set; }
        DbSet<Spell> Spells { get; set; }
        DbSet<User> Users { get; set; }
    }
}