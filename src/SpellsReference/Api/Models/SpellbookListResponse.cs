using System.Collections.Generic;

namespace SpellsReference.Api.Models
{
    public class SpellbookListResponse
    {
        public List<ISpellbookInfo> Spellbooks { get; set; }

        public SpellbookListResponse()
        {
            Spellbooks = new List<ISpellbookInfo>();
        }
    }
}