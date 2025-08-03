using SWAPI.Services;
using SWAPI.SwapiModels;

namespace SWAPI.Interfaces
{
    public interface IPeopleService
    {
        public Task<List<People>> GetPeopleAsync();
    }
}
