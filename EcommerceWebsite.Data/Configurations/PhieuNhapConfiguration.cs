using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class PhieuNhapConfiguration : IEntityTypeConfiguration<PhieuNhap>
    {
        public void Configure(EntityTypeBuilder<PhieuNhap> builder)
        {
            builder.ToTable("PHIEUNHAP");

            builder.HasKey(nsp => nsp.MaPhieuNhap);

            builder.Property(nsp => nsp.MaPhieuNhap)
                .HasMaxLength(100);

            builder.Property(nsp => nsp.MaNhaCungCap)
               .HasMaxLength(100);

            builder.Property(nsp => nsp.MaNhanVien)
               .HasMaxLength(100);

            builder.Property(nsp => nsp.TongTien)
                .HasColumnType("money");

            builder.HasOne(nsp => nsp.NhaCungCapE)
                .WithMany(nsp => nsp.PhieuNhaps)
                .HasForeignKey(nsp => nsp.MaNhaCungCap);

            builder.HasOne(nsp => nsp.NhanVien)
                .WithMany(nsp => nsp.PhieuNhaps)
                .HasForeignKey(nsp => nsp.MaNhanVien);
        }
    }
}
