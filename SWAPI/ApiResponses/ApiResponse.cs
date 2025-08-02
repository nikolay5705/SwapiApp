using SWAPI.SwapiModels;

namespace SWAPI.ApiResponses
{
    public class ApiResponse<T> 
    {
        public List<T> Results = new List<T>();
    }
}