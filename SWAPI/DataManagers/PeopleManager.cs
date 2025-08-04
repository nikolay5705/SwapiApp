using SWAPI.Caching;
using SWAPI.Models;
using SWAPI.Services.Peoples;

namespace SWAPI.DataManager
{
    public class PeopleManager : IPeopleManager
    {
        private readonly IRepository<Person> _cache;
        private readonly IPeopleService _peopleService;

        public PeopleManager(IRepository<Person> cache, IPeopleService peopleService)
        {
            _cache = cache;
            _peopleService = peopleService;
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            var cached = _cache.GetAll();
            if (cached.Any())
            {
                return cached;
            }

            var dataFromApi = await _peopleService.GetPeopleAsync();

            if (dataFromApi != null && dataFromApi.Any())
            {
                _cache.Add(dataFromApi);
            }

            return dataFromApi;
        }
    }
}