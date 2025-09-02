namespace SWAPI.Models.Entities;

public class PersonEntity : IEntity
{
    public string Name { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public string BirthYear { get; set; } = string.Empty;

    public string Height { get; set; } = string.Empty;

    public string Mass { get; set; } = string.Empty;

    public string SkinColor { get; set; } = string.Empty;

    public string EyeColor { get; set; } = string.Empty;

    public string Id { get; set; } = string.Empty;
}