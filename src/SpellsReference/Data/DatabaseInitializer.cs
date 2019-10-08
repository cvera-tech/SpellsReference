using SpellsReference.Models;
using System.Data.Entity;

namespace SpellsReference.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            // Test Data

            // Users
            var specificFireball = new Spell()
            {
                Name = "Fireball @ Jason's Head",
                Level = 1,
                School = "Fire",
                CastingTime = "1 Second",
                Range = "40 yards",
                Verbal = false,
                Somatic = true,
                Materials = "None",
                Duration = "Instantaneous",
                Ritual = false,
                Description = "Hurls a ball of fire at Jason's head."
            };
            context.Spells.Add(specificFireball);

            context.SaveChanges();
        }
    }
}