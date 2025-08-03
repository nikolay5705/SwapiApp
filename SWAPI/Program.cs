using System.Text.Json;
using SWAPI.ValidationData;
using SWAPI.SwapiModels;
using SWAPI.Interfaces;
using SWAPI.Services;

class Program
{
    private static IRequestService requestService = new RequestService();
    private static IPeopleService peopleService = new PeopleService(requestService);
    private static IPlanetsService planetsService = new PlanetService(requestService);
    private static IStarshipsService starshipsService = new StarshipsService(requestService);

    static async void Main()
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

            Console.WriteLine("> loading...");

            try
            {
                if (category == "people")
                {
                    await peopleService.GetInformationAboutPeople();
                }
                else if (category == "planets")
                {
                    await planetsService.GetInformationAboutPlanet();
                }
                else if (category == "starships")
                {
                    await starshipsService.GetInformationAboutStarships();
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