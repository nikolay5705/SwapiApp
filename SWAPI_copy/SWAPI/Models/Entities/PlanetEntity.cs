namespace SWAPI.Models.Entities;

public class PlanetEntity : IEntity
{
    public string Name { get; set; } = string.Empty;

    public string Climate { get; set; } = string.Empty;

    public string Terrain { get; set; } = string.Empty;

    public string Id { get; set; } = string.Empty;
}
