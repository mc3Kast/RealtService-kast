using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly RealtServiceDBContext _dbContext;

    public UnitOfWork(
        RealtServiceDBContext realtServiceDBContext,
        IRepository<Offer> offers,
        IRepository<User> users,
        IRepository<Office> offices,
        IRepository<Shop> shops,
        IRepository<Restaurant> restaurants,
        IRepository<Warehouse> warehouses,
        IRepository<House> houses,
        IRepository<Rooms> rooms,
        IRepository<Flat> flats,
        IRepository<Estate> estates,
        IRepository<CommercialEstate> commercialStates,
        IRepository<ResidentialEstate> residentialStates,
        IRepository<ResidentialOffer> residentialOffers,
        IRepository<CommercialOffer> commercialOffers
    ) 
    { 
        _dbContext = realtServiceDBContext;
        Offers = offers;
        Users = users;
        Offices = offices;
        Shops = shops;
        Restaurants = restaurants;
        Warehouses = warehouses;
        Rooms = rooms;
        Houses = houses;
        Flats = flats;
        Estates = estates;
        CommercialEstates = commercialStates;
        ResidentialEstates = residentialStates;
        ResidentialOffers = residentialOffers;
        CommercialOffers = commercialOffers;
    }

    #region repositories
    public IRepository<Offer> Offers { get; }
    public IRepository<User> Users { get; }
    public IRepository<Shop> Shops { get; }
    public IRepository<Office> Offices { get; }
    public IRepository<Restaurant> Restaurants { get; }
    public IRepository<Warehouse> Warehouses { get; }
    public IRepository<House> Houses { get; }
    public IRepository<Rooms> Rooms { get; }
    public IRepository<Flat> Flats { get; }
    public IRepository<Estate> Estates { get; }
    public IRepository<CommercialEstate> CommercialEstates { get; }
    public IRepository<ResidentialEstate> ResidentialEstates { get; }
    public IRepository<ResidentialOffer> ResidentialOffers { get; }
    public IRepository<CommercialOffer> CommercialOffers { get; }

    #endregion
    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }

    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
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
