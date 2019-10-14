namespace SpellsReference.Api.Models
{
    public interface ISpellbookInfo
    {
        int Id { get; set; }
        string Name { get; set; }
        int NumberOfSpells { get; set; }
    }
}