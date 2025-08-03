using SWAPI.Models;
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

        public async Task<List<Starship>> GetStarshipsAsync()
        {
            string url = $"https://swapi.info/api/starships";
            var data = await _requestService.GetAsync<CollectionResponse<Starship>>(url);

            return data.Results;
        }
    }
}