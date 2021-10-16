using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class MauSanPhamConfiguration : IEntityTypeConfiguration<MauMaSanPham>
    {
        public void Configure(EntityTypeBuilder<MauMaSanPham> builder)
        {
            builder.ToTable("MAUMASANPHAM");

            builder.HasKey(msp => new { msp.MaSanPham, msp.TenMauMa });

            builder.Property(msp => msp.MaSanPham)
                .HasMaxLength(100);

            builder.Property(msp => msp.TenMauMa)
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

            builder.HasOne(msp => msp.SanPham)
                .WithMany(msp => msp.MauMaSanPhams)
                .HasForeignKey(msp => msp.MaSanPham);

        }
    }
}
