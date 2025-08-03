using SWAPI.Interfaces;
using SWAPI.Services;

namespace SWAPI.SwapiModels
{
    public class PeopleService : IPeopleService
    {
        private readonly IRequestService _requestService;

        public PeopleService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<List<People>> GetPeopleAsync()
        {
            string url = $"https://swapi.info/api/people";
            var data = await _requestService.GetAsync<CollectionResponse<People>>(url);

            return data.Results;
        }
    }
}