using SWAPI.ApiResponses;

namespace SWAPI.Interfaces
{
    public interface IRequestService
    {
        public Task<ApiResponse<T>> GetAsync<T>(string url);
    }

}
