using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class MauSanPhamConfiguration : IEntityTypeConfiguration<MauSanPham>
    {
        public void Configure(EntityTypeBuilder<MauSanPham> builder)
        {
            builder.ToTable("MAUSANPHAM");

            builder.HasKey(msp => new { msp.MaSanPham, msp.TenMau });

            builder.Property(msp => msp.MaSanPham)
                .HasMaxLength(100);

            builder.Property(msp => msp.TenMau)
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

            builder.HasOne(msp => msp.sanPham)
                .WithMany(msp => msp.mauSanPhams)
                .HasForeignKey(msp => msp.MaSanPham);

        }
    }
}
