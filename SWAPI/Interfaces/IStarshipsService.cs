using SWAPI.Services;
using SWAPI.SwapiModels;

namespace SWAPI.Interfaces
{
    public interface IStarshipsService
    {
        public Task<List<Starship>> GetStarshipsAsync();
    }
}
