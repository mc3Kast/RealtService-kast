using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Base;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<Offer> Offers { get; }
    IRepository<ResidentialOffer> ResidentialOffers { get; }
    IRepository<CommercialOffer> CommercialOffers { get; }
    IRepository<User> Users { get; }
    IRepository<Shop> Shops { get; }
    IRepository<Office> Offices { get; }
    IRepository<Restaurant> Restaurants { get; }
    IRepository<Estate> Estates { get; }
    IRepository<CommercialEstate> CommercialEstates { get; }
    IRepository<ResidentialEstate> ResidentialEstates { get; }
    IRepository<Warehouse> Warehouses { get; }
    IRepository<House> Houses { get; }
    IRepository<Rooms> Rooms { get; }
    IRepository<Flat> Flats { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync();
}