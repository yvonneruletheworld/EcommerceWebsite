using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class NhapSanPhamConfiguration : IEntityTypeConfiguration<NhapSanPham>
    {
        public void Configure(EntityTypeBuilder<NhapSanPham> builder)
        {
            builder.ToTable("NHAPSANPHAM");

            builder.HasKey(nsp => nsp.MaNhap);

            builder.Property(nsp => nsp.MaNhap)
                .HasMaxLength(100);

            builder.Property(nsp => nsp.MaNhaCungCap)
               .HasMaxLength(100);

            builder.Property(nsp => nsp.MaNhanVien)
               .HasMaxLength(100);

            builder.Property(nsp => nsp.TongTien)
                .HasColumnType("money");

            builder.HasOne(nsp => nsp.nhaCungCaps)
                .WithMany(nsp => nsp.nhapSanPhams)
                .HasForeignKey(nsp => nsp.MaNhaCungCap);

            builder.HasOne(nsp => nsp.nhanViens)
                .WithMany(nsp => nsp.nhapSanPhams)
                .HasForeignKey(nsp => nsp.MaNhanVien);
        }
    }
}
