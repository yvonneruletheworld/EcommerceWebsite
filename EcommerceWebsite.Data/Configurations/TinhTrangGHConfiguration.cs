using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class TinhTrangGHConfiguration : IEntityTypeConfiguration<TinhTrangGH>
    {
        public void Configure(EntityTypeBuilder<TinhTrangGH> builder)
        {
            builder.ToTable("TINHTRANGIAOHANG");

            builder.HasKey(tt => new { tt.MaGiaoHang, tt.MaTinhTrangGH });

            builder.Property(tt => tt.MaGiaoHang)
                .HasMaxLength(100);

            builder.Property(tt => tt.MaTinhTrangGH)
               .HasMaxLength(100);

            builder.HasOne(tt => tt.giaoHangs)
                .WithMany(tt => tt.tinhTrangGHs)
                .HasForeignKey(tt => tt.MaGiaoHang);



        }
    }
}
