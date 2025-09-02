using SWAPI.Caching;
using SWAPI.Constants;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.Requests;

namespace SWAPI.Services.People;

public class PeopleService(IRequestService requestService) : IPeopleService
{
    public async Task<List<PersonDto>> GetPeopleAsync()
    {
        string url = $"{ApiConstants.BaseUrl}/{ApiConstants.PeopleSegment}";
        var result = await requestService.GetAsync<List<PersonDto>>(url);
        return result;
    }

    public async Task<PersonDetailsDto> GetPersonDetailsAsync(string id)
    {
        string url = $"{ApiConstants.BaseUrl}/{ApiConstants.PeopleSegment}/{id}";
        var result = await requestService.GetAsync<PersonDetailsDto>(url);
        return result;
    }
}