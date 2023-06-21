using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;

public class ResidentialTermConfiguration : IEntityTypeConfiguration<ResidentialTerm>
{
    public void Configure(EntityTypeBuilder<ResidentialTerm> builder)
    {
        builder.HasBaseType<Term>();
    }
}
