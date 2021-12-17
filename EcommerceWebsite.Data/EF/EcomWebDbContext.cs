using EcommerceWebsite.Data.Configurations;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Extensions;
using EcommerceWebsite.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.EF
{
    public class EcomWebDbContext : IdentityDbContext
    {


        public EcomWebDbContext( DbContextOptions<EcomWebDbContext> options) : base(options)
        {

        }

        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<ThuocTinh> ThuocTinhs { get; set; }
        public DbSet<DinhLuong> DinhLuongs { get; set; }
        public DbSet<LichSuGia> LichSuGias { get; set; }
        public DbSet<NhanHieu> NhanHieus { get; set; }
        public DbSet<DiaChiKhachHang> DiaChiKhaches { get; set; }
        public DbSet<BinhLuan> BinhLuans { get; set; }
        public DbSet<BoPhan> BoPhans { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietNhapSanPham> ChiTietNhapSanPhams { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<GiaoHang> GiaoHangs { get; set; }
        public DbSet<TinhTrangGiaoHang> TinhTrangGiaoHangs { get; set; }
        public DbSet<DanhGiaSanPham> DanhGiaSanPhams { get; set; }
        public DbSet<SanPhamYeuThich> SanPhamYeuThiches { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<DanhMucThuocTinh> DanhMucThuocTinhs { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new DanhMucConfiguration());
            modelBuilder.ApplyConfiguration(new HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietHoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucConfiguration());
            modelBuilder.ApplyConfiguration(new ThuocTinhConfiguration());
            modelBuilder.ApplyConfiguration(new DinhLuongConfiguration());
            modelBuilder.ApplyConfiguration(new LichSuGiaConfiguration());
            modelBuilder.ApplyConfiguration(new NhanHieuConfiguration());
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new DiaChiKhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new BinhLuanConfiguration());
            modelBuilder.ApplyConfiguration(new BoPhanConfiguration());
            modelBuilder.ApplyConfiguration(new NhanVienConfiguartion());
            modelBuilder.ApplyConfiguration(new NhaCungCapConfiguration());
            modelBuilder.ApplyConfiguration(new PhieuNhapConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietNhapSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new KhuyenMaiConfiguration());
            modelBuilder.ApplyConfiguration(new HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietHoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new GiaoHangConfiguration());
            modelBuilder.ApplyConfiguration(new TinhTrangGiaoHangConfiguration());
            modelBuilder.ApplyConfiguration(new DanhGiaSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamYeuThichConfiguration());
            modelBuilder.ApplyConfiguration(new BannerConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucThuocTinhConfiguration());
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            modelBuilder.Seed();
        }
    }
}
