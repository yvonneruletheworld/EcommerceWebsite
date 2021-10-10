﻿using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KHACHHANG");

            builder.HasKey(kh => kh.MaKH);

            builder.Property(kh => kh.MaKH)
                .HasMaxLength(100);

            builder.Property(Kh => Kh.TenKH)
                .HasMaxLength(200)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(kh => kh.SDT)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(kh => kh.Mail)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
