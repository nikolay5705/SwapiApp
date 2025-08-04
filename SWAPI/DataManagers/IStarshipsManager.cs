using SWAPI.Models;

namespace SWAPI.DataManager
{
    public interface IStarshipsManager
    {
        Task<List<Starship>> GetStarshipsAsync();
    }
}