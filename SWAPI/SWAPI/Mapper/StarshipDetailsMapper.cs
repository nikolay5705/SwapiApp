using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Utils;

namespace SWAPI.Mappers;

public static class StarshipDetailsMapper
{
    public static Starship ToDetailsModel(this StarshipDto starshipDto)
    {
        return new Starship
        {
            Id = Utils.Utils.ExtractIdFromUrl(starshipDto.Url),
            Name = starshipDto.Name,
            Model = starshipDto.Model,
            Manufacturer = starshipDto.Manufacturer
        };
    }

    public static StarshipDetails ToDetailsModel(this StarshipDetailsDto starshipDetailsDto)
    {
        return new StarshipDetails
        {
            Name = starshipDetailsDto.Name,
            Model = starshipDetailsDto.Model,
            Manufacturer = starshipDetailsDto.Manufacturer,
            CostInCredits = starshipDetailsDto.CostInCredits,
            Length = starshipDetailsDto.Length,
            Crew = starshipDetailsDto.Crew,
            Passengers = starshipDetailsDto.Passengers,
            CargoCapacity = starshipDetailsDto.CargoCapacity
        };
    }

    public static StarshipDetails ToDetailsModel(this StarshipEntity starshipEntity)
    {
        return new StarshipDetails
        {
            Name = starshipEntity.Name,
            Model = starshipEntity.Model,
            Manufacturer = starshipEntity.Manufacturer,
        };
    }

    public static StarshipEntity ToDetailsEntity(this StarshipDetailsDto starshipDetailsDto)
    {
        return new StarshipEntity
        {
            Name = starshipDetailsDto.Name,
            Model = starshipDetailsDto.Model,
            Manufacturer = starshipDetailsDto.Manufacturer,
        };
    }
}
