using SWAPI.Caching;
using SWAPI.Models;
using SWAPI.Services.Requests;

namespace SWAPI.Services.Starships
{
    public class StarshipsService : IStarshipsService
    {
        private readonly IRequestService _requestService;

        private MemoryRepository<Starship> _starshipCache;

        public StarshipsService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<List<Starship>> GetStarshipsAsync()
        {
            if (_starshipCache.GetAll().Any())
            {
                return _starshipCache.GetAll();
            }

            string url = $"https://swapi.info/api/starships";
            var data = await _requestService.GetAsync<CollectionResponse<Starship>>(url);

            foreach (var item in data.Results)
            {
                _starshipCache.Add(item);
            }

            return data.Results;
        }
    }
}