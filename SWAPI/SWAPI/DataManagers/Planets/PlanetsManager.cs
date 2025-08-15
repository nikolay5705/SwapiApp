using SWAPI.Caching;
using SWAPI.Mappers;
using SWAPI.Models;
using SWAPI.Models.Entities;
using SWAPI.Services.Planets;

namespace SWAPI.DataManager.Planets;

public class PlanetsManager(IRepository<PlanetEntity> cache, IPlanetsService planetService) : IPlanetsManager
{
    public async Task<List<Planet>> GetPlanetAsync()
    {
        var cachedData = cache.GetAll();
        if (cachedData.Any())
        {
            return cachedData.ConvertAll(item => item.ToModel());
        }

        var dataFromApi = await planetService.GetPlanetsAsync();

        if (dataFromApi != null && dataFromApi.Any())
        {
            var entities = dataFromApi.ConvertAll(item => item.ToEntity());
            cache.AddRange(entities);
        }

        return dataFromApi.Select(item => item.ToModel()).ToList();
    }

    public async Task<PlanetDetails> GetPlanetDetailsAsync(string id)
    {
        var cachedPlanet = cache.GetById(id);
        if (cachedPlanet != null)
        {
            return cachedPlanet.ToDetailsModel();
        }

        var dto = await planetService.GetPlanetDetailsAsync(id);
        if (dto == null)
            return null;

        var entity = dto.ToDetailsEntity();
        cache.Add(entity);

        return dto.ToDetailsModel();
    }
}