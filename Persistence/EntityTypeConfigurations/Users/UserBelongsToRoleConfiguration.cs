using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence.EntityTypeConfigurations.Users;

public class UserBelongsToRoleConfiguration : IEntityTypeConfiguration<UserBelongsToRole>
{
    public void Configure(EntityTypeBuilder<UserBelongsToRole> builder)
    {
        builder.ToTable("M2M_Users_Roles");
    }
}
