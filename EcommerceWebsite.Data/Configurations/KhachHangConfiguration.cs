using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KHACHHANG");

            builder.HasKey(kh => kh.MaKhachHang);

            builder.Property(kh => kh.MaKhachHang)
                .HasMaxLength(100);

            builder.Property(Kh => Kh.HoTen)
                .HasMaxLength(200)
                .HasColumnType("nvarchar")
                .IsRequired();

        }
    }
}
