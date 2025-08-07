using SWAPI.Models;

namespace SWAPI.DataManager.Interfaces
{
    public interface IPlanetsManager
    {
        Task<List<Planet>> GetPlanetAsync();
    }
}