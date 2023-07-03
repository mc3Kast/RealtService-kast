using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence.EntityTypeConfigurations.Users;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasKey(token => new { token.UserId, token.LoginProvider, token.Name });

        builder.Property(token => token.LoginProvider).HasMaxLength(256);
        builder.Property(token => token.Name).HasMaxLength(256);

        builder.ToTable("UserTokens");

        //Relations defined in UserConfiguration
    }
}
