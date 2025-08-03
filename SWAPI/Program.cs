using System.Text.Json;
using SWAPI.Interfaces;
using SWAPI.Services;
using SWAPI.SwapiModels;
using SWAPI.ValidationData;

// GetPeopleAsync/GetPlanetsAsync/GetStarshipsAsync
public class Program
{
    private static IRequestService _requestService = new RequestService();
    private static IPeopleService? _peopleService;
    private static IPlanetsService? _planetsService;
    private static IStarshipsService? _starshipsService;

    private static void InitializeDependencies()
    {
        _requestService = new RequestService();
        _peopleService = new PeopleService(_requestService);
        _planetsService = new PlanetService(_requestService);
        _starshipsService = new StarshipsService(_requestService);
    }

    public static async void Main()
    {
        InitializeDependencies();

        while (true)
        {
            // Get category (people, planets, starships) or 'exit' to finish the program
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
                    await _peopleService.GetPeopleAsync();
                }
                else if (category == "planets")
                {
                    await _planetsService.GetPlanetsAsync();
                }
                else if (category == "starships")
                {
                    await _starshipsService.GetStarshipsAsync();
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