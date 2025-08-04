using SWAPI.Caching;
using SWAPI.Models;
using SWAPI.Services.Requests;

namespace SWAPI.Services.Planets
{
    public class PlanetService : IPlanetsService
    {
        private readonly IRequestService _requestService;

        public PlanetService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<List<Planet>> GetPlanetsAsync()
        {
            string url = $"https://swapi.info/api/planets";
            var data = await _requestService.GetAsync<CollectionResponse<Planet>>(url);

            return data.Results;
        }
    }
}