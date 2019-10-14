using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SpellsReference.Api.Models
{
    // Unfortunately, we cannot rely solely on convention to implement adding and removing spells
    // from a spellbook. Rather than creating separate controllers for those actions, I just added
    // routing attributes here. Our API is no longer truly RESTful :(
    [RoutePrefix("api/spellbook")]
    public class SpellbookController : ApiController
    {
        private ISpellbookRepository _spellbookRepo;

        public SpellbookController(ISpellbookRepository spellbookRepo)
        {
            _spellbookRepo = spellbookRepo;
        }

        [Route("{id}")]
        public Task<SpellbookDeleteResponse> Delete(int id)
        {
            return null;
        }

        [Route("")]
        public Task<SpellbookListResponse> Get()
        {
            return null;
        }

        [Route("{id}")]
        public Task<SpellbookDetailsResponse> Get(int id)
        {
            return null;
        }

        [Route("")]
        public Task<SpellbookCreateResponse> Post(SpellbookCreateRequest request)
        {
            return null;
        }

        [Route("{id}")]
        public Task<SpellbookUpdateResponse> Put(int id, SpellbookUpdateRequest request)
        {
            return null;
        }

        [HttpPost]
        [Route("{id}/add")]
        public Task<SpellbookAddSpellResponse> AddSpell(int id, SpellbookAddSpellRequest request)
        {
            return null;
        }

        [HttpPost]
        [Route("{id}/remove")]
        public Task<SpellbookRemoveSpellResponse> RemoveSpell(int id, SpellbookRemoveSpellRequest request)
        {
            return null;
        }
    }
}