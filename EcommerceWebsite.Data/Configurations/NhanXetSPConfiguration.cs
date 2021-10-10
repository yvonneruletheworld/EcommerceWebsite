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

            builder.HasKey(nx => new { nx.MaKH, nx.MaSP });

            builder.Property(nx => nx.MaSP)
                .HasMaxLength(100);

            builder.Property(nx => nx.MaKH)
                .HasMaxLength(100);

            builder.Property(nx => nx.NoiDung)
                .IsRequired();

            builder.Property(nx => nx.soSao)
                 .HasColumnType("int")
                 .IsRequired();

            //Khóa ngoại
            builder.HasOne(xl => xl.sanPham)
                 .WithMany(xl => xl.nhanXetSPs)
                 .HasForeignKey(xl => xl.MaSP);
            //Khóa ngoại
            builder.HasOne(xl => xl.KhachHang)
                 .WithMany(xl => xl.nhanXetSPs)
                 .HasForeignKey(xl => xl.MaKH);
        }
    }
}
