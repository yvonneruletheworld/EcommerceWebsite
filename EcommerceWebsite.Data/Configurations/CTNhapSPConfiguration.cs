using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class CTNhapSPConfiguration : IEntityTypeConfiguration<CTNhapSP>
    {
        public void Configure(EntityTypeBuilder<CTNhapSP> builder)
        {
            builder.ToTable("CTNHAPSP");

            builder.HasKey(ctn => new { ctn.MaNhap, ctn.MaSP });

            builder.Property(ctn => ctn.MaSP)
                .HasMaxLength(100);

            builder.Property(ctn => ctn.MaNhap)
               .HasMaxLength(100);

            builder.Property(ctn => ctn.DonGia)
                .HasColumnType("money");

            builder.Property(ctn => ctn.ThanhTien)
               .HasColumnType("money");

            builder.Property(ctn => ctn.SoLuong)
               .HasColumnType("int")
                .HasDefaultValue(0); ;

            builder.HasOne(xl => xl.nhapSanPham)
                .WithMany(xl => xl.cTNhapSPs)
                .HasForeignKey(xl => xl.MaNhap);

            builder.HasOne(xl => xl.sanPham)
                .WithMany(xl => xl.cTNhapSPs)
                .HasForeignKey(xl => xl.MaSP);
        }
    }
}
