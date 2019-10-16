using SpellsReference.Api.Models;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        /// <summary>
        /// Attempts to delete the spellbook with the given ID from the database.
        /// 
        /// ROUTE
        /// "api/spellbook/{id}"
        /// 
        /// REQUEST
        ///     METHOD: DELETE
        ///     
        /// RESPONSE
        /// If success:
        ///     Status Code: 204 (NO CONTENT)
        ///     
        /// If the spellbook doesn't exist in the database:
        ///     Status Code: 400 (BAD REQUEST)
        ///     BODY:
        ///         {
        ///             "message": `string`
        ///         }
        ///         
        /// If unable to delete the spellbook from database:
        ///     Status Code: 500 (INTERNAL SERVER ERROR)
        ///     
        /// </summary>
        /// <param name="id">The spellbook's ID.</param>
        /// <returns>The appropriate HttpActionResult.</returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (!await _spellbookRepo.ExistsAsync(id))
            {
                return BadRequest("Invalid spellbook ID.");
            }

            if (await _spellbookRepo.DeleteAsync(id))
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Retrieves the list of spellbooks from the database.
        /// 
        /// ROUTE
        /// "api/spellbook"
        /// 
        /// REQUEST
        ///     METHOD: GET
        ///     
        /// RESPONSE
        /// If success:
        ///     Status Code: 200 (OK)
        ///     BODY:
        ///         [
        ///             {
        ///                 "id": `int`,
        ///                 "name": `string`,
        ///                 "numberOfSpells": `int` 
        ///             }, 
        ///             .
        ///             .
        ///             .
        ///         ]
        /// 
        /// If exception is thrown:
        ///     Status Code: 500 (INTERNAL SERVER ERROR)
        ///     
        /// </summary>
        /// <returns>The appropriate HttpActionResult.</returns>
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var spellbooks = await _spellbookRepo.ListAsync();
                var response = spellbooks.Select(sb => sb.GetShortInfo());
                return Ok(response);
            }
            catch
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Attempts to retrieve a spellbook from the database.
        /// 
        /// ROUTE
        /// "api/spellbook/{id}"
        /// 
        /// REQUEST 
        ///     METHOD: GET
        /// 
        /// RESPONSE
        /// If success:
        ///     Status Code: 200 (SUCCESS)
        ///     BODY:
        ///         {
        ///             "id": `int`,
        ///             "name": `string`,
        ///             "numberOfSpells": `int`
        ///             "spells": [
        ///                 {
        ///                     "id": `int`,
        ///                     "name": `string`,
        ///                     "level": `int`,
        ///                     "school": `string`,
        ///                     "castingTime": `string`,
        ///                     "range": `string`,
        ///                     "verbal": `bool`,
        ///                     "somatic": `bool`,
        ///                     "materials": `string`,
        ///                     "duration": `string`,
        ///                     "ritual": `bool`,
        ///                     "description": `string`
        ///                 }, 
        ///                 .
        ///                 .
        ///                 .
        ///             ]
        ///         }
        ///         
        /// If spellbook does not exist:
        ///     Status Code: 400 (BAD REQUEST)
        ///     BODY:
        ///         {
        ///             "message": `string`,
        ///             "modelState": {
        ///                 "request.Name": [`string`, . . . ]
        ///             }
        ///         }
        /// 
        /// </summary>
        /// <param name="id">The spellbook's ID.</param>
        /// <returns>The appropriate HttpActionResult.</returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var spellbook = await _spellbookRepo.GetAsync(id);
            if (spellbook != null)
            {
                return Ok(spellbook.GetInfo());
            }
            else
            {
                return BadRequest("Invalid spellbook ID.");
            }
        }

        /// <summary>
        /// Attempts to retrieve the spells that don't belong to the spellbook
        /// with the given id.
        /// 
        /// ROUTE
        /// "api/spellbook/{id}/nonmemberspells"
        /// 
        /// REQUEST
        ///     METHOD: GET
        ///     
        /// RESPONSE
        /// If success:
        ///     Status Code: 200 (OK)
        ///     BODY:
        ///         [
        ///             {
        ///                 "id": `int`,
        ///                 "name": `string`,
        ///                 "level": `int`,
        ///                 "school": `string`,
        ///                 "castingTime": `string`,
        ///                 "range": `string`,
        ///                 "verbal": `bool`,
        ///                 "somatic": `bool`,
        ///                 "materials": `string`,
        ///                 "duration": `string`,
        ///                 "ritual": `bool`,
        ///                 "description": `string`
        ///             },
        ///             .
        ///             .
        ///             .
        ///         ]
        /// 
        /// If spellbook does not exist:
        ///     Status Code: 400 (BAD REQUEST)
        ///     BODY:
        ///         {
        ///             "message": `string`
        ///         }
        /// </summary>
        /// <param name="id">The spellbook's ID.</param>
        /// <returns>The appropriate HttpActionResult.</returns>
        [Route("{id}/nonmemberSpells")]
        public async Task<IHttpActionResult> GetNonmemberSpells(int id)
        {
            var spells = await _spellbookRepo.GetNonmemberSpellsAsync(id);
            
            if (spells == null)
            {
                return BadRequest("Invalid spellbook ID.");
            }
            else
            {
                var response = spells.Select(s => s.GetInfo()).ToList();
                return Ok(response);
            }
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
        /// <returns>The appropriate HttpActionResult.</returns>
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
                    // var url = Url.Link("DefaultApi", new { controller = "Spellbook", id = spellbookId.Value });
                    var url = $"/spellbook/details/{spellbookId}";
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
        /// <returns>The appropriate HttpActionResult.</returns>
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
        /// <returns>The appropriate HttpActionResult.</returns>
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
        /// <returns>The appropriate HttpActionResult.</returns>
        [HttpPost]
        [Route("{id}/remove")]
        public async Task<IHttpActionResult> RemoveSpell(int id, SpellbookRemoveSpellRequest request)
        {
            if (ModelState.IsValid)
            {
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