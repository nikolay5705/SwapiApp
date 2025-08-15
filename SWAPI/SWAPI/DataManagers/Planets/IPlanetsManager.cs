using SWAPI.Models;

namespace SWAPI.DataManager.Planets;

public interface IPlanetsManager
{
    Task<List<Planet>> GetPlanetAsync();

    Task<PlanetDetails> GetPlanetDetailsAsync(string id);
}
