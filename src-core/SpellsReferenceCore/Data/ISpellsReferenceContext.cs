using Microsoft.EntityFrameworkCore;
using SpellsReferenceCore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpellsReferenceCore.Data
{
    interface ISpellsReferenceContext
    {
        DbSet<Spellbook> Spellbooks { get; set; }
        DbSet<Spell> Spells { get; set; }
        //DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
