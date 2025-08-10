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

        public static PersonDetails ToDetailsModel(this PersonDetailsEntity personDetailsEntity)
        {
            return new PersonDetails
            {
                Name = personDetailsEntity.Name,
                Gender = personDetailsEntity.Gender,
                Birth_Year = personDetailsEntity.Birth_Year,
                Height = personDetailsEntity.Height,
                Mass = personDetailsEntity.Mass,
                HairColor = personDetailsEntity.HairColor,
                SkinColor = personDetailsEntity.SkinColor,
                EyeColor = personDetailsEntity.EyeColor
            };
        }

        public static PersonDetailsEntity ToDetailsEntity(this PersonDetailsDto personDetailsDto)
        {
            return new PersonDetailsEntity
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