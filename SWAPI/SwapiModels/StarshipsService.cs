using SWAPI.Interfaces;
using SWAPI.Services;


namespace SWAPI.SwapiModels
{
    public class StarshipsService : IStarshipsService
    {
        private static readonly IRequestService _requestService = new RequestService();
        public async void GetInformationAboutStarships(string url)
        {
            var data = await _requestService.GetAsync<CollectionResponse<Starship>>(url);

            if (data?.Results != null)
            {
                foreach (var item in data.Results)
                {
                    Console.WriteLine($"> Starships| name: {item.Name}, model: {item.Model}, manufacturer: {item.Manufacturer}");
                }
            }
        }

    }
}