using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpellsReferenceCore.Data.Models
{
    public class SpellbookSpell
    {
        public int SpellbookId { get; set; }
        public int SpellId { get; set; }
        public Spellbook Spellbook { get; set; }
        public Spell Spell { get; set; }
    }
}
