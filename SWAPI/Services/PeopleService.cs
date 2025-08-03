using SWAPI.Interfaces;
using SWAPI.Services;

namespace SWAPI.SwapiModels
{
    public class PeopleService : IPeopleService
    {
        private readonly IRequestService _requestService;
        public PeopleService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task GetInformationAboutPeople()
        {
            string url = $"https://swapi.info/api/people";
            var data = await _requestService.GetAsync<CollectionResponse<People>>(url);

            if (data?.Results != null)
            {
                foreach (var item in data.Results)
                {
                    Console.WriteLine($"> Person| name: {item.Name}, gender: {item.Gender}, birth year: {item.Birth_Year}");
                }
            }
        }
    }
}