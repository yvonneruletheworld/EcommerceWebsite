using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class NhanXetSanPhamConfiguration : IEntityTypeConfiguration<BinhLuan>
    {
        public void Configure(EntityTypeBuilder<BinhLuan> builder)
        {
            builder.ToTable("NHANXETSANPHAM");

            builder.HasKey(nx => new { nx.MaKhachHang, nx.MaSanPham });

            builder.Property(nx => nx.MaSanPham)
                .HasMaxLength(100);

            builder.Property(nx => nx.MaKhachHang)
                .HasMaxLength(100);

            builder.Property(nx => nx.NoiDung)
                .IsRequired();

            builder.Property(nx => nx.SoSao)
                 .HasColumnType("int")
                 .IsRequired();

            //Khóa ngoại
            builder.HasOne(xl => xl.SanPham)
                 .WithMany(xl => xl.BinhLuans)
                 .HasForeignKey(xl => xl.MaSanPham);
            //Khóa ngoại
            builder.HasOne(xl => xl.KhachHang)
                 .WithMany(xl => xl.BinhLuans)
                 .HasForeignKey(xl => xl.MaKhachHang);
        }
    }
}
