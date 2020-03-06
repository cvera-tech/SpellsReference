using Microsoft.EntityFrameworkCore;
using SpellsReferenceCore.Data.Models;

namespace SpellsReferenceCore.Data
{
    public interface ISpellsReferenceContext
    {
        DbSet<Spell> Spells { get; set; }
        DbSet<Spellbook> Spellbooks { get; set; }
        DbSet<SpellbookSpell> SpellbookSpells { get; set; }
        //DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
