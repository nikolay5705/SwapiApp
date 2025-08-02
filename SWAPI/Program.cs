using System.Text.Json;
using SWAPI.ValidationData;
using SWAPI.SwapiModels;
using SWAPI.Interfaces;
using SWAPI.Services;

class Program
{
    static void Main()
    {
        while (true)
        {
            //Get category (people, planets, starships) or 'exit' to finish the program
            Console.Write("> ");
            string? category = Console.ReadLine()?.Trim().ToLower();

            if (ValidationData.IsExit(category))
            {
                Console.WriteLine("> Program has finished working");
                break;
            }

            if (ValidationData.IsUnknownCategory(category))
            {
                Console.WriteLine("> Incorrect category");
                continue;
            }
            string url = $"https://swapi.info/api/{category}";

            Console.WriteLine("> loading...");

            try
            {
                if (category == "people")
                {
                    PeopleService peopleService = new PeopleService();
                    peopleService.GetInformationAboutPeople(url);
                }
                else if (category == "planets")
                {
                    PlanetService planetService = new PlanetService();
                    planetService.GetInformationAboutPlanet(url);
                }
                else if (category == "starships")
                {
                    StarshipsService starshipsService = new StarshipsService();
                    starshipsService.GetInformationAboutStarships(url);
                }
                else
                {
                    Console.WriteLine("> Something wrong with getting data.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"> Exception: {exception.Message}");
            }

            Console.WriteLine();
        }
    }

}