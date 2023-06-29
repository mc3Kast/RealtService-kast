using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Base;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Terms;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence;

public class RealtServiceDBContext : DbContext
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
    public DbSet<Term> Terms { get; set; }
    public DbSet<CommercialTerm> CommercialTerms { get; set; }
    public DbSet<CommercialSale> CommercialSales { get; set; }
    public DbSet<CommercialLeasing> CommercialLeasings { get; set; }
    public DbSet<CommercialLeasingRequirement> CommercialLeasingRequirements { get; set; }
    public DbSet<ResidentialTerm> ResidentialTerms { get; set; }
    public DbSet<ResidentialSale> ResidentialSales { get; set; }
    public DbSet<ResidentialLeasing> ResidentialLeasings { get; set; }
    public DbSet<ResidentialLeasingRequirement> ResidentialLeasingRequirements { get; set; }

    public RealtServiceDBContext(DbContextOptions options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RealtServiceDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}
