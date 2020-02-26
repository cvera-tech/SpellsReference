using SpellsReferenceCore.Data.Models;
using System.Collections.Generic;

namespace SpellsReferenceCore.Data
{
    public class SeedData
    {
        public SeedData()
        {
            var fireball = new Spell()
            {
                Name = "Fireball",
                Level = 3,
                School = SchoolOfMagic.Evocation,
                CastingTime = "1 action",
                Range = "150 feet",
                Verbal = false,
                Somatic = true,
                Materials = "Bat Guano, Sulfur",
                Duration = "Instantaneous",
                Ritual = false,
                Description = "A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame. Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw. A target takes 8d6 fire damage on a failed save, or half as much damage on a successful one."
            };
            var animateDead = new Spell()
            {
                Name = "Animate Dead",
                Level = 3,
                School = SchoolOfMagic.Necromancy,
                CastingTime = "60 Seconds",
                Range = "10 feet",
                Verbal = true,
                Somatic = true,
                Materials = "Flesh, Blood, Bone",
                Duration = "Instantaneous",
                Ritual = false,
                Description = "This spell creates an undead servant. Choose a pile of bones or a corpse of a Medium or Small humanoid within range. Your spell imbues the target with a foul mimicry of life, raising it as an undead creature. The target becomes a skeleton if you chose bones or a zombie if you chose a corpse."
            };
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
                Description = "A spectral, floating hand appears at a point you choose within range. The hand lasts for the duration or until you dismiss it as an action. The hand vanishes if it is ever more than 30 feet away from you or if you cast this spell again."
            };
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
                Description = "Three illusory duplicates of yourself appear in your space. Until the spell ends, the duplicates move with you and mimic your actions, shifting position so it's impossible to track which image is real. You can use your action to dismiss the illusory duplicates."
            };
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
                Description = "You attempt to interrupt a creature in the process of casting a spell. If the creature is casting a spell of 3rd level or lower, its spell fails and has no effect. If it is casting a spell of 4th level or higher, make an ability check using your spellcasting ability. The DC equals 10 + the spell's level. On a success, the creature's spell fails and has no effect."
            };
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
                Description = "You briefly stop the flow of time for everyone but yourself. No time passes for other creatures, while you take 1d4 + 1 turns in a row, during which you can use actions and move as normal."
            };
            var bless = new Spell()
            {
                Name = "Bless",
                Level = 1,
                School = SchoolOfMagic.Enchantment,
                CastingTime = "1 action",
                Range = "30 feet",
                Verbal = true,
                Somatic = true,
                Materials = "Holy Water",
                Duration = "Concentration, up to 1 minute",
                Ritual = false,
                Description = "You bless up to three creatures of your choice within range."
            };
            var foresight = new Spell()
            {
                Name = "Foresight",
                Level = 9,
                School = SchoolOfMagic.Divination,
                CastingTime = "1 minute",
                Range = "Touch",
                Verbal = true,
                Somatic = true,
                Materials = "Hummingbird Feather",
                Duration = "8 Hours",
                Ritual = false,
                Description = "You touch a willing creature and bestow a limited ability to see into the immediate future. For the duration, the target can't be surprised and has advantage on attack rolls, ability checks, and saving throws. Additionally, other creatures have disadvantage on attack rolls against the target for the duration."
            };
            var detectMagic = new Spell()
            {
                Name = "Detect Magic",
                Level = 1,
                School = SchoolOfMagic.Divination,
                CastingTime = "1 action",
                Range = "30 feet",
                Verbal = true,
                Somatic = true,
                Materials = "None",
                Duration = "10 minutes",
                Ritual = true,
                Description = "For the duration, you sense the presence of magic within 30 feet of you. If you sense magic in this way, you can use your action to see a faint aura around any visible creature or object in the area that bears magic, and you learn its school of magic, if any."
            };
            var circleOfDeath = new Spell()
            {
                Name = "Circle of Death",
                Level = 6,
                School = SchoolOfMagic.Necromancy,
                CastingTime = "1 action",
                Range = "150 feet",
                Verbal = true,
                Somatic = true,
                Materials = "Powder of a crushed black pearl",
                Duration = "Instantaneous",
                Ritual = false,
                Description = "A sphere of negative energy ripples out in a 60-foot- radius sphere from a point within range. Each creature in that area must make a Constitution saving throw. A target takes 8d6 necrotic damage on a failed save, or half as much damage on a successful one."
            };
            var guidingBolt = new Spell()
            {
                Name = "Guiding Bolt",
                Level = 1,
                School = SchoolOfMagic.Evocation,
                CastingTime = "1 action",
                Range = "120 feet",
                Verbal = true,
                Somatic = true,
                Materials = "None",
                Duration = "1 round",
                Ritual = false,
                Description = "A flash of light streaks toward a creature of your choice within range. Make a ranged spell attack against the target."
            };
            var sleep = new Spell()
            {
                Name = "Sleep",
                Level = 1,
                School = SchoolOfMagic.Enchantment,
                CastingTime = "1 action",
                Range = "90 feet",
                Verbal = true,
                Somatic = true,
                Materials = "Sand",
                Duration = "1 Minute",
                Ritual = false,
                Description = "This spell sends creatures into a magical slumber. "
            };
            var stormOfVengeance = new Spell()
            {
                Name = "Storm of Vengeance",
                Level = 9,
                School = SchoolOfMagic.Conjuration,
                CastingTime = "1 action",
                Range = "Sight",
                Verbal = true,
                Somatic = true,
                Materials = "None",
                Duration = "Concentration, up to 1 minute",
                Ritual = false,
                Description = "A churning storm cloud forms, centered on a point you can see and spreading to a radius of 360 feet. Lightning flashes in the area, thunder booms, and strong winds roar."
            };
            var enlargeReduce = new Spell()
            {
                Name = "Enlarge/Reduce",
                Level = 2,
                School = SchoolOfMagic.Transmutation,
                CastingTime = "1 action",
                Range = "30 feet",
                Verbal = true,
                Somatic = true,
                Materials = "Powdered Iron",
                Duration = "Concentration, up to 1 minute",
                Ritual = false,
                Description = "You cause a creature or an object you can see within range to grow larger or smaller for the duration. Choose either a creature or an object that is neither worn nor carried."
            };
            Spells = new List<Spell>()
            {
                fireball, 
                animateDead,
                mageHand,
                mirrorImage,
                counterspell,
                timeStop,
                bless,
                foresight,
                detectMagic,
                circleOfDeath,
                guidingBolt,
                sleep,
                stormOfVengeance,
                enlargeReduce
            };

            var spellbook1 = new Spellbook() { Name = "Arcane Magics" };
            spellbook1.Spells.AddRange(new Spell[] { fireball, mageHand, mirrorImage, counterspell });
            var spellbook2 = new Spellbook() { Name = "Necronomicon" };
            spellbook2.Spells.AddRange(new Spell[] { animateDead });
            var spellbook3 = new Spellbook() { Name = "Annette's Special" };
            spellbook3.Spells.AddRange(new Spell[] { timeStop, mageHand, stormOfVengeance });
            Spellbooks = new List<Spellbook>() { spellbook1, spellbook2, spellbook3 };

            SpellbookSpells = new List<SpellbookSpell>();
        }
        public List<Spell> Spells { get; private set; }
        public List<Spellbook> Spellbooks { get; private set; }
        public List<SpellbookSpell> SpellbookSpells { get; private set; }
    }
}
