using SWAPI.Models;
using SWAPI.Models.Entities;

namespace SWAPI.DataManager.People;

public interface IPeopleManager
{
    Task<List<Person>> GetPeopleAsync();

    Task<PersonDetails> GetPeopleDetailsAsync(string id);
}
