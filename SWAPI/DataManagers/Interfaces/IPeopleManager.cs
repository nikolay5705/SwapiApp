using SWAPI.Models;
using SWAPI.Models.Entities;

namespace SWAPI.DataManager.Interfaces
{
    public interface IPeopleManager
    {
        Task<List<Person>> GetPeopleAsync();
    }
}