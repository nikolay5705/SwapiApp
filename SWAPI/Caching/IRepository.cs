using SWAPI.Models.Entities;

namespace SWAPI.Caching;

public interface IRepository<T>
    where T : IEntity
{
    T? GetById(string id);

    void Add(T item);

    void AddRange(IEnumerable<T> items);

    List<T> GetAll();

    void Delete(T item);

    void Clean();
}
