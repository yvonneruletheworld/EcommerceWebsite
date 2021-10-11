using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HOADON");

            builder.HasKey(hd => hd.MaHoaDon);

            builder.Property(hd => hd.MaHoaDon)
                .HasMaxLength(100);

            builder.Property(hd => hd.MaKhachHang)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(hd => hd.MaKhuyenMai)
                .HasMaxLength(100);

            builder.Property(hd => hd.MaDiaChiKH)
                .HasMaxLength(100);

            builder.Property(hd => hd.PhiGH)
                .HasColumnType("money");

            builder.Property(hd => hd.ThanhTien)
                .HasColumnType("money");

            builder.Property(hd => hd.TongTien)
                .HasColumnType("money");

            builder.HasOne(hd => hd.khachHangs)
                .WithMany(hd => hd.hoaDons)
                .HasForeignKey(hd => hd.MaKhachHang);

            builder.HasOne(hd => hd.khuyenMais)
                .WithMany(hd => hd.hoaDons)
                .HasForeignKey(hd => hd.MaKhuyenMai);

            builder.HasOne(hd => hd.diaChiKHs)
                .WithMany(hd => hd.hoaDons)
                .HasForeignKey(hd =>new { hd.MaDiaChiKH, hd.MaKhachHang });
        }
    }
}
