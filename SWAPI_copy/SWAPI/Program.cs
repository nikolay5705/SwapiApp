using SWAPI.Caching;
using SWAPI.DataManager.People;
using SWAPI.DataManager.Planets;
using SWAPI.DataManager.Starships;
using SWAPI.Mappers;
using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.People;
using SWAPI.Services.Planets;
using SWAPI.Services.Requests;
using SWAPI.Services.Starships;
using SWAPI.Utils;
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
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (input == null)
                continue;

            if (ValidationData.IsExit(input))
            {
                Console.WriteLine("> Program has finished working");
                break;
            }

            if (ValidationData.IsUnknownCategory(input))
            {
                Console.WriteLine("> Incorrect category");
                continue;
            }

            Console.WriteLine("> ...");

            try
            {
                if (input == "people")
                {
                    var listOfPeople = await _peopleManager.GetPeopleAsync();

                    Console.Write("> ");
                    string? personName = Console.ReadLine()?.Trim().ToLower();

                    if (!string.IsNullOrEmpty(personName))
                    {
                        var person = listOfPeople.FirstOrDefault(p => p.Name.ToLower() == personName);
                        if (person != null)
                        {
                            var details = await _peopleManager.GetPeopleDetailsAsync(person.Id);
                            DetailsDescription.PrintPersonDetails(details);
                        }
                        else
                        {
                            Console.WriteLine("> Person not found.");
                        }
                    }
                }
                else if (input == "planets")
                {
                    var listOfPlanets = await _planetsManager.GetPlanetAsync();

                    Console.Write("> ");
                    string? planetName = Console.ReadLine()?.Trim().ToLower();

                    if (!string.IsNullOrEmpty(planetName))
                    {
                        var planet = listOfPlanets.FirstOrDefault(p => p.Name.ToLower() == planetName);
                        if (planet != null)
                        {
                            var details = await _planetsManager.GetPlanetDetailsAsync(planet.Id);
                            DetailsDescription.PrintPlanetDetails(details);
                        }
                        else
                        {
                            Console.WriteLine("> Planet not found.");
                        }
                    }
                }
                else if (input == "starships")
                {
                    var listOfStarships = await _starshipsManager.GetStarshipsAsync();

                    Console.Write("> ");
                    string? starshipName = Console.ReadLine()?.Trim().ToLower();

                    if (!string.IsNullOrEmpty(starshipName))
                    {
                        var starship = listOfStarships.FirstOrDefault(s => s.Name.ToLower() == starshipName);
                        if (starship != null)
                        {
                            var details = await _starshipsManager.GetStarshipDetailsAsync(starship.Id);
                            DetailsDescription.PrintStarshipDetails(details);
                        }
                        else
                        {
                            Console.WriteLine("> Starship not found.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("> Something wrong with getting data.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"> Exception: {ex.Message}");
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