using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Mappers;

public static class PersonMapper
{
    public static PersonDto ToDto(this Person personModel)
    {
        return new PersonDto
        {
            Name = personModel.Name,
            Gender = personModel.Gender,
            BirthYear = personModel.BirthYear
        };
    }

    public static PersonDto ToDto(this PersonEntity personEntity)
    {
        return new PersonDto
        {
            Name = personEntity.Name,
            Gender = personEntity.Gender,
            BirthYear = personEntity.BirthYear
        };
    }

    public static Person ToModel(this PersonDto personDto)
    {
        return new Person
        {
            Name = personDto.Name,
            Gender = personDto.Gender,
            BirthYear = personDto.BirthYear
        };
    }

    public static Person ToModel(this PersonEntity personEntity)
    {
        return new Person
        {
            Name = personEntity.Name,
            Gender = personEntity.Gender,
            BirthYear = personEntity.BirthYear
        };
    }

    public static Person ToModel(this Person person)
    {
        return new Person
        {
            Name = person.Name,
            Gender = person.Gender,
            BirthYear = person.BirthYear
        };
    }

    public static PersonEntity ToEntity(this Person personModel)
    {
        return new PersonEntity
        {
            Name = personModel.Name,
            Gender = personModel.Gender,
            BirthYear = personModel.BirthYear
        };
    }

    public static PersonEntity ToEntity(this PersonDto personDto)
    {
        return new PersonEntity
        {
            Name = personDto.Name,
            Gender = personDto.Gender,
            BirthYear = personDto.BirthYear
        };
    }
}
