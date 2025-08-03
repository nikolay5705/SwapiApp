using SWAPI.Models;

namespace SWAPI.Services.Starships
{
    public interface IStarshipsService
    {
        public Task<List<Starship>> GetStarshipsAsync();
    }
}
