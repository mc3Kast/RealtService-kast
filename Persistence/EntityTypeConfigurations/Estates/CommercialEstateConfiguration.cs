﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Estates;

public class CommercialEstateConfiguration: IEntityTypeConfiguration<CommercialEstate>
{
    public void Configure(EntityTypeBuilder<CommercialEstate> builder)
    {
        builder.HasBaseType<Estate>();
    }
}
