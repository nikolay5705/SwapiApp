using SWAPI.Caching;
using SWAPI.Constants;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.Requests;

namespace SWAPI.Services.Starships;

public class StarshipsService(IRequestService requestService) : IStarshipsService
{
    public async Task<List<StarshipDto>> GetStarshipsAsync()
    {
        string url = $"{ApiConstants.BaseUrl}/{ApiConstants.StarshipsSegment}";
        var result = await requestService.GetAsync<CollectionResponse<StarshipDto>>(url);

        return result.Results;
    }

    public async Task<StarshipDetailsDto> GetStarshipDetailsAsync(string id)
    {
        string url = $"{ApiConstants.BaseUrl}/{ApiConstants.StarshipsSegment}/{id}";
        var result = await requestService.GetAsync<StarshipDetailsDto>(url);
        return result;
    }
}
