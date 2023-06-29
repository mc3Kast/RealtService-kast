using Microsoft.EntityFrameworkCore;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Users;
using System.Linq.Expressions;

namespace RealtService.Persistence.UnitOfWork.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly RealtServiceDBContext _context;
    private readonly DbSet<User> _users;

    public UserRepository(RealtServiceDBContext context)
    {
        _context = context;
        _users = _context.Set<User>();
    }

    public void Delete(User entity)
    {
        _users.Remove(entity);
    }

    public void Delete(IEnumerable<User> entities)
    {
        _users.RemoveRange(entities);
    }

    public User? Find(params object[] keyValues)
    {
        return _users.Find(keyValues);
    }

    public Task<User?> FindAsync(params object[] keyValues)
    {
        return _users.FindAsync(keyValues).AsTask();
    }
    public async Task<User?> GetByIdAsync(int id)
    {
        return await _users.FindAsync(id);
    }

    public IQueryable<User> GetAll()
    {
        return _users.AsQueryable();
    }

    public IQueryable<User> GetAll(Expression<Func<User, bool>> selector)
    {
        return _users.Where(selector).AsQueryable();
    }

    public Task<IQueryable<User>> GetAllAsync()
    {
        return Task.Run(_users.AsQueryable);
    }

    public Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> selector)
    {
        return Task.Run(_users.Where(selector).AsQueryable);
    }

    public Task<User?> GetFirstOrDefaulAsync()
    {
        return _users.FirstOrDefaultAsync();
    }

    public Task<User?> GetFirstOrDefaulAsync(Expression<Func<User, bool>> selector)
    {
        return _users.FirstOrDefaultAsync(selector);
    }

    public User? GetFirstOrDefault(Expression<Func<User, bool>> selector)
    {
        return _users.FirstOrDefault(selector);
    }

    public User? GetFirstOrDefault()
    {
        return _users.FirstOrDefault();
    }

    public User Insert(User entity)
    {
        _users.Add(entity);
        return entity;
    }

    public void Update(User entity)
    {
       _users.Update(entity);
    }
}
