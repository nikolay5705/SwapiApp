using SWAPI.Caching;
using SWAPI.Constants;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.Requests;

namespace SWAPI.Services.Planets;

public class PlanetService(IRequestService requestService) : IPlanetsService
{
    public async Task<List<PlanetDto>> GetPlanetsAsync()
    {
        string url = $"{ApiConstants.BaseUrl}/{ApiConstants.PlanetsSegment}";
        var result = await requestService.GetAsync<CollectionResponse<PlanetDto>>(url);
        return result.Results;
    }

    public async Task<PlanetDetailsDto> GetPlanetDetailsAsync(string id)
    {
        string url = $"{ApiConstants.BaseUrl}/{ApiConstants.PlanetsSegment}/{id}";
        var result = await requestService.GetAsync<PlanetDetailsDto>(url);
        return result;
    }
}
