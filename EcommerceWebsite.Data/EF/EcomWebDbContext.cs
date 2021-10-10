using EcommerceWebsite.Data.Configurations;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.EF
{
    public class EcomWebDbContext : DbContext
    {


        public EcomWebDbContext( DbContextOptions options) : base(options)
        {

        }

        protected EcomWebDbContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguartion());
            modelBuilder.ApplyConfiguration(new HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietHoaDonConfiguration());
            //base.OnModelCreating(modelBuilder);

            //Seeding
            modelBuilder.Seed();
        }
    }
}
