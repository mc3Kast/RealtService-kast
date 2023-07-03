using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Users;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.HasKey(login => new { login.LoginProvider, login.ProviderKey });

        builder.Property(login => login.LoginProvider)
            .HasMaxLength(256);

        builder.Property(login => login.ProviderKey)
            .HasMaxLength(256);

        builder.ToTable("UserLogins");

        //Relations defined in UserConfiguration
    }
}
