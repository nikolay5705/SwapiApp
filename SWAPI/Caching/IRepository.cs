namespace SWAPI.Caching
{
    public interface IRepository<T>
    {
        void Add(T item);

        void Add(IEnumerable<T> items);

        List<T> GetAll();

        void Delete(T item);

        void Clean();
    }
}