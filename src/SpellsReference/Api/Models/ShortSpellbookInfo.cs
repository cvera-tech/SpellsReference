namespace SpellsReference.Api.Models
{
    public class ShortSpellbookInfo : ISpellbookInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSpells { get; set; }
    }
}