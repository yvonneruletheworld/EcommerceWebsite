using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class KhuyenMaiConfiguration : IEntityTypeConfiguration<KhuyenMai>
    {
        public void Configure(EntityTypeBuilder<KhuyenMai> builder)
        {
            builder.ToTable("KHUYENMAI");

            builder.HasKey(km => km.MaKM);

            builder.Property(km => km.MaKM)
                .HasMaxLength(100);

            builder.Property(km => km.TenKM)
                .IsRequired();

            builder.Property(km => km.PhanTram)
                .HasDefaultValue(0);

        }
    }
}
