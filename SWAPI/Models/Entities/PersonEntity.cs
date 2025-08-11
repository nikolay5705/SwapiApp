namespace SWAPI.Models.Entities;

public class PersonEntity : IEntity
{
    public string Name { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public string BirthYear { get; set; } = string.Empty;

    public string Id { get; set; } = string.Empty;
}
