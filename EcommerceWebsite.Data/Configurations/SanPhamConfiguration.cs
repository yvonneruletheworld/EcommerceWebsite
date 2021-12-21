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
            builder.HasKey(sp => sp.MaSanPham);

            builder.Property(sp => sp.MaSanPham)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(sp => sp.TenSanPham)
                .HasMaxLength(500)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(sp => sp.SoLuongTon)
                  .IsRequired()
                  .HasColumnType("int")
                  .HasDefaultValue(0);

            builder.Property(sp => sp.MaLoaiSanPham)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(sp => sp.MaHang)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(sp => sp.DanhMuc)
                  .WithMany(sp => sp.SanPhams)
                  .HasForeignKey(sp => sp.MaLoaiSanPham);

            builder.HasOne(sp => sp.NhanHieuEnti)
                 .WithMany(sp => sp.SanPhams)
                 .HasForeignKey(sp => sp.MaHang);

        }
    }
}
