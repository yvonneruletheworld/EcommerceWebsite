using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class ChiTietHoaDonConfiguration : IEntityTypeConfiguration<ChiTietHoaDon>
    {
        public void Configure(EntityTypeBuilder<ChiTietHoaDon> builder)
        {
            builder.ToTable("ChiTietHoaDon");
            builder.HasKey(ct => new { ct.HoaDonId, ct.ProductId});
            builder.Property(hd => hd.SoLuong)
                .HasDefaultValue(0);
            builder.HasOne(ct => ct.Products)
                .WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(ct => ct.ProductId);
            builder.HasOne(ct => ct.HoaDons)
                .WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(ct => ct.HoaDonId);
        }
    }
}
