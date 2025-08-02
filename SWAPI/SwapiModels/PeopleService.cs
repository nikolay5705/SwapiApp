using SWAPI.Interfaces;
using SWAPI.Services;

namespace SWAPI.SwapiModels
{
    public class PeopleService : IPeopleService
    {
        private static readonly IRequestService _requestService = new RequestService();
        public async void GetInformationAboutPeople(string url)
        {
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