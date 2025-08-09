using SWAPI.Models;

namespace SWAPI.Utils
{
    public static class DetailsDescription
    {
        public static void PrintPersonDetails(PersonDetails details)
        {
            string pronounGender = GetPronounByGender(details.Gender);
            Console.WriteLine($"{details.Name} has height {details.Height} cm and weight {details.Mass} kg. " +
                $"{pronounGender} has {details.HairColor} hair, {details.SkinColor} skin and {details.EyeColor} eyes. " +
                $"{pronounGender} was born in {details.Birth_Year}.");
        }

        public static void PrintPlanetDetails(PlanetDetails details)
        {
            Console.WriteLine($"Planet {details.Name} has rotation period {details.RotationPeriod} hours and orbital period {details.OrbitalPeriod} days.");
            Console.WriteLine($"{details.Name} has {details.Climate} climate, {details.Terrain} terrain and has surface water. Planet population - {details.Population} people.");
        }

        public static void PrintStarshipDetails(StarshipDetails details)
        {
            Console.WriteLine($"{details.Name} is {details.Model} which has been manufactured by {details.Manufacturer}. It costs {details.CostInCredits} credits.");
            Console.WriteLine($"Its length is {details.Length} meters, and crew capacity - {details.Crew}. Also may ship {details.Passengers} passengers and {details.CargoCapacity} kg of cargo capacity.");
        }

        public static string GetPronounByGender(string gender)
        {
            if (string.IsNullOrWhiteSpace(gender))
                return "It";

            switch (gender.Trim().ToLower())
            {
                case "male":
                    return "He";
                case "female":
                    return "She";
                case "n/a":
                case "none":
                case "hermaphrodite":
                case "unknown":
                default:
                    return "It";
            }
        }
    }
}