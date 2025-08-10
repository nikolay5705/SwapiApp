using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Utils;

namespace SWAPI.Mappers
{
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

        public static StarshipDetails ToDetailsModel(this StarshipDetailsEntity starshipDetailsEntity)
        {
            return new StarshipDetails
            {
                Name = starshipDetailsEntity.Name,
                Model = starshipDetailsEntity.Model,
                Manufacturer = starshipDetailsEntity.Manufacturer,
                CostInCredits = starshipDetailsEntity.CostInCredits,
                Length = starshipDetailsEntity.Length,
                Crew = starshipDetailsEntity.Crew,
                Passengers = starshipDetailsEntity.Passengers,
                CargoCapacity = starshipDetailsEntity.CargoCapacity
            };
        }

        public static StarshipDetailsEntity ToDetailsEntity(this StarshipDetailsDto starshipDetailsDto)
        {
            return new StarshipDetailsEntity
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
    }
}