using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class DiaChiKhachHangConfiguration : IEntityTypeConfiguration<DiaChiKhachHang>
    {
        public void Configure(EntityTypeBuilder<DiaChiKhachHang> builder)
        {
            builder.ToTable("DIACHIKHACHHANG");

            builder.HasKey(dc =>new { dc.MaDiaChi, dc.MaKhachHang });

            builder.Property(dc => dc.MaDiaChi)
                .HasMaxLength(100);

            builder.Property(dc => dc.MaKhachHang)
                .HasMaxLength(100);

            builder.Property(dc => dc.SDT)
                .HasMaxLength(11)
                .IsRequired();

            //Khóa ngoại
            builder.HasOne(xl => xl.KhachHang)
                 .WithMany(xl => xl.DiaChiKhachHangs)
                 .HasForeignKey(dl => dl.MaKhachHang);
        }
    }
}
