using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Mappers;

public static class PlanetMapper
{
    public static PlanetDto ToDto(this Planet planetModel)
    {
        return new PlanetDto
        {
            Name = planetModel.Name,
            Climate = planetModel.Climate,
            Terrain = planetModel.Terrain
        };
    }

    public static PlanetDto ToDto(this PlanetEntity planetEntity)
    {
        return new PlanetDto
        {
            Name = planetEntity.Name,
            Climate = planetEntity.Climate,
            Terrain = planetEntity.Terrain
        };
    }

    public static Planet ToModel(this PlanetDto planetDto)
    {
        return new Planet
        {
            Name = planetDto.Name,
            Climate = planetDto.Climate,
            Terrain = planetDto.Terrain
        };
    }

    public static Planet ToModel(this Planet planet)
    {
        return new Planet
        {
            Name = planet.Name,
            Climate = planet.Climate,
            Terrain = planet.Terrain
        };
    }

    public static Planet ToModel(this PlanetEntity entity)
    {
        return new Planet
        {
            Name = entity.Name,
            Climate = entity.Climate,
            Terrain = entity.Terrain
        };
    }

    public static PlanetEntity ToEntity(this Planet planetModel)
    {
        return new PlanetEntity
        {
            Name = planetModel.Name,
            Climate = planetModel.Climate,
            Terrain = planetModel.Terrain
        };
    }

    public static PlanetEntity ToEntity(this PlanetDto planetDto)
    {
        return new PlanetEntity
        {
            Name = planetDto.Name,
            Climate = planetDto.Climate,
            Terrain = planetDto.Terrain
        };
    }
}
