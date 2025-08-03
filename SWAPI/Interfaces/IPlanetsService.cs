using SWAPI.Services;
using SWAPI.SwapiModels;

namespace SWAPI.Interfaces
{
    public interface IPlanetsService
    {
        public Task<List<Planet>> GetPlanetsAsync();
    }
}
