using SWAPI.Models;

public interface IPeopleManager
{
    Task<List<Person>> GetPeopleAsync();
}