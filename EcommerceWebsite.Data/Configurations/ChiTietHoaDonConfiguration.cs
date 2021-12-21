using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class ChiTietHoaDonConfiguration : IEntityTypeConfiguration<ChiTietHoaDon>
    {
        public void Configure(EntityTypeBuilder<ChiTietHoaDon> builder)
        {
            builder.ToTable("CHITIETHOADON");

            builder.HasKey(ct => new { ct.ProductId, ct.HoaDonId, ct.MaHUI });

            builder.Property(ct => ct.ProductId)
                .HasMaxLength(100);
            builder.Property(ct => ct.HoaDonId)
                .HasMaxLength(100);
            
            builder.Property(ct => ct.MaHUI)
                .HasMaxLength(100);

            builder.Property(ct => ct.SoLuong)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(ct => ct.GiaBan)
                .HasColumnType("money");

            builder.HasOne(ct => ct.HoaDons)
                .WithMany(ct => ct.ChiTietHoaDons)
                .HasForeignKey(ct => ct.HoaDonId);

            builder.HasOne(ct => ct.SanPhams)
               .WithMany(ct => ct.ChiTietHoaDons)
               .HasForeignKey(ct => ct.ProductId);
        }
    }
}
