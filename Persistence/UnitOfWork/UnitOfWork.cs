using Microsoft.EntityFrameworkCore;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Users;
using RealtService.Persistence.UnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly RealtServiceDBContext _dbContext;
    private readonly Dictionary<Type, IRepository> _repositories = new();
    public UnitOfWork(
        RealtServiceDBContext realtServiceDBContext,
        OfferRepository offerRepository,
        UserRepository userRepository
    ) 
    { 
        _dbContext = realtServiceDBContext;
        _repositories.Add(typeof(User), userRepository);
        _repositories.Add(typeof(Offer), offerRepository);
    }
    
    public IRepository<TEntity>? GetRepository<TEntity>() where TEntity : class
    {
        _repositories.TryGetValue(typeof(TEntity), out IRepository? repository);
        return (IRepository<TEntity>?)repository;
    }

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    #region IDisposable
    private bool _disposed;
    protected virtual void Dispose(bool manual)
    {
        if (_disposed)
            return;
        if (manual)
        {
            _dbContext.Dispose();
        }
        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}
