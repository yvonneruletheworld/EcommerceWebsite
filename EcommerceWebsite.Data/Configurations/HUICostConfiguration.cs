using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class HUICostConfiguration : IEntityTypeConfiguration<HUICost>
    {
        public void Configure(EntityTypeBuilder<HUICost> builder)
        {
            builder.HasKey(hc => new { hc.MaSanPham, hc.NgayTao, hc.ComboCode });
            builder.Property(hc => hc.MaSanPham).HasMaxLength(100);
            builder.Property(hc => hc.ComboCode).HasMaxLength(100);
        }
    }
}
