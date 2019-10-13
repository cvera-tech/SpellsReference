using SpellsReference.Api.Models;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SpellsReference.Api
{
    public class SpellController : ApiController
    {
        private ISpellRepository _spellRepo;

        public SpellController(ISpellRepository spellRepo)
        {
            _spellRepo = spellRepo;
        }

        /// <summary>
        /// Attempts to delete a spell with a given id.
        /// 
        /// ROUTE
        /// `api/spell/{id}`
        /// 
        /// RESPONSE BODY
        /// {
        ///     "success": `bool`,
        ///     "spell": {
        ///         "id": `int`,
        ///         "name": `string`,
        ///         "level": `int`,
        ///         "school": `string`,
        ///         "castingTime": `string`,
        ///         "range": `string`,
        ///         "verbal": `bool`,
        ///         "somatic": `bool`,
        ///         "materials": `string`,
        ///         "duration": `string`,
        ///         "ritual": `bool`,
        ///         "description": `string`
        ///     }
        /// }
        /// </summary>
        /// <param name="id">The ID of the spell.</param>
        /// <returns>The response body.</returns>
        public async Task<SpellDeleteResponse> Delete(int id)
        {
            // Query to get spell information. Maybe this isn't 
            // needed and we can just return a status code.
            var spell = await _spellRepo.GetAsync(id);
            var response = new SpellDeleteResponse()
            {
                Success = false
            };

            if (await _spellRepo.DeleteAsync(id))
            {
                response.Success = true;
                response.Spell = spell.GetInfo();
            }
            return response;
        }

        /// <summary>
        /// Retrieves a spell with a given id.
        /// 
        /// ROUTE
        /// `api/spell/{id}`
        /// 
        /// RESPONSE BODY
        /// {
        ///     "spell": {
        ///         "id": `int`,
        ///         "name": `string`,
        ///         "level": `int`,
        ///         "school": `string`,
        ///         "castingTime": `string`,
        ///         "range": `string`,
        ///         "verbal": `bool`,
        ///         "somatic": `bool`,
        ///         "materials": `string`,
        ///         "duration": `string`,
        ///         "ritual": `bool`,
        ///         "description": `string`
        ///     }
        /// }
        /// </summary>
        /// <param name="id">The ID of the spell.</param>
        /// <returns>The response body.</returns>
        public async Task<SpellDetailsResponse> Get(int id)
        {
            var spell = await _spellRepo.GetAsync(id);
            var response = new SpellDetailsResponse()
            {
                Spell = spell.GetInfo()
            };
            return response;
        }

        /// <summary>
        /// Retrieves a list of spells. Results can be filtered by passing in
        /// parameters through the query string.
        /// 
        /// ROUTE
        /// `api/spell`
        /// 
        /// RESPONSE BODY
        /// {
        ///     "spells": [
        ///         {
        ///             "id": `int`,
        ///             "name": `string`,
        ///             "level": `int`,
        ///             "school": `string`,
        ///             "castingTime": `string`,
        ///             "range": `string`,
        ///             "verbal": `bool`,
        ///             "somatic": `bool`,
        ///             "materials": `string`,
        ///             "duration": `string`,
        ///             "ritual": `bool`,
        ///             "description": `string`
        ///         },
        ///         .
        ///         .
        ///         .
        ///     ]
        /// }
        /// </summary>
        /// <returns>The response body.</returns>
        public async Task<SpellListResponse> Get([FromUri] SpellListFilter filter)
        {
            var spells = await _spellRepo.ListAsync(filter);
            var response = new SpellListResponse()
            {
                Spells = spells.Select(s => s.GetInfo()).ToList()
            };
            return response;
        }

        /// <summary>
        /// Attempts to create a new spell.
        /// 
        /// ROUTE
        /// `api/spell/`
        /// 
        /// REQUEST BODY
        /// {
        ///     "name": `string`,
        ///     "level": `int`,
        ///     "school": `string`,
        ///     "castingTime": `string`,
        ///     "range": `string`,
        ///     "verbal": `bool`,
        ///     "somatic": `bool`,
        ///     "materials": `string`,
        ///     "duration": `string`,
        ///     "ritual": `bool`,
        ///     "description": `string`
        /// }
        /// 
        /// RESPONSE BODY
        /// {
        ///     "success": `bool`,
        ///     "message": `string`,
        ///     "spell": {
        ///         "id": `int`,
        ///         "name": `string`,
        ///         "level": `int`,
        ///         "school": `string`,
        ///         "castingTime": `string`,
        ///         "range": `string`,
        ///         "verbal": `bool`,
        ///         "somatic": `bool`,
        ///         "materials": `string`,
        ///         "duration": `string`,
        ///         "ritual": `bool`,
        ///         "description": `string`
        ///     }
        /// }
        /// </summary>
        /// <param name="id">The ID of the spell.</param>
        /// <returns>The response body.</returns>
        public async Task<SpellCreateResponse> Post(SpellCreateRequest request)
        {
            var response = new SpellCreateResponse() { Success = false };
            if (ModelState.IsValid)
            {
                SchoolOfMagic school;
                if (Enum.TryParse(request.School, out school))
                {
                    var spell = new Spell()
                    {
                        Name = request.Name,
                        Level = request.Level.Value,
                        School = school,
                        CastingTime = request.CastingTime,
                        Range = request.Range,
                        Verbal = request.Verbal.Value,
                        Somatic = request.Somatic.Value,
                        Materials = request.Materials,
                        Duration = request.Duration,
                        Ritual = request.Ritual.Value,
                        Description = request.Description
                    };
                    int? spellId = await _spellRepo.AddAsync(spell);
                    if (spellId.HasValue)
                    {
                        response.Success = true;
                        response.Message = "Spell successfully created.";
                        response.Spell = spell.GetInfo();
                        return response;
                    }
                }
            }
            response.Message = "Unable to create spell. Please check parameter values.";
            return response;
        }

        /// <summary>
        /// Attempts to update a spell. This is a PUT because a PATCH is too much
        /// work for such a small model. 
        /// 
        /// ROUTE
        /// `api/spell/{id}`
        /// 
        /// REQUEST BODY
        /// {
        ///     "name": `string`,
        ///     "level": `int`,
        ///     "school": `string`,
        ///     "castingTime": `string`,
        ///     "range": `string`,
        ///     "verbal": `bool`,
        ///     "somatic": `bool`,
        ///     "materials": `string`,
        ///     "duration": `string`,
        ///     "ritual": `bool`,
        ///     "description": `string`
        /// }
        /// 
        /// RESPONSE BODY
        /// {
        ///     "success": `bool`,
        ///     "message": `string`,
        ///     "spell": {
        ///         "id": `int`,
        ///         "name": `string`,
        ///         "level": `int`,
        ///         "school": `string`,
        ///         "castingTime": `string`,
        ///         "range": `string`,
        ///         "verbal": `bool`,
        ///         "somatic": `bool`,
        ///         "materials": `string`,
        ///         "duration": `string`,
        ///         "ritual": `bool`,
        ///         "description": `string`
        ///     }
        /// }
        /// </summary>
        /// <param name="id">The ID of the spell.</param>
        /// <returns>The response body.</returns>
        public async Task<SpellUpdateResponse> Put(int id, SpellUpdateRequest request)
        {
            var response = new SpellUpdateResponse()
            {
                Success = false
            };

            if (ModelState.IsValid)
            {
                SchoolOfMagic school;
                if (Enum.TryParse(request.School, out school))
                {
                    var spell = new Spell()
                    {
                        Id = id,
                        Name = request.Name,
                        Level = request.Level.Value,
                        School = school,
                        CastingTime = request.CastingTime,
                        Range = request.Range,
                        Verbal = request.Verbal.Value,
                        Somatic = request.Somatic.Value,
                        Materials = request.Materials,
                        Duration = request.Duration,
                        Ritual = request.Ritual.Value,
                        Description = request.Description
                    };

                    if (await _spellRepo.UpdateAsync(spell))
                    {
                        response.Success = true;
                        response.Spell = spell.GetInfo();
                    }
                }
            }
            return response;
        }
    }
}