using SpellsReference.Api.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace SpellsReference.Api
{
    public class SpellbookApiController : ApiController
    {
        public Task<SpellbookDeleteResponse> Delete(SpellbookDeleteRequest request)
        {
            return null;
        }

        public Task<SpellbookListResponse> Get()
        {
            return null;
        }

        public Task<SpellbookDetailsResponse> Get(int id)
        {
            return null;
        }

        public Task<SpellbookUpdateResponse> Patch(SpellbookUpdateRequest request)
        {
            return null;
        }

        public Task<SpellbookListResponse> Post(SpellbookListRequest request)
        {
            return null;
        }

        public Task<SpellbookCreateResponse> Post(SpellbookCreateRequest request)
        {
            return null;
        }
    }
}