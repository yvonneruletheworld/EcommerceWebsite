﻿using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class BoPhanConfiguration : IEntityTypeConfiguration<BoPhan>
    {
        public void Configure(EntityTypeBuilder<BoPhan> builder)
        {
            builder.ToTable("BOPHAN");

            builder.HasKey(bp => bp.MaBP);

            builder.Property(bp => bp.MaBP)
                .HasMaxLength(100);

            builder.Property(bp => bp.TenBP)
                .IsRequired();
        }
    }
}
