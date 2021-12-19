using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class DanhMucThuocTinhConfiguration : IEntityTypeConfiguration<DanhMucThuocTinh>
    {
        public void Configure(EntityTypeBuilder<DanhMucThuocTinh> builder)
        {
            builder.ToTable("DANHMUCTHUOCTINH");

            builder.HasKey(tt => new { tt.MaThuocTinh, tt.MaDanhMuc });

            builder.Property(tt => tt.MaThuocTinh)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(tt => tt.MaDanhMuc)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
