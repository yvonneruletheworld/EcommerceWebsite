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

            builder.HasKey(dl => new { dl.MaTT, dl.MaSP });

            builder.Property(dl => dl.MaSP)
                .HasMaxLength(100);

            builder.Property(dl => dl.MaTT)
                .HasMaxLength(100);

            builder.Property(dl => dl.DonVi)
                .IsRequired();

            //Khóa ngoại
            builder.HasOne(dl => dl.sanPham)
                 .WithMany(dl => dl.dinhLuongs)
                 .HasForeignKey(dl => dl.MaSP);

            builder.HasOne(dl => dl.thuocTinh)
                   .WithMany(dl => dl.dinhLuongs)
                   .HasForeignKey(dl => dl.MaTT);
        }
    }
}
