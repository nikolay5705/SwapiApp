using System.Text.Json;
using SWAPI.ApiResponses;
using SWAPI.ValidationData;

class Program
{
    static async Task Main()
    {
        using HttpClient client = new HttpClient();

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

            if (ValidationData.ContainsAnyCategory(category))
            {
                Console.WriteLine("> Incorrect category");
                continue;
            }
            string url = $"https://swapi.info/api/{category}";

            Console.WriteLine("loading...");

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<ApiResponse>(responseBody);

                if (data?.Results != null)
                {
                    List<string> items = new List<string>();
                    foreach (var item in data.Results)
                    {
                        items.Add(item.Name);
                    }
                    Console.WriteLine(string.Join(", ", items));
                }
                else
                {
                    Console.WriteLine("Something wrong with getting data.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception: {exception.Message}");
            }

            Console.WriteLine();
        }
    }

}