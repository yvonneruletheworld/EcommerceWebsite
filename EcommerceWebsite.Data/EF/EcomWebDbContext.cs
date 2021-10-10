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
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiSanPham> loaiSanPhams { get; set; }
        public DbSet<ThuocTinh> thuocTinhs { get; set; }
        public DbSet<DinhLuong> dinhLuongs { get; set; }
        public DbSet<MauSanPham> mauSanPhams { get; set; }
        public DbSet<LichSuGia> lichSuGias { get; set; }
        public DbSet<HangSanPham> hangSanPhams { get; set; }
        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<DiaChiKH> diaChiKHs { get; set; }
        public DbSet<NhanXetSP> nhanXetSPs { get; set; }
        public DbSet<BoPhan> boPhans { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<NhaCungCap> nhaCungCaps { get; set; }
        public DbSet<NhapSanPham> nhapSanPhams { get; set; }
        public DbSet<CTNhapSP> cTNhapSPs { get; set; }
        public DbSet<KhuyenMai> khuyenMais { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<CTHoaDon> cTHoaDons { get; set; }
        public DbSet<GiaoHang> giaoHangs { get; set; }
        public DbSet<TinhTrangGH> tinhTrangGHs { get; set; }
        public DbSet<DanhGiaSP> danhGiaSPs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguartion());
            modelBuilder.ApplyConfiguration(new HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietHoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new ThuocTinhConfiguration());
            modelBuilder.ApplyConfiguration(new DinhLuongConfiguration());
            modelBuilder.ApplyConfiguration(new MauSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new LichSuGiaConfiguration());
            modelBuilder.ApplyConfiguration(new HangSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new DiaChiKHConfiguration());
            modelBuilder.ApplyConfiguration(new NhanXetSPConfiguration());
            modelBuilder.ApplyConfiguration(new BoPhanConfiguration());
            modelBuilder.ApplyConfiguration(new NhanVienConfiguartion());
            modelBuilder.ApplyConfiguration(new NhaCungCapConfiguration());
            modelBuilder.ApplyConfiguration(new NhapSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new CTNhapSPConfiguration());
            modelBuilder.ApplyConfiguration(new KhuyenMaiConfiguration());
            modelBuilder.ApplyConfiguration(new HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new CTHoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new GiaoHangConfiguration());
            modelBuilder.ApplyConfiguration(new TinhTrangGHConfiguration());
            modelBuilder.ApplyConfiguration(new DanhGiaSPConfiguration());
            //base.OnModelCreating(modelBuilder);

            //Seeding
            modelBuilder.Seed();
        }
    }
}
