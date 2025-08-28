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
    }

    public string Name { get; set; } = string.Empty;

    public string Height { get; set; } = string.Empty;

    public string Mass { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public string Id { get; set; } = string.Empty;

    public string GenderImage { get; set; } = string.Empty;
}