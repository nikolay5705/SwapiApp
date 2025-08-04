using SWAPI.Models;

namespace SWAPI.Services.Peoples
{
    public interface IPeopleService
    {
        public Task<List<Person>> GetPeopleAsync();
    }
}
