using SWAPI.Caching;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
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

        public async Task<List<PlanetDto>> GetPlanetsAsync()
        {
            string url = $"https://swapi.info/api/planets";
            var data = await _requestService.GetAsync<CollectionResponse<PlanetDto>>(url);

            return data.Results;
        }
    }
}