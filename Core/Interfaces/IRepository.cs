namespace Core.Interfaces;

public interface IRepository<T>
{
    void Create(T entity);
    T? Read(Guid id);
    List<T> ReadAll();
    void Update(T entity);
    void Delete(Guid id);
}