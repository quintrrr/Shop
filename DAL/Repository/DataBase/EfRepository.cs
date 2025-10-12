using Core.Classes;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.DataBase;

public class EfRepository<T> : EfRepositoryBase<T> where T : class, IPrimary
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    protected EfRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    
    protected override void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    protected override T? GetById(Guid id)
    {
        return _dbSet.AsNoTracking().FirstOrDefault(e => e.Id == id);
    }

    protected override List<T> GetAll()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    protected override void UpdateEntity(T entity)
    {
        var local = _dbSet.Local.FirstOrDefault(e => e.Id == entity.Id);
        if (local is not null)
        {
            _dbContext.Entry(local).State = EntityState.Detached;
        }
        
        _dbSet.Update(entity);
    }

    protected override void DeleteEntity(T entity)
    {
        var local = _dbSet.Local.FirstOrDefault(e => e.Id == entity.Id);
        if (local is not null)
        {
            _dbContext.Entry(local).State = EntityState.Detached;
        }
        
        _dbSet.Remove(entity);
    }

    protected override void Save()
    {
        _dbContext.SaveChanges();
    }
}