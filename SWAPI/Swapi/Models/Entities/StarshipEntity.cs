namespace SWAPI.Models.Entities;

public class StarshipEntity : IEntity
{
    public string Name { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public string Manufacturer { get; set; } = string.Empty;

    public string Id { get; set; } = string.Empty;
}
