using SpellsReference.Models;
using System.Collections.Generic;

namespace SpellsReference.Api.Models
{
    public class SpellListResponse
    {
        public List<SpellInfo> Spells { get; set; }

        public SpellListResponse()
        {
            Spells = new List<SpellInfo>();
        }
    }
}