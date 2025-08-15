using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Services.People;

public interface IPeopleService
{
    public Task<List<PersonDto>> GetPeopleAsync();

    Task<PersonDetailsDto> GetPersonDetailsAsync(string id);
}
