using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    class SanPhamYeuThichConfiguration : IEntityTypeConfiguration<SanPhamYeuThich>
    {
        public void Configure(EntityTypeBuilder<SanPhamYeuThich> builder)
        {
            builder.ToTable("SANPHAMYEUTHICH");

            builder.HasKey(nx => new { nx.MaKhachHang, nx.MaSanPham });

            builder.Property(nx => nx.MaSanPham)
                .HasMaxLength(100);

            builder.Property(nx => nx.MaKhachHang)
                .HasMaxLength(100);
            //Khóa ngoại
            builder.HasOne(xl => xl.SanPham)
                 .WithMany(xl => xl.SanPhamYeus)
                 .HasForeignKey(xl => xl.MaSanPham);
            //Khóa ngoại
            builder.HasOne(xl => xl.KhachHang)
                 .WithMany(xl => xl.SanPhamYeus)
                 .HasForeignKey(xl => xl.MaKhachHang);
        }
    }
}
