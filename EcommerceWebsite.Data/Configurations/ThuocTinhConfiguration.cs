using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class ThuocTinhConfiguration : IEntityTypeConfiguration<ThuocTinh>
    {
        public void Configure(EntityTypeBuilder<ThuocTinh> builder)
        {
            builder.ToTable("THUOCTINH");

            builder.HasKey(tt => tt.MaThuocTinh);

            builder.Property(tt => tt.MaThuocTinh)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(tt => tt.TenThuocTinh)
                .IsRequired();
        }
    }
}
