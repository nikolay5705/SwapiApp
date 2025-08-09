using SWAPI.Models;
using SWAPI.Models.Dtos;

namespace SWAPI.Mappers
{
    public static class PlanetDetailsMapper
    {
        public static Planet ToDetailsModel(this PlanetDto planetDto)
        {
            return new Planet
            {
                Id = Utils.Utils.ExtractIdFromUrl(planetDto.Url),
                Name = planetDto.Name,
                Climate = planetDto.Climate,
                Terrain = planetDto.Terrain
            };
        }

        public static PlanetDetails ToDetailsModel(this PlanetDetailsDto planetDetailsDto)
        {
            return new PlanetDetails
            {
                Name = planetDetailsDto.Name,
                Climate = planetDetailsDto.Climate,
                Terrain = planetDetailsDto.Terrain,
                RotationPeriod = planetDetailsDto.RotationPeriod,
                OrbitalPeriod = planetDetailsDto.OrbitalPeriod,
                SurfaceWater = planetDetailsDto.SurfaceWater,
                Population = planetDetailsDto.Population
            };
        }
    }
}