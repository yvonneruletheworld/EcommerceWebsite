using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class DiaChiKHConfiguration : IEntityTypeConfiguration<DiaChiKH>
    {
        public void Configure(EntityTypeBuilder<DiaChiKH> builder)
        {
            builder.ToTable("DIACHIKH");

            builder.HasKey(dc =>new { dc.MaDiaChiKH, dc.MaKhachHang });

            builder.Property(dc => dc.MaDiaChiKH)
                .HasMaxLength(100);

            builder.Property(dc => dc.MaKhachHang)
                .HasMaxLength(100);

            builder.Property(dc => dc.DiaChiGH)
                .IsRequired();

            builder.Property(dc => dc.SDT)
                .HasMaxLength(11)
                .IsRequired();

            //Khóa ngoại
            builder.HasOne(xl => xl.khachHang)
                 .WithMany(xl => xl.diaChiKHs)
                 .HasForeignKey(dl => dl.MaKhachHang);
        }
    }
}
