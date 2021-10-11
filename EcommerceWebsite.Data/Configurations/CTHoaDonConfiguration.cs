using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class CTHoaDonConfiguration : IEntityTypeConfiguration<CTHoaDon>
    {
        public void Configure(EntityTypeBuilder<CTHoaDon> builder)
        {
            builder.ToTable("CTHOADON");

            builder.HasKey(ct => new { ct.MaHoaDon, ct.MaSanPham });

            builder.Property(ct => ct.MaSanPham)
                .HasMaxLength(100);

            builder.Property(ct => ct.MaHoaDon)
                .HasMaxLength(100);

            builder.Property(ct => ct.SoLuong)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(ct => ct.ThanhTien)
                .HasColumnType("money");

            builder.Property(ct => ct.DonGia)
                .HasColumnType("money");

            builder.HasOne(ct => ct.HoaDons)
                .WithMany(ct => ct.cTHoaDons)
                .HasForeignKey(ct => ct.MaHoaDon);

            builder.HasOne(ct => ct.SanPhams)
               .WithMany(ct => ct.cTHoaDons)
               .HasForeignKey(ct => ct.MaSanPham);
        }
    }
}
