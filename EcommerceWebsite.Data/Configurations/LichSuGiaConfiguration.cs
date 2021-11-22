using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class LichSuGiaConfiguration : IEntityTypeConfiguration<LichSuGia>
    {
        public void Configure(EntityTypeBuilder<LichSuGia> builder)
        {
            builder.ToTable("LICHSUGIA");

            builder.HasKey(xl => new { xl.MaDinhLuong, xl.NgayTao });

            builder.Property(xl => xl.MaDinhLuong)
                .HasMaxLength(100);

            builder.Property(xl => xl.GiaMoi)
                   .HasColumnType("money")
                   .IsRequired();

            //Khóa ngoại
            builder.HasOne(xl => xl.DinhLuong)
                 .WithMany(xl => xl.LichSuGias)
                 .HasForeignKey(xl => xl.MaDinhLuong);
        }
    }
}
