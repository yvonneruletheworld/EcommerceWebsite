using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                    .HasMaxLength(100);

            builder.Property(p => p.Name)
                   .IsRequired().HasMaxLength(200)
                   .HasColumnType("nvarchar");

            builder.Property(p => p.Stock)
                   .IsRequired()
                   .HasColumnType("INT")
                   .HasDefaultValue(0);

            builder.Property(p => p.Const)
                    .HasColumnType("money")
                    .IsRequired();
            
            builder.Property(p => p.Price)
                    .HasColumnType("money");

            builder.Property(p => p.ViewCount)
                    .HasDefaultValue(0);
            builder.Property(p => p.Brand)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(100);
                   
        }
    }
}
