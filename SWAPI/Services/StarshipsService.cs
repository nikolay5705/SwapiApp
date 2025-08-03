using SWAPI.Interfaces;
using SWAPI.Services;


namespace SWAPI.SwapiModels
{
    public class StarshipsService : IStarshipsService
    {
        private readonly IRequestService _requestService;
        public StarshipsService(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public async Task GetInformationAboutStarships()
        {
            string url = $"https://swapi.info/api/starships";
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