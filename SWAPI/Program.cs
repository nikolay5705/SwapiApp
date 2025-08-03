using SWAPI.Services.Peoples;
using SWAPI.Services.Planets;
using SWAPI.Services.Requests;
using SWAPI.Services.Starships;
using SWAPI.Validation;

public class Program
{
    private static IRequestService? _requestService;
    private static IPeopleService? _peopleService;
    private static IPlanetsService? _planetsService;
    private static IStarshipsService? _starshipsService;

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
                    var listOfPeople = await _peopleService.GetPeopleAsync();
                    if (listOfPeople?.Any() == true)
                    {
                        foreach (var person in listOfPeople)
                        {
                            Console.WriteLine($"> Person| name: {person.Name}, gender: {person.Gender}, birth year: {person.Birth_Year}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("> No people found.");
                    }
                }
                else if (category == "planets")
                {
                    var listOfPlanets = await _planetsService.GetPlanetsAsync();
                    if (listOfPlanets?.Any() == true)
                    {
                        foreach (var planet in listOfPlanets)
                        {
                            Console.WriteLine($"> Planet| name: {planet.Name}, climate: {planet.Climate}, terrain: {planet.Terrain}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("> No planets found.");
                    }
                }
                else if (category == "starships")
                {
                    var listOfStarships = await _starshipsService.GetStarshipsAsync();
                    if (listOfStarships?.Any() == true)
                    {
                        foreach (var starship in listOfStarships)
                        {
                            Console.WriteLine($"> Starships| name: {starship.Name}, model: {starship.Model}, manufacturer: {starship.Manufacturer}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("> No starships found.");
                    }
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

    private static void InitializeDependencies()
    {
        _requestService = new RequestService();
        _peopleService = new PeopleService(_requestService);
        _planetsService = new PlanetService(_requestService);
        _starshipsService = new StarshipsService(_requestService);
    }
}