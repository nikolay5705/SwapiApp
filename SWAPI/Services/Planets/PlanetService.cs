using SWAPI.Caching;
using SWAPI.Models;
using SWAPI.Services.Requests;

namespace SWAPI.Services.Planets
{
    public class PlanetService : IPlanetsService
    {
        private readonly IRequestService _requestService;

        private MemoryRepository<Planet> _planetCache;

        public PlanetService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<List<Planet>> GetPlanetsAsync()
        {
            if (_planetCache.GetAll().Any())
            {
                return _planetCache.GetAll();
            }

            string url = $"https://swapi.info/api/planets";
            var data = await _requestService.GetAsync<CollectionResponse<Planet>>(url);

            foreach (var item in data.Results)
            {
                _planetCache.Add(item);
            }

            return data.Results;
        }
    }
}