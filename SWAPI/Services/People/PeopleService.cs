using SWAPI.Caching;
using SWAPI.Models;
using SWAPI.Services.Requests;

namespace SWAPI.Services.Peoples
{
    public class PeopleService : IPeopleService
    {
        private readonly IRequestService _requestService;

        private MemoryRepository<Person> _peopleCache;

        public PeopleService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            if (_peopleCache.GetAll().Any())
            {
                return _peopleCache.GetAll();
            }

            string url = $"https://swapi.info/api/people";
            var data = await _requestService.GetAsync<CollectionResponse<Person>>(url);

            foreach (var item in data.Results)
            {
                _peopleCache.Add(item);
            }

            return data.Results;
        }
    }
}