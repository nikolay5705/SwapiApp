using SWAPI.Caching;
using SWAPI.DataManager.Interfaces;
using SWAPI.DataManager.Manager;
using SWAPI.Mappers;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.Peoples;
using SWAPI.Services.Planets;
using SWAPI.Services.Requests;
using SWAPI.Services.Starships;
using SWAPI.Validation;

public class Program
{
    private static IPeopleManager? _peopleManager;
    private static IPlanetsManager? _planetsManager;
    private static IStarshipsManager? _starshipsManager;
    private static IRequestService? _requestService;

    private static IPeopleService? _peopleService;
    private static IPlanetsService? _planetService;
    private static IStarshipsService? _starshipService;

    private static IRepository<PersonEntity>? _peopleCache;
    private static IRepository<PlanetEntity>? _planetCache;
    private static IRepository<StarshipEntity>? _starshipCache;

    public static async Task Main()
    {
        InitializeDependencies();

        while (true)
        {
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
                    var listOfPeople = await _peopleManager.GetPeopleAsync();
                    if (listOfPeople.Any())
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
                    var listOfPlanets = await _planetsManager.GetPlanetAsync();
                    if (listOfPlanets.Any())
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
                    var listOfStarships = await _starshipsManager.GetStarshipsAsync();
                    if (listOfStarships.Any())
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
        _planetService = new PlanetService(_requestService);
        _starshipService = new StarshipsService(_requestService);

        _peopleCache = new MemoryRepository<PersonEntity>();
        _planetCache = new MemoryRepository<PlanetEntity>();
        _starshipCache = new MemoryRepository<StarshipEntity>();
        _peopleManager = new PeopleManager(_peopleCache, _peopleService);
        _planetsManager = new PlanetsManager(_planetCache, _planetService);
        _starshipsManager = new StarshipsManager(_starshipCache, _starshipService);
    }
}