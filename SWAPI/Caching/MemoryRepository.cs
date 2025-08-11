using SWAPI.Models.Entities;

namespace SWAPI.Caching;

public class MemoryRepository<T>() : IRepository<T>
where T : IEntity
{
    private readonly List<T> _cacheStorage = new List<T>();

    public void Add(T item)
    {
        _cacheStorage.Add(item);
    }

    public void AddRange(IEnumerable<T> items)
    {
        _cacheStorage.AddRange(items);
    }

    public List<T> GetAll()
    {
        return new List<T>(_cacheStorage);
    }

    public T? GetById(string id)
    {
        return _cacheStorage.FirstOrDefault(e => e.Id == id);
    }

    public void Delete(T item)
    {
        _cacheStorage.Remove(item);
    }

    public void Clean()
    {
        _cacheStorage.Clear();
    }
}
