using SWAPI.Caching;
using SWAPI.Models;
using SWAPI.Services.Starships;

namespace SWAPI.DataManager
{
    public class StarshipsManager : IStarshipsManager
    {
        private readonly IRepository<Starship> _cache;
        private readonly IStarshipsService _starshipService;

        public StarshipsManager(IRepository<Starship> cache, IStarshipsService starshipService)
        {
            _cache = cache;
            _starshipService = starshipService;
        }

        public async Task<List<Starship>> GetStarshipsAsync()
        {
            var cached = _cache.GetAll();
            if (cached.Any())
            {
                return cached;
            }

            var dataFromApi = await _starshipService.GetStarshipsAsync();

            if (dataFromApi != null && dataFromApi.Any())
            {
                _cache.Add(dataFromApi);
            }

            return dataFromApi;
        }
    }
}
