using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities;

namespace RealtService.Persistence.EntityTypeConfiguration
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(offer => offer.Id);
            builder.HasIndex(offer => offer.Id).IsUnique();
            builder.Property(offer => offer.Title).HasMaxLength(250);
        }
    }
}
