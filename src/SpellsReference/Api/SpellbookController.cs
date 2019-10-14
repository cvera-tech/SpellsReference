using SpellsReference.Api.Models;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SpellsReference.Api
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
        public async Task<SpellbookListResponse> Get()
        {
            var spellbooks = await _spellbookRepo.ListAsync();
            var response = new SpellbookListResponse();
            spellbooks.ForEach(sb => response.Spellbooks.Add(sb.GetShortInfo()));
            return response;
        }

        [Route("{id}")]
        public async Task<SpellbookDetailsResponse> Get(int id)
        {
            var spellbook = await _spellbookRepo.GetAsync(id);
            var response = new SpellbookDetailsResponse()
            {
                Spellbook = spellbook.GetInfo()
            };
            return response;
        }

        [Route("")]
        public async Task<SpellbookCreateResponse> Post(SpellbookCreateRequest request)
        {
            var response = new SpellbookCreateResponse() { Success = false };
            if (ModelState.IsValid)
            {
                var spellbook = new Spellbook()
                {
                    Name = request.Name
                };
                int? spellbookId = await _spellbookRepo.AddAsync(spellbook);
                if (spellbookId.HasValue)
                {
                    response.Success = true;
                    response.Spellbook = spellbook.GetShortInfo();
                }
            }
            return response;
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