using SpellsReference.Api.Models;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<SpellbookDeleteResponse> Delete(int id)
        {
            var response = new SpellbookDeleteResponse() { Success = false };
            var spellbook = await _spellbookRepo.GetAsync(id);
            var spellbookInfo = spellbook.GetShortInfo();
            if (await _spellbookRepo.DeleteAsync(id))
            {
                response.Spellbook = spellbookInfo;
            }
            return response;
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

        /// <summary>
        /// Attempts to create a new spellbook.
        /// 
        /// ROUTE
        /// "api/spellbook"
        /// 
        /// REQUEST BODY:
        /// {
        ///     "name": `string`
        /// }
        /// 
        /// RESPONSE:
        /// If success:
        ///     Status Code: 201 (CREATED)
        ///     Location: URI to the spellbook details
        ///     BODY:
        ///         {
        ///             "id": `int`,
        ///             "name": `string`,
        ///             "numberOfSpells": `int`
        ///         }
        ///     
        /// If unable to add to database:
        ///     Status Code: 500 (INTERNAL SERVER ERROR)
        ///     
        /// If model state is invalid:
        ///     Status Code: 400 (BAD REQUEST)
        ///     BODY:
        ///         {
        ///             "message": `string`,
        ///             "modelState": {
        ///                 "request.Name": [`string`, . . . ]
        ///             }
        ///         }
        /// </summary>
        /// <param name="request">The request body.</param>
        /// <returns>The appropriate HTTPActionResult.</returns>
        [Route("")]
        public async Task<IHttpActionResult> Post(SpellbookCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                var spellbook = new Spellbook()
                {
                    Name = request.Name
                };
                int? spellbookId = await _spellbookRepo.AddAsync(spellbook);
                if (spellbookId.HasValue)
                {
                    var url = Url.Link("DefaultApi", new { controller = "Spellbook", id = spellbookId.Value });
                    var info = spellbook.GetShortInfo();
                    return Created(url, info);
                }
                return InternalServerError();
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Attempts to update a spellbook with the given ID.
        /// 
        /// ROUTE
        /// "api/spellbook/{id}"
        /// 
        /// REQUEST BODY:
        /// {
        ///     "name": `string`
        /// }
        /// 
        /// RESPONSE:
        /// If success:
        ///     Status Code: 204 (NO CONTENT)
        ///     
        /// If unable to add to database:
        ///     Status Code: 500 (INTERNAL SERVER ERROR)
        ///     
        /// If model state is invalid:
        ///     Status Code: 400 (BAD REQUEST)
        ///         {
        ///             "message": `string`,
        ///             "modelState": {
        ///                 "request.Name": [`string`, . . . ]
        ///             }
        ///         }
        /// </summary>
        /// <param name="request">The request body.</param>
        /// <returns>The appropriate HTTPActionResult.</returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, SpellbookUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                var spellbook = new Spellbook()
                {
                    Id = id,
                    Name = request.Name
                };
                if (await _spellbookRepo.UpdateAsync(spellbook))
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                return InternalServerError();
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Attempts to add a spell to the spellbook with the given ID.
        /// 
        /// ROUTE
        /// "api/spellbook/{id}/add"
        /// 
        /// REQUEST BODY:
        /// {
        ///     "spellId": `int`
        /// }
        /// 
        /// RESPONSE:
        /// If success:
        ///     Status Code: 201 (CREATED)
        ///     Location: URI to the spellbook details
        ///     
        /// If unable to add spell to spellbook:
        ///     Status Code: 500 (INTERNAL SERVER ERROR)
        ///     
        /// If model state is invalid:
        ///     Status Code: 400 (BAD REQUEST)
        ///         {
        ///             "message": `string`,
        ///             "modelState": {
        ///                 "request.Name": [`string`, . . . ]
        ///             }
        ///         }
        /// </summary>
        /// <param name="id">The spellbook's ID.</param>
        /// <param name="request">The request body.</param>
        /// <returns>The appropriate HTTPActionResult.</returns>
        [HttpPost]
        [Route("{id}/add")]
        public async Task<IHttpActionResult> AddSpell(int id, SpellbookAddSpellRequest request)
        {
            if (ModelState.IsValid)
            {
                if (await _spellbookRepo.AddSpellAsync(id, request.SpellId.Value))
                {
                    var url = Url.Link("DefaultApi", new { controller = "Spellbook", id = id });
                    return Created(url, new { });
                }
                return InternalServerError();
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Attempts to remove a spell from the spellbook with the given ID.
        /// 
        /// ROUTE
        /// "api/spellbook/{id}/remove"
        /// 
        /// REQUEST BODY:
        /// {
        ///     "spellId": `int`
        /// }
        /// 
        /// RESPONSE:
        /// If success:
        ///     Status Code: 204 (NO CONTENT)
        ///     
        /// If unable to remove spell from spellbook:
        ///     Status Code: 500 (INTERNAL SERVER ERROR)
        ///     
        /// If model state is invalid:
        ///     Status Code: 400 (BAD REQUEST)
        ///         {
        ///             "message": `string`,
        ///             "modelState": {
        ///                 "request.Name": [`string`, . . . ]
        ///             }
        ///         }
        /// </summary>
        /// <param name="id">The spellbook's ID.</param>
        /// <param name="request">The request body.</param>
        /// <returns>The appropriate HTTPActionResult.</returns>
        [HttpPost]
        [Route("{id}/remove")]
        public async Task<IHttpActionResult> RemoveSpell(int id, SpellbookRemoveSpellRequest request)
        {
            if (ModelState.IsValid){
                if (await _spellbookRepo.RemoveSpellAsync(id, request.SpellId.Value))
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                return InternalServerError();
            }
            return BadRequest(ModelState);
        }
    }
}