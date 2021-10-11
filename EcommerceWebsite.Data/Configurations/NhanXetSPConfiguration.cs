using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class NhanXetSPConfiguration : IEntityTypeConfiguration<NhanXetSP>
    {
        public void Configure(EntityTypeBuilder<NhanXetSP> builder)
        {
            builder.ToTable("NHANXETSP");

            builder.HasKey(nx => new { nx.MaKhachHang, nx.MaSanPham });

            builder.Property(nx => nx.MaSanPham)
                .HasMaxLength(100);

            builder.Property(nx => nx.MaKhachHang)
                .HasMaxLength(100);

            builder.Property(nx => nx.NoiDung)
                .IsRequired();

            builder.Property(nx => nx.soSao)
                 .HasColumnType("int")
                 .IsRequired();

            //Khóa ngoại
            builder.HasOne(xl => xl.sanPhams)
                 .WithMany(xl => xl.nhanXetSPs)
                 .HasForeignKey(xl => xl.MaSanPham);
            //Khóa ngoại
            builder.HasOne(xl => xl.KhachHangs)
                 .WithMany(xl => xl.nhanXetSPs)
                 .HasForeignKey(xl => xl.MaKhachHang);
        }
    }
}
