namespace SpellsReference.Api.Models
{
    public class SpellDeleteResponse
    {
        public bool Success { get; set; }
        public SpellInfo Spell { get; set; }
    }
}