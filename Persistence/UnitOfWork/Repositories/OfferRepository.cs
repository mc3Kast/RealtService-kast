using Microsoft.EntityFrameworkCore;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.UnitOfWork.Repositories;

public class OfferRepository : IRepository<Offer>
{
    private readonly RealtServiceDBContext _context;
    private readonly DbSet<Offer> _offers;

    public OfferRepository(RealtServiceDBContext context)
    {
        _context = context;
        _offers = context.Set<Offer>();
    }

    public void Delete(Offer entity)
    {
        _offers.Remove(entity);
    }

    public void Delete(IEnumerable<Offer> entities)
    {
        _offers.RemoveRange(entities);
    }

    public Offer? Find(params object[] keyValues)
    {
        return _offers.Find(keyValues);
    }

    public Task<Offer?> FindAsync(params object[] keyValues)
    {
        return _offers.FindAsync(keyValues).AsTask();
    }
    public async Task<Offer?> GetByIdAsync(int id)
    {
        return await _offers.FindAsync(id);
    }

    public IQueryable<Offer> GetAll()
    {
        return _offers.AsQueryable();
    }

    public IQueryable<Offer> GetAll(Expression<Func<Offer, bool>> selector)
    {
        return _offers.Where(selector).AsQueryable();
    }

    public Task<IQueryable<Offer>> GetAllAsync()
    {
        return Task.Run(_offers.AsQueryable);
    }

    public Task<IQueryable<Offer>> GetAllAsync(Expression<Func<Offer, bool>> selector)
    {
        return Task.Run(_offers.Where(selector).AsQueryable);
    }

    public Task<Offer?> GetFirstOrDefaulAsync()
    {
        return _offers.FirstOrDefaultAsync();
    }

    public Task<Offer?> GetFirstOrDefaulAsync(Expression<Func<Offer, bool>> selector)
    {
        return _offers.FirstOrDefaultAsync(selector);
    }

    public Offer? GetFirstOrDefault()
    {
        return _offers.FirstOrDefault();
    }

    public Offer? GetFirstOrDefault(Expression<Func<Offer, bool>> selector)
    {
        return _offers.FirstOrDefault(selector);
    }

    public Offer Insert(Offer entity)
    {
        _offers.Add(entity);
        return entity;
    }

    public void Update(Offer entity)
    {
        _offers.Update(entity);
    }
}
