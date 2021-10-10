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

            builder.HasKey(gh => gh.MaGH);

            builder.Property(gh => gh.MaGH)
                .HasMaxLength(100);

            builder.Property(gh => gh.MaHD)
                .HasMaxLength(100);

            builder.HasOne(gh => gh.hoaDon)
                .WithOne(gh => gh.giaoHang)
                .HasForeignKey<GiaoHang>(gh => gh.MaHD);
        }
    }
}
