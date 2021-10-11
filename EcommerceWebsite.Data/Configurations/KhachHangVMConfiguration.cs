using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using EcommerceWebsite.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class KhachHangVMConfiguration : IEntityTypeConfiguration<KhachHangVM>
    {
        public void Configure(EntityTypeBuilder<KhachHangVM> builder)
        {
            builder.Property(kh => kh.HoTen)
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
        }
    }
}
