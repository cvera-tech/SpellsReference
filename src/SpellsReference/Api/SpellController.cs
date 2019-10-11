using SpellsReference.Api.Models;
using SpellsReference.Data.Repositories;
using SpellsReference.Models;
using System;
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

        public Task<SpellDeleteResponse> Delete(SpellDeleteRequest request)
        {
            return null;
        }

        /// <summary>
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
        public async Task<SpellListResponse> Get()
        {
            var spells = await _spellRepo.ListAsync();
            var response = new SpellListResponse();
            spells.ForEach(s => response.Spells.Add(s.GetInfo()));
            return response;
        }

        /// <summary>
        /// ROUTE
        /// `api/spell/{id}`
        /// 
        /// RESPONSE BODY
        /// {
        ///     "spell": [
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
        ///         }
        ///     ]
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

        public Task<SpellUpdateResponse> Patch(SpellUpdateRequest request)
        {
            return null;
        }

        //public Task<SpellListResponse> Post(SpellListRequest request)
        //{
        //    return null;
        //}

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
                        response.Spell = spell.GetInfo();
                    }
                }
            }

            return response;
        }
    }
}