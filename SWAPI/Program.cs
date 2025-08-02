using System.Text.Json;
using SWAPI.ValidationData;
using SWAPI.SwapiModels;
using SWAPI.Interfaces;
using SWAPI.Services;

class Program
{
    private static readonly IRequestService _requestService = new RequestService();
    static async Task Main()
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
                    var data = await _requestService.GetAsync<CollectionResponse<Person>>(url);

                    if (data?.Results != null)
                    {
                        foreach (var item in data.Results)
                        {
                            Console.WriteLine($"> Person| name: {item.Name}, gender: {item.Gender}, birth year: {item.Birth_Year}");
                        }
                    }
                }
                else if (category == "planets")
                {
                    var data = await _requestService.GetAsync<CollectionResponse<Planet>>(url);

                    if (data?.Results != null)
                    {
                        foreach (var item in data.Results)
                        {
                            Console.WriteLine($"> Planet| name: {item.Name}, climate: {item.Climate}, terrain: {item.Terrain}");
                        }
                    }
                }
                else if (category == "starships")
                {
                    var data = await _requestService.GetAsync<CollectionResponse<StarShip>>(url);

                    if (data?.Results != null)
                    {
                        foreach (var item in data.Results)
                        {
                            Console.WriteLine($"> Starships| name: {item.Name}, model: {item.Model}, manufacturer: {item.Manufacturer}");
                        }
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

}