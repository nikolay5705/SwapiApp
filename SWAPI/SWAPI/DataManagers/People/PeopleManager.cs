using SWAPI.Caching;
using SWAPI.Mappers;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.People;

namespace SWAPI.DataManager.People;

public class PeopleManager(IRepository<PersonEntity> cache, IPeopleService peopleService) : IPeopleManager
{
    public async Task<List<Person>> GetPeopleAsync()
    {
        var cachedData = cache.GetAll();
        if (cachedData.Any())
        {
            return cachedData.ConvertAll(item => item.ToModel());
        }

        var dataFromApi = await peopleService.GetPeopleAsync();

        if (dataFromApi != null && dataFromApi.Any())
        {
            var entities = dataFromApi.ConvertAll(item => item.ToEntity());
            cache.AddRange(entities);
        }

        return dataFromApi.Select(item => item.ToModel()).ToList();
    }

    public async Task<PersonDetails> GetPeopleDetailsAsync(string id)
    {
        var cachedPerson = cache.GetById(id);
        if (cachedPerson != null)
        {
            return cachedPerson.ToDetailsModel();
        }

        var dto = await peopleService.GetPersonDetailsAsync(id);
        if (dto == null)
            return null;

        var entity = dto.ToDetailsEntity();
        cache.Add(entity);

        return dto.ToDetailsModel();
    }
}