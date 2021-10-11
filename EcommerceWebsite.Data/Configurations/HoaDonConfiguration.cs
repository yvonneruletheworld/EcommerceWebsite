using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(hd => hd.Id);

            builder.Property(hd => hd.CreateDate)
                .IsRequired();
            builder.Property(hd => hd.MaKhachHang)
                .IsRequired();
            builder.Property(hd => hd.TongCong)
                .HasDefaultValue(0).HasColumnType("money");
            builder.Property(hd => hd.ThanhTien)
                .HasDefaultValue(0).HasColumnType("money");
            builder.HasOne(hd => hd.KhachHangs)
                .WithMany(kh => kh.HoaDons)
                .HasForeignKey(hd => hd.MaKhachHang);
        }
    }
}
