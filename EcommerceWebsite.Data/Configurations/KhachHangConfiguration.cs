using EcommerceWebsite.Data.Entities;
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
            builder.ToTable("KhachHang"); //Tên bảng
            builder.HasKey(kh => kh.Id);  //Khóa Chính

            //Các thuộc tính khác

            builder.Property(kh => kh.Id)
                .IsRequired()  //not null
                .HasMaxLength(100);  //...(100)
            builder.Property(kh => kh.Sdt)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(kh => kh.HoTen)
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
        }
    }
}
