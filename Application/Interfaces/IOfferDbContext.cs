using Microsoft.EntityFrameworkCore;
using RealtService.Domain.Entities;

namespace RealtService.Application.Interfaces;

//Deprecated, update with persistence level later
public interface IOfferDbContext
{
    DbSet<Offer> Offers { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
}
