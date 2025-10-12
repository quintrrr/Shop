using Core.Interfaces;

namespace Core.Classes;

public abstract class EfRepositoryBase<T> : IRepository<T> where T : class, IPrimary
{
    public void Create(T entity)
    {
        if (Read(entity.Id) is not null) return;
        Add(entity);
        Save();
    }

    public T? Read(Guid id)
    {
        return GetById(id);
    }

    public List<T> ReadAll()
    {
        return GetAll();
    }

    public void Update(T entity)
    {
        UpdateEntity(entity);
        Save();
    }

    public void Delete(Guid id)
    {
        var entity = GetById(id);
        if (entity == null) return;
        
        DeleteEntity(entity);
        Save();
    }
    
    protected abstract void Add(T entity);
    protected abstract T? GetById(Guid id);
    protected abstract List<T> GetAll();
    protected abstract void UpdateEntity(T entity);
    protected abstract void DeleteEntity(T entity);
    protected abstract void Save();
    
}