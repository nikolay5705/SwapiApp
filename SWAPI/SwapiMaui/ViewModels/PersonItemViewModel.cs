using System.Text.Json.Serialization;
using SWAPI.Models;

namespace SwapiMaui.ViewModels;

public class PersonItemViewModel
{
    public PersonItemViewModel(Person person)
    {
        Name = person.Name;
    }

    public string Name { get; set; } = string.Empty;
}