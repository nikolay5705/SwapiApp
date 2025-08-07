using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Mappers
{
    public static class PersonMapper
    {
        public static PersonDto ToDto(this Person personModel)
        {
            return new PersonDto
            {
                Name = personModel.Name,
                Gender = personModel.Gender,
                Birth_Year = personModel.Birth_Year
            };
        }

        public static PersonDto ToDto(this PersonEntity personEntity)
        {
            return new PersonDto
            {
                Name = personEntity.Name,
                Gender = personEntity.Gender,
                Birth_Year = personEntity.Birth_Year
            };
        }

        public static Person ToModel(this PersonDto personDto)
        {
            return new Person
            {
                Name = personDto.Name,
                Gender = personDto.Gender,
                Birth_Year = personDto.Birth_Year
            };
        }

        public static Person ToModel(this PersonEntity personEntity)
        {
            return new Person
            {
                Name = personEntity.Name,
                Gender = personEntity.Gender,
                Birth_Year = personEntity.Birth_Year
            };
        }

        public static Person ToModel(this Person person)
        {
            return new Person
            {
                Name = person.Name,
                Gender = person.Gender,
                Birth_Year = person.Birth_Year
            };
        }

        public static PersonEntity ToEntity(this Person personModel)
        {
            return new PersonEntity
            {
                Name = personModel.Name,
                Gender = personModel.Gender,
                Birth_Year = personModel.Birth_Year
            };
        }

        public static PersonEntity ToEntity(this PersonDto personDto)
        {
            return new PersonEntity
            {
                Name = personDto.Name,
                Gender = personDto.Gender,
                Birth_Year = personDto.Birth_Year
            };
        }
    }
}