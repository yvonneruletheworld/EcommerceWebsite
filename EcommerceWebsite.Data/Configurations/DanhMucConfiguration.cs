using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class DanhMucConfiguration : IEntityTypeConfiguration<DanhMuc>
    {
        public void Configure(EntityTypeBuilder<DanhMuc> builder)
        {
            builder.ToTable("DANHMUC");

            builder.HasKey(lsp => lsp.Id);

            builder.Property(lsp => lsp.Id)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(lsp => lsp.Name)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnType("nvarchar");
        }
    }
}
