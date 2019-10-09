using SpellsReference.Models;
using System.Data.Entity;

namespace SpellsReference.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            // Users
            var user1 = new User()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
                HashedPassword = "password"
            };
            context.Users.Add(user1);
            var user2 = new User()
            {
                FirstName = "Mo",
                LastName = "Salam",
                Email = "hufflepuff4life@gmail.com",
                HashedPassword = "password"
            };
            context.Users.Add(user2);
            var user3 = new User()
            {
                FirstName = "Gandalf",
                LastName = "the Gray",
                Email = "hobbits2isengard@gmail.com",
                HashedPassword = "password"
            };
            context.Users.Add(user3);

            // Spells
            var fireball = new Spell()
            {
                Name = "Fireball",
                Level = 3,
                School = SchoolOfMagic.Evocation,
                CastingTime = "1 action",
                Range = "150 feet",
                Verbal = false,
                Somatic = true,
                Materials = "Sulfur",
                Duration = "Instantaneous",
                Ritual = false,
                Description = "Hurls a ball of fire at the target."
            };
            context.Spells.Add(fireball);
            var animateDead = new Spell()
            {
                Name = "Animate Dead",
                Level = 3,
                School = SchoolOfMagic.Necromancy,
                CastingTime = "60 Seconds",
                Range = "10 feet",
                Verbal = true,
                Somatic = true,
                Materials = "Corpse, something sinister",
                Duration = "Instantaneous",
                Ritual = false,
                Description = "Command a skeleton or corpse for up to the next 24 hours."
            };
            context.Spells.Add(animateDead);
            var mageHand = new Spell()
            {
                Name = "Mage Hand",
                Level = 0,
                School = SchoolOfMagic.Conjuration,
                CastingTime = "1 action",
                Range = "30 feet",
                Verbal = true,
                Somatic = true,
                Materials = "None",
                Duration = "1 Minute",
                Ritual = false,
                Description = "Summon a hand to interact with things for the next minute."
            };
            context.Spells.Add(mageHand);
            var mirrorImage = new Spell()
            {
                Name = "Mirror Image",
                Level = 2,
                School = SchoolOfMagic.Illusion,
                CastingTime = "1 action",
                Range = "Self",
                Verbal = true,
                Somatic = true,
                Materials = "None",
                Duration = "1 Minute",
                Ritual = false,
                Description = "Duplicate an image of yourself where you stand."
            };
            context.Spells.Add(mirrorImage);
            var counterspell = new Spell()
            {
                Name = "Counterspell",
                Level = 3,
                School = SchoolOfMagic.Abjuration,
                CastingTime = "1 reaction",
                Range = "60 feet",
                Verbal = false,
                Somatic = true,
                Materials = "None",
                Duration = "Instantaneous",
                Ritual = false,
                Description = "Interrupt a creature casting a spell."
            };
            context.Spells.Add(counterspell);
            var timeStop = new Spell()
            {
                Name = "Time Stop",
                Level = 9,
                School = SchoolOfMagic.Transmutation,
                CastingTime = "1 action",
                Range = "Self",
                Verbal = true,
                Somatic = false,
                Materials = "None",
                Duration = "Instantaneous",
                Ritual = false,
                Description = "Stop time around you, lasting for 2 minutes or until you interact with something around you."
            };
            context.Spells.Add(timeStop);

            // Spellbooks
            var spellbook1 = new Spellbook()
            {
                Name = "Arcane Magics",
            };
            spellbook1.Spells.Add(fireball);
            spellbook1.Spells.Add(mageHand);
            spellbook1.Spells.Add(mirrorImage);
            spellbook1.Spells.Add(counterspell);
            context.Spellbooks.Add(spellbook1);
            var spellbook2 = new Spellbook()
            {
                Name = "Necronomicon",
            };
            spellbook2.Spells.Add(animateDead);
            context.Spellbooks.Add(spellbook2);
            var spellbook3 = new Spellbook()
            {
                Name = "Overpowered A.F.",
            };
            spellbook3.Spells.Add(timeStop);
            spellbook3.Spells.Add(mageHand);
            context.Spellbooks.Add(spellbook3);

            context.SaveChanges();
        }
    }
}