using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class SanPhamConfiguration : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SANPHAM");
            builder.HasKey(sp => sp.MaSP);

            builder.Property(sp => sp.MaSP)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(sp => sp.TenSP)
                .HasMaxLength(500)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(sp => sp.SoLuongTon)
                  .IsRequired()
                  .HasColumnType("int")
                  .HasDefaultValue(0);

            builder.Property(sp => sp.MaLoaiSP)
                 .IsRequired()
                 .HasMaxLength(100)
                 .HasDefaultValue(0);

            builder.HasOne(sp => sp.loaiSanPhams)
                  .WithMany(sp => sp.sanPhams)
                  .HasForeignKey(sp => sp.MaLoaiSP);

            builder.HasOne(sp => sp.hangSanPhams)
                 .WithMany(sp => sp.sanPhams)
                 .HasForeignKey(sp => sp.MaHang);

        }
    }
}
