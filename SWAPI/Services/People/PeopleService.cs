using SWAPI.Caching;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.Requests;

namespace SWAPI.Services.Peoples
{
    public class PeopleService : IPeopleService
    {
        private readonly IRequestService _requestService;

        public PeopleService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<List<PersonDto>> GetPeopleAsync()
        {
            string url = $"https://swapi.info/api/people";
            var data = await _requestService.GetAsync<CollectionResponse<PersonDto>>(url);

            return data.Results;
        }
    }
}