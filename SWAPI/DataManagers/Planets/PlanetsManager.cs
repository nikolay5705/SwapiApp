using SWAPI.Caching;
using SWAPI.Mappers;
using SWAPI.Models;
using SWAPI.Models.Entities;
using SWAPI.Services.Planets;

namespace SWAPI.DataManager.Planets
{
    public class PlanetsManager : IPlanetsManager
    {
        private readonly IRepository<PlanetEntity> _cache;

        private readonly IPlanetsService _planetService;

        public PlanetsManager(IRepository<PlanetEntity> cache, IPlanetsService peopleService)
        {
            _cache = cache;
            _planetService = peopleService;
        }

        public async Task<List<Planet>> GetPlanetAsync()
        {
            var cached = _cache.GetAll();
            if (cached.Any())
            {
                var data = cached.ConvertAll(item => item.ToModel());
                return data;
            }

            var dataFromApi = await _planetService.GetPlanetsAsync();

            if (dataFromApi != null && dataFromApi.Any())
            {
                var cache = dataFromApi.ConvertAll(item => item.ToEntity());
                _cache.AddRange(cache);
            }

            var result = dataFromApi.Select(item => item.ToModel()).ToList();
            return result;
        }

        public async Task<PlanetDetails> GetPlanetDetailsAsync(string id)
        {
            var cached = _cache.GetAll().FirstOrDefault(p => p.Id == id);

            if (cached != null)
            {
                return cached.ToDetailsModel();
            }

            var dto = await _planetService.GetPlanetDetailsAsync(id);

            if (dto == null)
                return null;

            var entity = dto.ToDetailsEntity();
            _cache.Add(entity);

            return dto.ToDetailsModel();
        }
    }
}