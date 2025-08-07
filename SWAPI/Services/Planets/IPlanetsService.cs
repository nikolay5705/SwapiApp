using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Services.Planets
{
    public interface IPlanetsService
    {
        public Task<List<PlanetDto>> GetPlanetsAsync();
    }
}
