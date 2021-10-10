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

            builder.HasKey(xl => new { xl.MaSP, xl.NgayBD });

            builder.Property(xl => xl.MaSP)
                .HasMaxLength(100);

            builder.Property(xl => xl.Gia)
                   .HasColumnType("money")
                   .IsRequired();

            //Khóa ngoại
            builder.HasOne(xl => xl.sanPham)
                 .WithMany(xl => xl.lishSuGias)
                 .HasForeignKey(xl => xl.MaSP);
        }
    }
}
