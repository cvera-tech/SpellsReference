namespace SpellsReference.Api.Models
{
    public class SpellbookDeleteResponse
    {
        public bool Success { get; set; }
        public ShortSpellbookInfo Spellbook { get; set; }
    }
}