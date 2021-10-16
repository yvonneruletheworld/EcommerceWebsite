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

            builder.HasKey(kh => kh.Id);

            builder.Property(kh => kh.Id)
                .HasMaxLength(100);
            builder.Property(kh => kh.Username)
                .HasMaxLength(20).IsRequired();

            builder.Property(Kh => Kh.HoTen)
                .HasMaxLength(200)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(kh => kh.Sdt)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(kh => kh.Email)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
