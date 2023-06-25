using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using RealtService.Domain.Entities.Base;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity>? GetRepository<TEntity>() where TEntity : class;
    int SaveChanges();
    Task<int> SaveChangesAsync();
}