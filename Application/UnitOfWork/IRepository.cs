using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using RealtService.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.UnitOfWork;

public interface IRepository<TEntity>
    where TEntity : class
{
    TEntity? GetFirstOrDefault();
    TEntity? GetFirstOrDefault(Expression<Func<TEntity, bool>> selector);
    Task<TEntity?> GetFirstOrDefaulAsync();
    Task<TEntity?> GetFirstOrDefaulAsync(Expression<Func<TEntity, bool>> selector);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> selector);
    Task<IQueryable<TEntity>> GetAllAsync();
    Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> selector);
    TEntity? Find(params object[] keyValues);
    Task<TEntity?> FindAsync(params object[] keyValues);
    TEntity Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void Delete(IEnumerable<TEntity> entities);
}
