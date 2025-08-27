using System.Text.Json.Serialization;

namespace SWAPI.Models.Dtos;

public class PersonDto
{
    public string Name { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    [JsonPropertyName("birth_year")]
    public string BirthYear { get; set; } = string.Empty;

    public string Height { get; set; } = string.Empty;

    public string Mass { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;
}