using SWAPI.Caching;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.Requests;

namespace SWAPI.Services.Starships
{
    public class StarshipsService : IStarshipsService
    {
        private readonly IRequestService _requestService;

        public StarshipsService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<List<StarshipDto>> GetStarshipsAsync()
        {
            string url = $"https://swapi.info/api/starships";
            var data = await _requestService.GetAsync<CollectionResponse<StarshipDto>>(url);

            return data.Results;
        }

        public async Task<StarshipDetailsDto> GetStarshipDetailsAsync(string id)
        {
            string url = $"https://swapi.info/api/starships/{id}";
            return await _requestService.GetAsync<StarshipDetailsDto>(url);
        }
    }
}