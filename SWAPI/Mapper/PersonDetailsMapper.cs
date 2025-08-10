using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Mappers
{
    public static class PersonDetailsMapper
    {
        public static Person ToDetailsModel(this PersonDto personDto)
        {
            return new Person
            {
                Id = Utils.Utils.ExtractIdFromUrl(personDto.Url),
                Name = personDto.Name,
                Gender = personDto.Gender,
                Birth_Year = personDto.Birth_Year
            };
        }

        public static PersonDetails ToDetailsModel(this PersonEntity personEntity)
        {
            return new PersonDetails
            {
                Id = personEntity.Id,
                Name = personEntity.Name,
                Gender = personEntity.Gender,
                Birth_Year = personEntity.Birth_Year,
            };
        }

        public static PersonEntity ToDetailsEntity(this PersonDetailsDto personDetailsDto)
        {
            return new PersonEntity
            {
                Name = personDetailsDto.Name,
                Gender = personDetailsDto.Gender,
                Birth_Year = personDetailsDto.Birth_Year
            };
        }

        public static PersonDetails ToDetailsModel(this PersonDetailsDto personDetailsDto)
        {
            return new PersonDetails
            {
                Name = personDetailsDto.Name,
                Gender = personDetailsDto.Gender,
                Birth_Year = personDetailsDto.Birth_Year,
                Height = personDetailsDto.Height,
                Mass = personDetailsDto.Mass,
                HairColor = personDetailsDto.HairColor,
                SkinColor = personDetailsDto.SkinColor,
                EyeColor = personDetailsDto.EyeColor
            };
        }
    }
}