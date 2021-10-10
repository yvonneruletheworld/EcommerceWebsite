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

            builder.HasKey(ct => new { ct.MaHD, ct.MaSP });

            builder.Property(ct => ct.MaSP)
                .HasMaxLength(100);

            builder.Property(ct => ct.MaHD)
                .HasMaxLength(100);

            builder.Property(ct => ct.SoLuong)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(ct => ct.ThanhTien)
                .HasColumnType("money");

            builder.Property(ct => ct.DonGia)
                .HasColumnType("money");

            builder.HasOne(ct => ct.hoaDon)
                .WithMany(ct => ct.cTHoaDons)
                .HasForeignKey(ct => ct.MaHD);

            builder.HasOne(ct => ct.sanPham)
               .WithMany(ct => ct.cTHoaDons)
               .HasForeignKey(ct => ct.MaSP);
        }
    }
}
