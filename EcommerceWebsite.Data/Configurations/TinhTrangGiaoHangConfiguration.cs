using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class TinhTrangGiaoHangConfiguration : IEntityTypeConfiguration<TinhTrangGiaoHang>
    {
        public void Configure(EntityTypeBuilder<TinhTrangGiaoHang> builder)
        {
            builder.ToTable("TINHTRANGIAOHANG");

            builder.HasKey(tt => new { tt.MaGiaoHang, tt.MaTinhTrangGiaoHang });

            builder.Property(tt => tt.MaGiaoHang)
                .HasMaxLength(100);

            builder.Property(tt => tt.MaTinhTrangGiaoHang)
               .HasMaxLength(100);

            builder.HasOne(tt => tt.GiaoHang)
                .WithMany(tt => tt.TinhTrangGiaoHangs)
                .HasForeignKey(tt => tt.MaGiaoHang);

        }
    }
}
