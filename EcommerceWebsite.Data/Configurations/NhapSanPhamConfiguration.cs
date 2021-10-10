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

            builder.Property(nsp => nsp.MaNCC)
               .HasMaxLength(100);

            builder.Property(nsp => nsp.MaNV)
               .HasMaxLength(100);

            builder.Property(nsp => nsp.TongTien)
                .HasColumnType("money");

            builder.HasOne(nsp => nsp.nhaCungCap)
                .WithMany(nsp => nsp.nhapSanPhams)
                .HasForeignKey(nsp => nsp.MaNCC);

            builder.HasOne(nsp => nsp.nhanVien)
                .WithMany(nsp => nsp.nhapSanPhams)
                .HasForeignKey(nsp => nsp.MaNV);
        }
    }
}
