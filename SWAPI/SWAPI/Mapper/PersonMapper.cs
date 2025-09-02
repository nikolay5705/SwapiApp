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
            Height = personModel.Height,
            Mass = personModel.Mass,
            BirthYear = personModel.BirthYear,
            SkinColor = personModel.SkinColor,
            EyeColor = personModel.EyeColor,
        };
    }

    public static PersonDto ToDto(this PersonEntity personEntity)
    {
        return new PersonDto
        {
            Name = personEntity.Name,
            Gender = personEntity.Gender,
            Height = personEntity.Height,
            Mass = personEntity.Mass,
            BirthYear = personEntity.BirthYear,
            SkinColor = personEntity.SkinColor,
            EyeColor = personEntity.EyeColor,
        };
    }

    public static Person ToModel(this PersonDto personDto)
    {
        return new Person
        {
            Id = Utils.Utils.ExtractIdFromUrl(personDto.Url),
            Name = personDto.Name,
            Gender = personDto.Gender,
            Height = personDto.Height,
            Mass = personDto.Mass,
            BirthYear = personDto.BirthYear,
            SkinColor = personDto.SkinColor,
            EyeColor = personDto.EyeColor,
        };
    }

    public static Person ToModel(this PersonEntity personEntity)
    {
        return new Person
        {
            Name = personEntity.Name,
            Gender = personEntity.Gender,
            Height = personEntity.Height,
            Mass = personEntity.Mass,
            BirthYear = personEntity.BirthYear,
            SkinColor = personEntity.SkinColor,
            EyeColor = personEntity.EyeColor,
        };
    }

    public static Person ToModel(this Person person)
    {
        return new Person
        {
            Name = person.Name,
            Gender = person.Gender,
            Height = person.Height,
            Mass = person.Mass,
            BirthYear = person.BirthYear,
            SkinColor = person.SkinColor,
            EyeColor = person.EyeColor,
        };
    }

    public static PersonEntity ToEntity(this Person personModel)
    {
        return new PersonEntity
        {
            Name = personModel.Name,
            Gender = personModel.Gender,
            Height = personModel.Height,
            Mass = personModel.Mass,
            BirthYear = personModel.BirthYear,
            SkinColor = personModel.SkinColor,
            EyeColor = personModel.EyeColor,
        };
    }

    public static PersonEntity ToEntity(this PersonDto personDto)
    {
        return new PersonEntity
        {
            Name = personDto.Name,
            Gender = personDto.Gender,
            Height = personDto.Height,
            Mass = personDto.Mass,
            BirthYear = personDto.BirthYear,
            SkinColor = personDto.SkinColor,
            EyeColor = personDto.EyeColor,
        };
    }
}
