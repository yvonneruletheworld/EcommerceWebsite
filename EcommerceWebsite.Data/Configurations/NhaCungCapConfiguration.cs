using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class NhaCungCapConfiguration : IEntityTypeConfiguration<NhaCungCap>
    {
        public void Configure(EntityTypeBuilder<NhaCungCap> builder)
        {
            builder.ToTable("NHACUNGCAP");

            builder.HasKey(ncc => ncc.MaNhaCungCap);

            builder.Property(ncc => ncc.MaNhaCungCap)
                .HasMaxLength(100);

            builder.Property(ncc => ncc.TenNhaCungCap)
                .HasColumnType("nvarchar")
                .HasMaxLength(200);

            builder.Property(ncc => ncc.SDT)
                .HasMaxLength(11);

        }
    }
}
