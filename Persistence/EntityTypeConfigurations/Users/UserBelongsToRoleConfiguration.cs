using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Users;

public class UserBelongsToRoleConfiguration : IEntityTypeConfiguration<UserBelongsToRole>
{
    public void Configure(EntityTypeBuilder<UserBelongsToRole> builder)
    {
        builder.ToTable("M2M_Users_Roles");
    }
}
