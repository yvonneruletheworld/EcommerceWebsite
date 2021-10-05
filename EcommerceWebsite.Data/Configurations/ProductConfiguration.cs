using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.Stock)
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.Property(p => p.Const)
                    .IsRequired();

            builder.Property(p => p.ViewCount)
                    .IsRequired()
                    .HasDefaultValue(0);
                   
        }
    }
}
