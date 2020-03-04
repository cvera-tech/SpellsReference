namespace SpellsReferenceCore.Data.Models
{
    public class SpellbookSpell
    {
        public int SpellbookId { get; set; }
        public Spellbook Spellbook { get; set; }

        public int SpellId { get; set; }
        public Spell Spell { get; set; }
    }
}
