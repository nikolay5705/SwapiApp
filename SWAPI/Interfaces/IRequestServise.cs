namespace SWAPI.Interfaces
{
    public interface IRequestService
    {
           public Task<T> GetAsync<T>(string url);
    }

}
