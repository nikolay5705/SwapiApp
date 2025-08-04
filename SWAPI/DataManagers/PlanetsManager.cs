using SWAPI.Caching;
using SWAPI.Models;
using SWAPI.Services.Planets;

namespace SWAPI.DataManager
{
     public class PlanetsManager : IPlanetsManager
    {
        private readonly IRepository<Planet> _cache;
        private readonly IPlanetsService _planetService;

        public PlanetsManager(IRepository<Planet> cache, IPlanetsService planetService)
        {
            _cache = cache;
            _planetService = planetService;
        }

        public async Task<List<Planet>> GetPlanetAsync()
        {
            var cached = _cache.GetAll();
            if (cached.Any())
            {
                return cached;
            }

            var dataFromApi = await _planetService.GetPlanetsAsync();

            if (dataFromApi != null && dataFromApi.Any())
            {
                _cache.Add(dataFromApi);
            }

            return dataFromApi;
        }
    }
}