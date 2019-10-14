namespace SpellsReference.Api.Models
{
    public class SpellbookUpdateResponse
    {
        public bool Success { get; set; }
        public ShortSpellbookInfo Spellbook { get; set; }
    }
}