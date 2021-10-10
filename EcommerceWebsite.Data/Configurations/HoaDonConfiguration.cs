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

            builder.HasKey(hd => hd.MaHD);

            builder.Property(hd => hd.MaHD)
                .HasMaxLength(100);

            builder.Property(hd => hd.MaKH)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(hd => hd.MaKM)
                .HasMaxLength(100);

            builder.Property(hd => hd.MaDiaChiKH)
                .HasMaxLength(100);

            builder.Property(hd => hd.PhiGH)
                .HasColumnType("money");

            builder.Property(hd => hd.ThanhTien)
                .HasColumnType("money");

            builder.Property(hd => hd.TongTien)
                .HasColumnType("money");

            builder.HasOne(hd => hd.khachHang)
                .WithMany(hd => hd.hoaDons)
                .HasForeignKey(hd => hd.MaKH);

            builder.HasOne(hd => hd.khuyenMai)
                .WithMany(hd => hd.hoaDons)
                .HasForeignKey(hd => hd.MaKM);

            builder.HasOne(hd => hd.diaChiKH)
                .WithMany(hd => hd.hoaDons)
                .HasForeignKey(hd =>new { hd.MaDiaChiKH, hd.MaKH });
        }
    }
}
