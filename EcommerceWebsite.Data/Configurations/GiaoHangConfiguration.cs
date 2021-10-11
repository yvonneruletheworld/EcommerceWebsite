using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class GiaoHangConfiguration : IEntityTypeConfiguration<GiaoHang>
    {
        public void Configure(EntityTypeBuilder<GiaoHang> builder)
        {
            builder.ToTable("GIAOHANG");

            builder.HasKey(gh => gh.MaGiaoHanh);

            builder.Property(gh => gh.MaGiaoHanh)
                .HasMaxLength(100);

            builder.Property(gh => gh.MaHoaDon)
                .HasMaxLength(100);

            builder.Property(gh => gh.NgayDuKienGiao)
                .HasColumnType("DateTime");

            builder.Property(gh => gh.NgayGiao)
                .HasColumnType("DateTime");

            builder.HasOne(gh => gh.hoaDons)
                .WithOne(gh => gh.giaoHang)
                .HasForeignKey<GiaoHang>(gh => gh.MaHoaDon);
        }
    }
}
