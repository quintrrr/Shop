using System.Text;
using Core.Interfaces;

namespace Core.Classes;

public abstract class FileRepositoryBase<T> : IRepository<T> where T : IPrimary
{
    protected abstract string Path { get; }

    public void Create(T entity)
    {
        var entityList = ReadAll();
        if (entityList.Any(e => e.Id == entity.Id)) return;
        entityList.Add(entity);
        Save(entityList);
    }

    public T? Read(Guid id) => ReadAll().FirstOrDefault(e => e.Id == id);

    public List<T> ReadAll()
    {
        if (!System.IO.File.Exists(Path)) return new List<T>();
        var fileContent = System.IO.File.ReadAllText(Path);
        return Deserialize(fileContent);
    }

    public void Update(T entity)
    {
        var entityList = ReadAll();
        var entityIndex = entityList.FindIndex(e => e.Id == entity.Id);
        if (entityIndex == -1) return;
        entityList[entityIndex] = entity;
        Save(entityList);
    }

    public void Delete(Guid id)
    {
        var entityList = ReadAll();
        var entity = entityList.FirstOrDefault(e => e.Id == id);
        if (entity is null) return;
        entityList.Remove(entity);
        Save(entityList);
    }

    private void Save(List<T> entities)
    {
        System.IO.File.WriteAllText(Path, Serialize(entities), Encoding.UTF8);
    }
    
    protected abstract List<T> Deserialize(string text);
    protected abstract string Serialize(List<T> list);
}