using System.Text.Json.Serialization;
using SWAPI.Models;

namespace SwapiMaui.ViewModels;

public class PersonItemViewModel
{
    public PersonItemViewModel(Person person)
    {
        Name = person.Name;
        Height = $"{person.Height} cm";
        Mass = $"{person.Mass} kg";
        Gender = person.Gender;
        SkinColor = person.SkinColor.Split(",").FirstOrDefault();
        EyeColor = person.EyeColor.Split(",").FirstOrDefault();
        Id = person.Id;
    }

    public PersonItemViewModel(PersonDetails personDetails)
    {
        Name = personDetails.Name;
        Height = $"{personDetails.Height} cm";
        Mass = $"{personDetails.Mass} kg";
        Gender = personDetails.Gender;
        SkinColor = personDetails.SkinColor.Split(",").FirstOrDefault();
        EyeColor = personDetails.EyeColor.Split(",").FirstOrDefault();
        Id = personDetails.Id;
    }

    public string Name { get; set; } = string.Empty;

    public string Height { get; set; } = string.Empty;

    public string Mass { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public string SkinColor { get; set; } = string.Empty;

    public string EyeColor { get; set; } = string.Empty;

    public string Id { get; set; } = string.Empty;

    public string GenderImage { get; set; } = string.Empty;
}