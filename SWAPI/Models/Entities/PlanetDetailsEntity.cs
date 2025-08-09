namespace SWAPI.Models.Entities
{
    public class PlanetDetailsEntity
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string RotationPeriod { get; set; } = string.Empty;

        public string OrbitalPeriod { get; set; } = string.Empty;

        public string Climate { get; set; } = string.Empty;

        public string Terrain { get; set; } = string.Empty;

        public string SurfaceWater { get; set; } = string.Empty;

        public string Population { get; set; } = string.Empty;
    }
}