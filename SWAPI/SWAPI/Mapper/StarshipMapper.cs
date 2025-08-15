using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Mappers;

public static class StarshipMapper
{
    public static StarshipDto ToDto(this Starship starshipModel)
    {
        return new StarshipDto
        {
            Name = starshipModel.Name,
            Model = starshipModel.Model,
            Manufacturer = starshipModel.Manufacturer
        };
    }

    public static StarshipDto ToDto(this StarshipEntity starshipEntity)
    {
        return new StarshipDto
        {
            Name = starshipEntity.Name,
            Model = starshipEntity.Model,
            Manufacturer = starshipEntity.Manufacturer
        };
    }

    public static Starship ToModel(this StarshipDto starshipDto)
    {
        return new Starship
        {
            Name = starshipDto.Name,
            Model = starshipDto.Model,
            Manufacturer = starshipDto.Manufacturer
        };
    }

    public static Starship ToModel(this StarshipEntity starshipEntity)
    {
        return new Starship
        {
            Name = starshipEntity.Name,
            Model = starshipEntity.Model,
            Manufacturer = starshipEntity.Manufacturer
        };
    }

    public static Starship ToModel(this Starship starship)
    {
        return new Starship
        {
            Name = starship.Name,
            Model = starship.Model,
            Manufacturer = starship.Manufacturer
        };
    }

    public static StarshipEntity ToEntity(this Starship starshipModel)
    {
        return new StarshipEntity
        {
            Name = starshipModel.Name,
            Model = starshipModel.Model,
            Manufacturer = starshipModel.Manufacturer
        };
    }

    public static StarshipEntity ToEntity(this StarshipDto starshipDto)
    {
        return new StarshipEntity
        {
            Name = starshipDto.Name,
            Model = starshipDto.Model,
            Manufacturer = starshipDto.Manufacturer
        };
    }
}
