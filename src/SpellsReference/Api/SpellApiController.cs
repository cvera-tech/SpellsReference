using System.Threading.Tasks;
using System.Web.Http;
using SpellsReference.Api.Models;

namespace SpellsReference.Api
{
    public class SpellApiController : ApiController
    {
        public Task<SpellDeleteResponse> Delete(SpellDeleteRequest request)
        {
            return null;
        }

        public Task<SpellListResponse> Get()
        {
            return null;
        }

        public Task<SpellDetailsResponse> Get(int id)
        {
            return null;
        }

        public Task<SpellUpdateResponse> Patch(SpellUpdateRequest request)
        {
            return null;
        }

        public Task<SpellListResponse> Post(SpellListRequest request)
        {
            return null;
        }

        public Task<SpellCreateResponse> Post(SpellCreateRequest request)
        {
            return null;
        }
    }
}