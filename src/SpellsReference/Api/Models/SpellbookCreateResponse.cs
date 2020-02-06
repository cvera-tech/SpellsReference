namespace SpellsReference.Api.Models
{
    public class SpellbookCreateResponse
    {
        public bool Success { get; set; }
        public ShortSpellbookInfo Spellbook { get; set; }
    }
}