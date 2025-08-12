using SWAPI.Caching;
using SWAPI.Mappers;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.Starships;

namespace SWAPI.DataManager.Starships;

public class StarshipsManager(IRepository<StarshipEntity> cache, IStarshipsService starshipService) : IStarshipsManager
{
    public async Task<List<Starship>> GetStarshipsAsync()
    {
        var cachedData = cache.GetAll();
        if (cachedData.Any())
        {
            return cachedData.ConvertAll(item => item.ToModel());
        }

        var dataFromApi = await starshipService.GetStarshipsAsync();

        if (dataFromApi != null && dataFromApi.Any())
        {
            var entities = dataFromApi.ConvertAll(item => item.ToEntity());
            cache.AddRange(entities);
        }

        return dataFromApi.Select(item => item.ToModel()).ToList();
    }

    public async Task<StarshipDetails> GetStarshipDetailsAsync(string id)
    {
        var cachedStarship = cache.GetById(id);
        if (cachedStarship != null)
        {
            return cachedStarship.ToDetailsModel();
        }

        var dto = await starshipService.GetStarshipDetailsAsync(id);
        if (dto == null)
            return null;

        var entity = dto.ToDetailsEntity();
        cache.Add(entity);

        return dto.ToDetailsModel();
    }
}