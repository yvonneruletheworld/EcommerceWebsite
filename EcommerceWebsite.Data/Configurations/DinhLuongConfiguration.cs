using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class DinhLuongConfiguration : IEntityTypeConfiguration<DinhLuong>
    {
        public void Configure(EntityTypeBuilder<DinhLuong> builder)
        {
            builder.ToTable("DINHLUONG");

            builder.HasKey(dl => new { dl.MaThuocTinh, dl.MaSanPham });

            builder.Property(dl => dl.MaSanPham)
                .HasMaxLength(100);

            builder.Property(dl => dl.MaThuocTinh)
                .HasMaxLength(100);

            builder.Property(dl => dl.DonVi)
                .IsRequired();

            //Khóa ngoại
            builder.HasOne(dl => dl.SanPham)
                 .WithMany(dl => dl.DinhLuongs)
                 .HasForeignKey(dl => dl.MaSanPham);

            builder.HasOne(dl => dl.ThuocTinh)
                   .WithMany(dl => dl.DinhLuongs)
                   .HasForeignKey(dl => dl.MaThuocTinh);
        }
    }
}
