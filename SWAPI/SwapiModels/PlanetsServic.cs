using SWAPI.Interfaces;
using SWAPI.Services;

namespace SWAPI.SwapiModels
{
    public class PlanetService : IPlanetsService
    {
        private static readonly IRequestService _requestService = new RequestService();
        public async void GetInformationAboutPlanet(string url)
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
    }
}