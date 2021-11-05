using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class NhanHieuConfiguration : IEntityTypeConfiguration<NhanHieu>
    {
        public void Configure(EntityTypeBuilder<NhanHieu> builder)
        {
            builder.ToTable("NHANHIEU");

            builder.HasKey(hsp => hsp.MaHang);

            builder.Property(sp => sp.MaHang)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(hsp => hsp.TenHang)
                .IsRequired();

        }
    }
}
