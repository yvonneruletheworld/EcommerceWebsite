using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class DanhGiaSanPhamConfiguration : IEntityTypeConfiguration<DanhGiaSanPham>
    {
        public void Configure(EntityTypeBuilder<DanhGiaSanPham> builder)
        {
            builder.ToTable("DANHGIASANPHAM");

            builder.HasKey(dg => dg.MaDanhGia);

            builder.Property(dg => dg.MaDanhGia)
                .HasMaxLength(100);

            builder.Property(dg => dg.MaSanPham)
              .HasMaxLength(100);

            builder.Property(dg => dg.NoiDung)
                .IsRequired();

            builder.HasOne(dg => dg.SanPham)
                .WithOne(dg => dg.DanhGiaSanPham)
                .HasForeignKey<DanhGiaSanPham>(dg => dg.MaSanPham);
        }
    }
}
