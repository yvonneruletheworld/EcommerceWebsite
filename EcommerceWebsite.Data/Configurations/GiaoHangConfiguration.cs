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

            builder.HasKey(gh => gh.MaGiaoHang);

            builder.Property(gh => gh.MaGiaoHang)
                .HasMaxLength(100);

            builder.Property(gh => gh.MaHoaDon)
                .HasMaxLength(100);

            builder.HasOne(gh => gh.HoaDon)
                .WithOne(gh => gh.GiaoHang)
                .HasForeignKey<GiaoHang>(gh => gh.MaHoaDon);
        }
    }
}
