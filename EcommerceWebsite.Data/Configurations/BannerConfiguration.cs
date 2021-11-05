using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.ToTable("BANNER");

            builder.HasKey(nx => nx.MaBanner);

            builder.Property(nx => nx.HinhAnhBanner)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(nx => nx.HinhAnhBanner)
                 .IsRequired();

            builder.Property(nx => nx.TenBanner)
                 .IsRequired();
        }
    }
}
