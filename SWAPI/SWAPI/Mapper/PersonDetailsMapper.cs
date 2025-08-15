using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Mappers;

public static class PersonDetailsMapper
{
    public static Person ToDetailsModel(this PersonDto personDto)
    {
        return new Person
        {
            Id = Utils.Utils.ExtractIdFromUrl(personDto.Url),
            Name = personDto.Name,
            Gender = personDto.Gender,
            BirthYear = personDto.BirthYear
        };
    }

    public static PersonDetails ToDetailsModel(this PersonEntity personEntity)
    {
        return new PersonDetails
        {
            Id = personEntity.Id,
            Name = personEntity.Name,
            Gender = personEntity.Gender,
            BirthYear = personEntity.BirthYear,
        };
    }

    public static PersonEntity ToDetailsEntity(this PersonDetailsDto personDetailsDto)
    {
        return new PersonEntity
        {
            Name = personDetailsDto.Name,
            Gender = personDetailsDto.Gender,
            BirthYear = personDetailsDto.BirthYear
        };
    }

    public static PersonDetails ToDetailsModel(this PersonDetailsDto personDetailsDto)
    {
        return new PersonDetails
        {
            Name = personDetailsDto.Name,
            Gender = personDetailsDto.Gender,
            BirthYear = personDetailsDto.BirthYear,
            Height = personDetailsDto.Height,
            Mass = personDetailsDto.Mass,
            HairColor = personDetailsDto.HairColor,
            SkinColor = personDetailsDto.SkinColor,
            EyeColor = personDetailsDto.EyeColor
        };
    }
}
