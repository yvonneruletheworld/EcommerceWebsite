using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class LoaiSanPhamConfiguration : IEntityTypeConfiguration<LoaiSanPham>
    {
        public void Configure(EntityTypeBuilder<LoaiSanPham> builder)
        {
            builder.ToTable("LOAISANPHAM");

            builder.HasKey(lsp => lsp.MaLoai);

            builder.Property(lsp => lsp.MaLoai)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(lsp => lsp.TenLoai)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnType("nvarchar");
        }
    }
}
