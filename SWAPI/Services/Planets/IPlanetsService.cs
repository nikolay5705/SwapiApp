using SWAPI.Models;

namespace SWAPI.Services.Planets
{
    public interface IPlanetsService
    {
        public Task<List<Planet>> GetPlanetsAsync();
    }
}
