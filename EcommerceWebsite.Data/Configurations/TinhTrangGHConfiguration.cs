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

            builder.HasKey(tt => new { tt.MaGH, tt.MaTTGH });

            builder.Property(tt => tt.MaGH)
                .HasMaxLength(100);

            builder.Property(tt => tt.MaTTGH)
               .HasMaxLength(100);

            builder.HasOne(tt => tt.giaoHang)
                .WithMany(tt => tt.tinhTrangGHs)
                .HasForeignKey(tt => tt.MaGH);



        }
    }
}
