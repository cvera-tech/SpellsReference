namespace SpellsReference.Api.Models
{
    public class SpellCreateResponse
    {
        public bool Success { get; set; }
        public SpellInfo Spell { get; set; }
    }
}