using SWAPI.Models;

namespace SWAPI.DataManager
{
    public interface IPlanetsManager
    {
        Task<List<Planet>> GetPlanetAsync();
    }
}