using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Terms;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence;

public class RealtServiceDBContext : IdentityDbContext<User, UserRole, int, UserClaim, UserBelongsToRole, UserLogin, RoleClaim, UserToken>
{
    public DbSet<Offer> Offers { get; set; }
    public DbSet<ResidentialOffer> ResidentialOffers { get; set; }
    public DbSet<CommercialOffer> CommercialOffers { get; set; }
    public DbSet<Term> Terms { get; set; }
    public DbSet<CommercialTerm> CommercialTerms { get; set; }
    public DbSet<CommercialSale> CommercialSales { get; set; }
    public DbSet<CommercialLeasing> CommercialLeasings { get; set; }
    public DbSet<ResidentialTerm> ResidentialTerms { get; set; }
    public DbSet<ResidentialSale> ResidentialSales { get; set; }
    public DbSet<ResidentialLeasing> ResidentialLeasings { get; set; }

    //Other UserRelated DbSets Defined in IdentityDbContext
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Agency> Agencies { get; set; }
    public DbSet<UserContact> UserContacts { get; set; }
    public RealtServiceDBContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(RealtServiceDBContext).Assembly);
    }
}
