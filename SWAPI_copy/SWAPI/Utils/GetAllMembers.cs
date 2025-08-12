using SWAPI.DataManager.People;
using SWAPI.Models;

namespace GetAllMembers;

public static class GetAllMembers
{
    public static void PeopleList(List<Person> listOfPeople)
    {
        if (listOfPeople.Any())
        {
            foreach (var person in listOfPeople)
            {
                Console.WriteLine($"> Person| name: {person.Name}, gender: {person.Gender}, birth year: {person.BirthYear}");
            }
        }
        else
        {
            Console.WriteLine("> No people found.");
        }
    }

    public static void PlanetsList(List<Planet> listOfPlanets)
    {
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

    public static void StarshipList(List<Starship> listOfStarships)
    {
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
}
