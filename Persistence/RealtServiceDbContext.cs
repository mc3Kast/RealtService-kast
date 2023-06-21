using Microsoft.EntityFrameworkCore;
using RealtService.Application.Interfaces;
using RealtService.Domain.Entities;
using RealtService.Persistence.EntityTypeConfiguration;

namespace RealtService.Persistence
{
    public class RealtServiceDbContext : DbContext, IOfferDbContext
    {
        public DbSet<Offer> Offers { get; set; }
        public RealtServiceDbContext(DbContextOptions<RealtServiceDbContext> options): base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
