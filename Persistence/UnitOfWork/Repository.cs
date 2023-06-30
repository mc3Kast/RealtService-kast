using Microsoft.EntityFrameworkCore;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.UnitOfWork;

public class Repository<T> : IRepository<T>
    where T : class
{
    private readonly DbSet<T> _entities;

    public Repository(DbSet<T> entities)
    {
        _entities = entities;
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }

    public void Delete(IEnumerable<T> entities)
    {
        _entities.RemoveRange(entities);
    }

    public T? Find(params object[] keyValues)
    {
        return _entities.Find(keyValues);
    }

    public Task<T?> FindAsync(params object[] keyValues)
    {
        return _entities.FindAsync(keyValues).AsTask();
    }

    public IQueryable<T> GetAll()
    {
        return _entities.AsQueryable();
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> selector)
    {
        return _entities.Where(selector).AsQueryable();
    }

    public Task<IQueryable<T>> GetAllAsync()
    {
        return Task.Run(_entities.AsQueryable);
    }

    public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> selector)
    {
        return Task.Run(_entities.Where(selector).AsQueryable);
    }

    public Task<T?> GetFirstOrDefaulAsync()
    {
        return _entities.FirstOrDefaultAsync();
    }

    public Task<T?> GetFirstOrDefaulAsync(Expression<Func<T, bool>> selector)
    {
        return _entities.FirstOrDefaultAsync(selector);
    }

    public T? GetFirstOrDefault()
    {
        return _entities.FirstOrDefault();
    }

    public T? GetFirstOrDefault(Expression<Func<T, bool>> selector)
    {
        return _entities.FirstOrDefault(selector);
    }

    public T Insert(T entity)
    {
        _entities.Add(entity);
        return entity;
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
    }
}
