using SWAPI.SwapiModels;

namespace SWAPI.SwapiModels
{
    public class CollectionResponse<T> 
    {
        public List<T> Results = new List<T>();
    }
}