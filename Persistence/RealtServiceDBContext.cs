using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence;

public class RealtServiceDBContext: DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Agency> Agencies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserStatus> UserStatuses { get; set; }
    public DbSet<UserContact> UserContacts { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<ResidentialOffer> ResidentialOffers { get; set; }
    public DbSet<CommercialOffer> CommercialOffers { get; set; }


    public RealtServiceDBContext(DbContextOptions options) : base(options) 
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
