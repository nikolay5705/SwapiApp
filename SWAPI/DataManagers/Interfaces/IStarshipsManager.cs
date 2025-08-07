using SWAPI.Models;

namespace SWAPI.DataManager.Interfaces
{
    public interface IStarshipsManager
    {
        Task<List<Starship>> GetStarshipsAsync();
    }
}