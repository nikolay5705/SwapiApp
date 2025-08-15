using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Mappers;

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

    public static PlanetDetails ToDetailsModel(this PlanetEntity planetDetailsDto)
    {
        return new PlanetDetails
        {
            Name = planetDetailsDto.Name,
            Climate = planetDetailsDto.Climate,
            Terrain = planetDetailsDto.Terrain,
        };
    }

    public static PlanetEntity ToDetailsEntity(this PlanetDetailsDto planetDetailsDto)
    {
        return new PlanetEntity
        {
            Name = planetDetailsDto.Name,
            Climate = planetDetailsDto.Climate,
            Terrain = planetDetailsDto.Terrain,
        };
    }
}
