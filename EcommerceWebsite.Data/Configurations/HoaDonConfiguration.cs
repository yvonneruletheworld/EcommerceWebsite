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

            builder.HasKey(hd => hd.Id);

            builder.Property(hd => hd.Id)
                .HasMaxLength(100);
            builder.Property(hd => hd.NgayTao)
                .IsRequired();

            builder.Property(hd => hd.MaKhuyenMai)
                .HasMaxLength(100);

            builder.Property(hd => hd.MaDiaChi)
                .HasMaxLength(100);

            builder.Property(hd => hd.PhiGiaoHang)
                .HasColumnType("money");

            builder.Property(hd => hd.ThanhTien)
                .HasColumnType("money");

            builder.Property(hd => hd.TongCong)
                .HasColumnType("money");

            builder.HasOne(hd => hd.KhachHang)
                .WithMany(hd => hd.HoaDons)
                .HasForeignKey(hd => hd.MaKhachHang);

            builder.HasOne(hd => hd.KhuyenMai)
                .WithMany(hd => hd.HoaDons)
                .HasForeignKey(hd => hd.MaKhuyenMai);

            builder.HasOne(hd => hd.DiaChiKhachHang)
                .WithMany(hd => hd.HoaDons)
                .HasForeignKey(hd =>new { hd.MaDiaChi, hd.MaKhachHang });
        }
    }
}
