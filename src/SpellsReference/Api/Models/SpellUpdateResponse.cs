namespace SpellsReference.Api.Models
{
    public class SpellUpdateResponse
    {
        public bool Success { get; set; }
        public SpellInfo Spell { get; set; }
    }
}