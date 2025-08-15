using SWAPI.Models;

namespace SWAPI.DataManager.Starships;

public interface IStarshipsManager
{
    Task<List<Starship>> GetStarshipsAsync();

    Task<StarshipDetails> GetStarshipDetailsAsync(string id);
}