namespace SpellsReference.Api.Models
{
    public class SpellDetailsResponse
    {
        public SpellInfo Spell { get; set; }

        // We can add other information to this response, such as
        // spellbooks that this spell is part of.
    }
}