using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class ChiTietNhapSanPhamConfiguration : IEntityTypeConfiguration<ChiTietNhapSanPham>
    {
        public void Configure(EntityTypeBuilder<ChiTietNhapSanPham> builder)
        {
            builder.ToTable("CHITIETNHAPSANPHAM");

            builder.HasKey(ctn => new { ctn.MaNhap, ctn.MaSanPham });

            builder.Property(ctn => ctn.MaSanPham)
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

            builder.HasOne(xl => xl.PhieuNhapEntity)
                .WithMany(xl => xl.ChiTietNhapSanPhams)
                .HasForeignKey(xl => xl.MaNhap);

            builder.HasOne(xl => xl.SanPham)
                .WithMany(xl => xl.ChiTietNhapSanPhams)
                .HasForeignKey(xl => xl.MaSanPham);
        }
    }
}
