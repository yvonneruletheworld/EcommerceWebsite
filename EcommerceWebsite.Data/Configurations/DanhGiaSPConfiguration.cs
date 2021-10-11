using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class DanhGiaSPConfiguration : IEntityTypeConfiguration<DanhGiaSP>
    {
        public void Configure(EntityTypeBuilder<DanhGiaSP> builder)
        {
            builder.ToTable("DANHGIASP");

            builder.HasKey(dg => dg.MaDanhGia);

            builder.Property(dg => dg.MaDanhGia)
                .HasMaxLength(100);

            builder.Property(dg => dg.MaSanPham)
              .HasMaxLength(100);

            builder.Property(dg => dg.NoiDung)
                .IsRequired();

            builder.HasOne(dg => dg.sanPhams)
                .WithOne(dg => dg.danhGiaSP)
                .HasForeignKey<DanhGiaSP>(dg => dg.MaSanPham);

        }
    }
}
