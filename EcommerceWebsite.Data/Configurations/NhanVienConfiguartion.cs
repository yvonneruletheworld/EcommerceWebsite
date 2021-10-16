using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class NhanVienConfiguartion : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("NHANVIEN");

            builder.HasKey(nv => nv.MaNhanVien);

            builder.Property(nv => nv.MaNhanVien)
                .HasMaxLength(100).IsRequired();
            builder.Property(nv => nv.Username)
                .HasMaxLength(20).IsRequired();

            builder.Property(nv => nv.MaBoPhan)
                .HasMaxLength(100);

            builder.Property(nv => nv.TenNhanVien)
                .HasMaxLength(200)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(nv => nv.SDT)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(nv => nv.Mail)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(nv => nv.BoPhan)
                .WithMany(nv => nv.NhanViens)
                .HasForeignKey(nv => nv.MaBoPhan);



        }
    }
}
