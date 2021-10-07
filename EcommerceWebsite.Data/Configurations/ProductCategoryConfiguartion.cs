using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class ProductCategoryConfiguartion : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory");
            builder.HasKey(pc => new { pc.CategoryId, pc.ProductId });

            builder.HasOne(pc => pc.Product)
                   .WithMany(pc => pc.ProductCategories)
                   .HasForeignKey(pc => pc.ProductId);

            builder.HasOne(pc => pc.Category)
                   .WithMany(pc => pc.ProductCategories)
                   .HasForeignKey(pc => pc.CategoryId);
            //builder.HasOne( )
        }
    }
}
