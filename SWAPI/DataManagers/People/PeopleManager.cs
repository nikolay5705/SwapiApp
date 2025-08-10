using SWAPI.Caching;
using SWAPI.Mappers;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.People;

namespace SWAPI.DataManager.People
{
    public class PeopleManager : IPeopleManager
    {
        private readonly IRepository<PersonEntity> _cache;

        private readonly IRepository<PersonDetailsEntity> _cacheDetails;

        private readonly IPeopleService _peopleService;

        public PeopleManager(IRepository<PersonEntity> cache, IPeopleService peopleService)
        {
            _cache = cache;
            _peopleService = peopleService;
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            var cached = _cache.GetAll();
            if (cached.Any())
            {
                var data = cached.ConvertAll(item => item.ToModel());
                return data;
            }

            var dataFromApi = await _peopleService.GetPeopleAsync();

            if (dataFromApi != null && dataFromApi.Any())
            {
                var cache = dataFromApi.ConvertAll(item => item.ToEntity());
                _cache.AddRange(cache);
            }

            var result = dataFromApi.Select(item => item.ToModel()).ToList();
            return result;
        }

        public async Task<PersonDetails> GetPeopleDetailsAsync(string id)
        {
            var cachedPerson = _cacheDetails.GetAll().FirstOrDefault(p => p.Id == id);

            if (cachedPerson != null)
            {
                return cachedPerson.ToDetailsModel();
            }

            var dto = await _peopleService.GetPersonDetailsAsync(id);

            if (dto == null)
                return null;

            var entity = dto.ToDetailsEntity();
            _cacheDetails.Add(entity);

            return dto.ToDetailsModel();
        }
    }
}
