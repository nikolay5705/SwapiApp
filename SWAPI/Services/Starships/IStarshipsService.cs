using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Services.Starships
{
    public interface IStarshipsService
    {
        public Task<List<StarshipDto>> GetStarshipsAsync();
    }
}
