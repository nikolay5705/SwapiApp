using SWAPI.Caching;
using SWAPI.Mappers;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.Starships;

namespace SWAPI.DataManager.Starships
{
    public class StarshipsManager : IStarshipsManager
    {
        private readonly IRepository<StarshipEntity> _cache;
        private readonly IStarshipsService _starshipService;

        public StarshipsManager(IRepository<StarshipEntity> cache, IStarshipsService starshipService)
        {
            _cache = cache;
            _starshipService = starshipService;
        }

        public async Task<List<Starship>> GetStarshipsAsync()
        {
            var cached = _cache.GetAll();
            if (cached.Any())
            {
                var data = cached.ConvertAll(item => item.ToModel());
                return data;
            }

            var dataFromApi = await _starshipService.GetStarshipsAsync();

            if (dataFromApi != null && dataFromApi.Any())
            {
                var cache = dataFromApi.ConvertAll(item => item.ToEntity());
                _cache.AddRange(cache);
            }

            var result = dataFromApi.Select(item => item.ToModel()).ToList();
            return result;
        }

        public async Task<StarshipDetails> GetStarshipDetailsAsync(string id)
        {
            var dto = await _starshipService.GetStarshipDetailsAsync(id);
            return dto.ToDetailsModel();
        }
    }
}
