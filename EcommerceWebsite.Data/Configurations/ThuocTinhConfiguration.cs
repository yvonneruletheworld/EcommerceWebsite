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

            builder.HasKey(tt => tt.MaTT);

            builder.Property(tt => tt.MaTT)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(tt => tt.TenTT)
                .IsRequired();
        }
    }
}
