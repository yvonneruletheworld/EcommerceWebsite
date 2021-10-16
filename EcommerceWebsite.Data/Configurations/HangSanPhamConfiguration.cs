using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class HangSanPhamConfiguration : IEntityTypeConfiguration<XepHangSanPham>
    {
        public void Configure(EntityTypeBuilder<XepHangSanPham> builder)
        {
            builder.ToTable("HANGSANPHAM");

            builder.HasKey(hsp => hsp.MaHang);

            builder.Property(hsp => hsp.MaHang)
                .HasMaxLength(100);

            builder.Property(hsp => hsp.TenHang)
                .IsRequired();
        }
    }
}
