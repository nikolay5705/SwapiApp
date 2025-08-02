using SWAPI.SwapiModels;

namespace SWAPI.Interfaces
{
    public interface IRequestService
    {
        
        public Task<CollectionResponse<T>> GetAsync<T>(string url);
    }

}
