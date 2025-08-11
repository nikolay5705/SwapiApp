namespace SWAPI.Services.Requests;

public interface IRequestService
{
    public Task<T> GetAsync<T>(string url);
}
