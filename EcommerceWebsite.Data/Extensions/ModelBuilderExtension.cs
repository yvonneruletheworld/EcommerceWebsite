using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Loại sản phẩm
            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc()
                {
                    MaDanhMuc = "DM01",
                    TenDanhMuc = "Điện thoại",
                    Status = Enum.Status.Active,
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    DaXoa = false,
                    HinhAnh = "",
                    HienThiTrangHome = true,
                    ParentId = null,
                },
                new DanhMuc()
                {
                    MaDanhMuc = "DM02",
                    TenDanhMuc = "Phụ kiện",
                    Status = Enum.Status.Active,
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    HinhAnh = "https://i.ibb.co/hKbXPTb/56bd682737d0d355fe665d380783371c.jpg",
                    DaXoa = false,
                    HienThiTrangHome = true,
                    ParentId = "DM01",
                },
                new DanhMuc()
                {
                    MaDanhMuc = "DM03",
                    TenDanhMuc = "Đồng hồ thông minh",
                    Status = Enum.Status.Active,
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    HinhAnh = "https://i.ibb.co/CmZS7bp/ng-h-th-ng-min.jpg",
                    DaXoa = false,
                    HienThiTrangHome = true,
                    ParentId = "DM01",
                },
                new DanhMuc()
                {
                    MaDanhMuc = "DM04",
                    TenDanhMuc = "PC, Máy in",
                    Status = Enum.Status.Active,
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    DaXoa = false,
                    HienThiTrangHome = true,
                    ParentId = "DM01",
                });
            //Hãng sản phẩm
            modelBuilder.Entity<NhanHieu>().HasData(
                new NhanHieu()
                {
                    MaHang = "MH01",
                    TenHang = "IPHONE",

                },
                new NhanHieu()
                {
                    MaHang = "MH02",
                    TenHang = "SAMSUNG",

                },
                new NhanHieu()
                {
                    MaHang = "MH03",
                    TenHang = "OPPO",

                },
                new NhanHieu()
                {
                    MaHang = "MH04",
                    TenHang = "VIVO",

                },
                new NhanHieu()
                {
                    MaHang = "MH05",
                    TenHang = "XIAOMI",

                },
                new NhanHieu()
                {
                    MaHang = "MH06",
                    TenHang = "REALME",

                },
                new NhanHieu()
                {
                    MaHang = "MH07",
                    TenHang = "VSMAST",

                },
                new NhanHieu()
                {
                    MaHang = "MH08",
                    TenHang = "NOKIA",

                },
                 new NhanHieu()
                 {
                     MaHang = "MH09",
                     TenHang = "HYDRUS",

                 });
            //Sản phẩm
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham()
                {
                    MaSanPham = "SP01",
                    TenSanPham = "Samsung Galaxy Z Fold3 5G 512GB",
                    MaHang = "MH02",
                    NgayTao = DateTime.UtcNow,
                    MaLoaiSanPham = "DM01",
                    HinhAnh = "https://i.ibb.co/T2Ywg8N/Samsung-galaxy-z-fold-3-silver-gc-org.jpg",
                    NguoiTao = "admin",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                },
                new SanPham()
                {
                    MaSanPham = "SP02",
                    TenSanPham = "Samsung Galaxy Z Flip3 5G 128GB",
                    MaHang = "MH02",
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    MaLoaiSanPham = "DM01",
                    HinhAnh = "https://i.ibb.co/CPq556s/Samsung-galaxy-z-flip-3-kem-1-org.jpg",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                },
                new SanPham()
                {
                    MaSanPham = "SP03",
                    TenSanPham = "iPhone 12 64GB",
                    MaHang = "MH01",
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    MaLoaiSanPham = "DM01",
                    HinhAnh = "https://i.ibb.co/RNz8N1G/Iphone-12-64-GB.jpg",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                },
                new SanPham()
                {
                    MaSanPham = "SP04",
                    TenSanPham = "iPhone 12 Pro Max 128GB",
                    MaHang = "MH01",
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    MaLoaiSanPham = "DM01",
                    HinhAnh = "https://i.ibb.co/JQNGCzb/Iphone-12-pro-max-128-GB.jpg",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                },
                new SanPham()
                {
                    MaSanPham = "SP05",
                    TenSanPham = "iPhone 12 mini 64GB",
                    MaHang = "MH01",
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    MaLoaiSanPham = "DM01",
                    HinhAnh = "https://i.ibb.co/vsLZ8km/Iphone-12-mini-64-GB.jpg",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                },
                new SanPham()
                {
                    MaSanPham = "SP06",
                    TenSanPham = "iPhone 11 64GB",
                    MaHang = "MH01",
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    MaLoaiSanPham = "DM01",
                    HinhAnh = "https://i.ibb.co/hZS5MJ3/Iphone-11-64-GB.jpg",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                },
                new SanPham()
                {
                     MaSanPham = "SP07",
                     TenSanPham = "iPhone XR 64GB",
                     MaHang = "MH01",
                     NgayTao = DateTime.UtcNow,
                     NguoiTao = "admin",
                     MaLoaiSanPham = "DM01",
                     HinhAnh = "https://i.ibb.co/2v36jLV/iphone-XR-64-GB.jpg",
                     DaXoa = false,
                     Status = Enum.Status.Active,
                     SoLuongTon = 1,
                },
                new SanPham()
                {
                      MaSanPham = "SP08",
                      TenSanPham = "OPPO Reno6 Z 5G",
                      MaHang = "MH03",
                      NgayTao = DateTime.UtcNow,
                      NguoiTao = "admin",
                      MaLoaiSanPham = "DM01",
                      HinhAnh = "https://i.ibb.co/1rp5mbM/Oppo-reno6-z-5g-bac-1-org.jpg",
                      DaXoa = false,
                      Status = Enum.Status.Active,
                      SoLuongTon = 1,
                },
                new SanPham()
                {
                    MaSanPham = "SP09",
                    TenSanPham = "OPPO A74",
                    MaHang = "MH03",
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    MaLoaiSanPham = "DM01",
                    HinhAnh = "https://i.ibb.co/zRQB86R/Oppo-a74-xanh-duong-1-org.jpg",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                },
                new SanPham()
                {
                    MaSanPham = "SP010",
                    TenSanPham = "OPPO Reno6 Pro 5G",
                    MaHang = "MH03",
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    MaLoaiSanPham = "DM01",
                    HinhAnh = "https://i.ibb.co/ydCdghQ/Oppo-reno6-pro-5g-xanh-duong-1.jpg",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                },
                new SanPham()
                {
                    MaSanPham = "SP011",
                    TenSanPham = "OPPO Find X3 Pro 5G",
                    MaHang = "MH03",
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    MaLoaiSanPham = "DM01",
                    HinhAnh = "https://i.ibb.co/pw2Kqcp/Oppo-find-x3-pro-den-1-org.jpg",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                },
                 new SanPham()
                 {
                     MaSanPham = "SP012",
                     TenSanPham = "OPPO Reno6 5G",
                     MaHang = "MH03",
                     NgayTao = DateTime.UtcNow,
                     NguoiTao = "admin",
                     MaLoaiSanPham = "DM01",
                     HinhAnh = "https://i.ibb.co/zbPGb0s/Oppo-reno6-den-1-org.jpg",
                     DaXoa = false,
                     Status = Enum.Status.Active,
                     SoLuongTon = 1,
                 },
                 new SanPham()
                 {
                     MaSanPham = "SP013",
                     TenSanPham = "OPPO Reno5 5G",
                     MaHang = "MH03",
                     NgayTao = DateTime.UtcNow,
                     NguoiTao = "admin",
                     MaLoaiSanPham = "DM01",
                     HinhAnh = "https://i.ibb.co/55BgPLp/Oppo-reno5-5g-bac-1-org.jpg",
                     DaXoa = false,
                     Status = Enum.Status.Active,
                     SoLuongTon = 1,
                 },
                 new SanPham()
                 {
                     MaSanPham = "SP014",
                     TenSanPham = "OPPO Reno4 Pro",
                     MaHang = "MH03",
                     NgayTao = DateTime.UtcNow,
                     NguoiTao = "admin",
                     MaLoaiSanPham = "DM01",
                     HinhAnh = "https://i.ibb.co/94LDnqK/Oppo-reno4-pro-trang-1-org.jpg",
                     DaXoa = false,
                     Status = Enum.Status.Active,
                     SoLuongTon = 1,
                 },
                 new SanPham()
                 {
                     MaSanPham = "SP015",
                     TenSanPham = "OPPO A16",
                     MaHang = "MH03",
                     NgayTao = DateTime.UtcNow,
                     NguoiTao = "admin",
                     MaLoaiSanPham = "DM01",
                     HinhAnh = "https://i.ibb.co/vVV9xVR/Oppo-a16-1-2.jpg",
                     DaXoa = false,
                     Status = Enum.Status.Active,
                     SoLuongTon = 1,
                 },
                 new SanPham()
                 {
                     MaSanPham = "SP016",
                     TenSanPham = "OPPO A16",
                     MaHang = "MH04",
                     NgayTao = DateTime.UtcNow,
                     NguoiTao = "admin",
                     MaLoaiSanPham = "DM01",
                     HinhAnh = "https://i.ibb.co/XWGXkDf/Vivo-y21-1-2.jpg",
                     DaXoa = false,
                     Status = Enum.Status.Active,
                     SoLuongTon = 1,
                 },
                 new SanPham()
                 {
                     MaSanPham = "SP017",
                     TenSanPham = "Vivo X70 Pro 5G",
                     MaHang = "MH04",
                     NgayTao = DateTime.UtcNow,
                     NguoiTao = "admin",
                     MaLoaiSanPham = "DM01",
                     HinhAnh = "https://i.ibb.co/NrnVRWj/Vivo-x70-pro-black-gc-org.jpg",
                     DaXoa = false,
                     Status = Enum.Status.Active,
                     SoLuongTon = 1,
                 },
                 new SanPham()
                 {
                     MaSanPham = "SP018",
                     TenSanPham = "Vivo V21 5G",
                     MaHang = "MH04",
                     NgayTao = DateTime.UtcNow,
                     NguoiTao = "admin",
                     MaLoaiSanPham = "DM01",
                     HinhAnh = "https://i.ibb.co/S7Xy2TM/Vivo-v21-5g-tim-hong-1-3-org.jpg",
                     DaXoa = false,
                     Status = Enum.Status.Active,
                     SoLuongTon = 1,
                 },
                  new SanPham()
                  {
                      MaSanPham = "SP019",
                      TenSanPham = "Vivo V20 (2021)",
                      MaHang = "MH04",
                      NgayTao = DateTime.UtcNow,
                      NguoiTao = "admin",
                      MaLoaiSanPham = "DM01",
                      HinhAnh = "https://i.ibb.co/TLdWMdd/Vivo-v20-2021-xanh-hong-1-org.jpg",
                      DaXoa = false,
                      Status = Enum.Status.Active,
                      SoLuongTon = 1,
                  },
                  new SanPham()
                  {
                      MaSanPham = "SP020",
                      TenSanPham = "Vivo Y72 5G",
                      MaHang = "MH04",
                      NgayTao = DateTime.UtcNow,
                      NguoiTao = "admin",
                      MaLoaiSanPham = "DM01",
                      HinhAnh = "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg",
                      DaXoa = false,
                      Status = Enum.Status.Active,
                      SoLuongTon = 1,
                  },
                  new SanPham()
                  {
                      MaSanPham = "SP021",
                      TenSanPham = "Vivo Y21s 6GB",
                      MaHang = "MH04",
                      NgayTao = DateTime.UtcNow,
                      NguoiTao = "admin",
                      MaLoaiSanPham = "DM01",
                      HinhAnh = "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg",
                      DaXoa = false,
                      Status = Enum.Status.Active,
                      SoLuongTon = 1,
                  },
                  //DỒNG hồ DM03
                  new SanPham()
                  {
                      MaSanPham = "SP022",
                      TenSanPham = "Samsung Galaxy Watch 4 44mm",
                      MaHang = "MH02",
                      NgayTao = DateTime.UtcNow,
                      NguoiTao = "admin",
                      MaLoaiSanPham = "DM03",
                      HinhAnh = "https://i.ibb.co/k5rV9Vg/Samsung-galaxy-watch-4-44mm-den-1-org.jpg",
                      DaXoa = false,
                      Status = Enum.Status.Active,
                      SoLuongTon = 1,
                  });
            //Thuộc tính
            modelBuilder.Entity<ThuocTinh>().HasData(
                new ThuocTinh()
                {
                    MaThuocTinh = "TT01",
                    TenThuocTinh = "Màn hình"
                },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT02",
                     TenThuocTinh = "Hệ điều hành"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT03",
                     TenThuocTinh = "Camera sau"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT04",
                     TenThuocTinh = "Camera trước"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT05",
                     TenThuocTinh = "Chip"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT06",
                     TenThuocTinh = "RAM"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT07",
                     TenThuocTinh = "Bộ nhớ trong"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT08",
                     TenThuocTinh = "SIM"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT09",
                     TenThuocTinh = "Pin, Sạc"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT010",
                     TenThuocTinh = "Trọng lượng Pin"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT011",
                     TenThuocTinh = "Kết nối với hệ điều hành"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT012",
                     TenThuocTinh = "Mặt"
                 },
                 new ThuocTinh()
                 {
                     MaThuocTinh = "TT013",
                     TenThuocTinh = "Tính năng cho sức khỏe"
                 }
                 //new ThuocTinh()
                 //{
                 //    MaThuocTinh = "TT014",
                 //    TenThuocTinh = "Nguồn ra"
                 //},
                 //new ThuocTinh()
                 //{
                 //    MaThuocTinh = "TT015",
                 //    TenThuocTinh = "Lõi pin"
                 //},
                 //new ThuocTinh()
                 //{
                 //    MaThuocTinh = "TT016",
                 //    TenThuocTinh = "Công nghệ/Tiện ích"
                 //},
                 //new ThuocTinh()
                 //{
                 //    MaThuocTinh = "TT017",
                 //    TenThuocTinh = "Kích thước"
                 //},
                 //new ThuocTinh()
                 //{
                 //    MaThuocTinh = "TT018",
                 //    TenThuocTinh = "Trọng lượng"
                 //},
                 //new ThuocTinh()
                 //{
                 //    MaThuocTinh = "TT019",
                 //    TenThuocTinh = "Thương hiệu của"
                 //},
                 //new ThuocTinh()
                 //{
                 //    MaThuocTinh = "TT020",
                 //    TenThuocTinh = "Sản xuất tại"
                 //}
        );
            //Dịnh lượng
            modelBuilder.Entity<DinhLuong>().HasData(
                new DinhLuong()
                {
                    MaSanPham = "SP01",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "Dynamic AMOLED 2X, Chính 7.6 & Phụ 6.2, Full HD+"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP01",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP01",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "3 camera 12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP01",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "10 MP & 4 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP01",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Snapdragon 888"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP01",
                    MaThuocTinh = "TT06",
                    GiaTri = 12,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP01",
                    MaThuocTinh = "TT07",
                    GiaTri = 512,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP01",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP01",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "4400 mAh, 25 W"
                },
                //
                new DinhLuong()
                {
                    MaSanPham = "SP02",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "Dynamic AMOLED 2X, Chính 6.7 & Phụ 1.9, Full HD+"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP02",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP02",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "2 camera 12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP02",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "10 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP02",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Snapdragon 888"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP02",
                    MaThuocTinh = "TT06",
                    GiaTri = 8,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP02",
                    MaThuocTinh = "TT07",
                    GiaTri = 128,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP02",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "1 Nano SIM & 1 eSIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP02",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "3300 mAh, 25 W"
                },
                //
                new DinhLuong()
                {
                    MaSanPham = "SP03",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "OLED, 6.1, Super Retina XDR"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP03",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "iOS 14"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP03",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "2 camera 12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP03",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP03",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Apple A14 Bionic"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP03",
                    MaThuocTinh = "TT06",
                    GiaTri = 4,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP03",
                    MaThuocTinh = "TT07",
                    GiaTri = 64,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP03",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "1 Nano SIM & 1 eSIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP03",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "2815 mAh, 20 W"
                },
                //
                new DinhLuong()
                {
                    MaSanPham = "SP04",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "OLED, 6.7, Super Retina XDR"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP04",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "iOS 14"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP04",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "3 camera 12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP04",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP04",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Apple A14 Bionic"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP04",
                    MaThuocTinh = "TT06",
                    GiaTri = 6,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP04",
                    MaThuocTinh = "TT07",
                    GiaTri = 128,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP04",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "1 Nano SIM & 1 eSIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP04",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "3687 mAh, 20 W"
                },
                //
                new DinhLuong()
                {
                    MaSanPham = "SP05",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "OLED, 5.4, Super Retina XDR"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP05",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "iOS 14"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP05",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "2 camera 12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP05",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP05",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Apple A14 Bionic"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP05",
                    MaThuocTinh = "TT06",
                    GiaTri = 4,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP05",
                    MaThuocTinh = "TT07",
                    GiaTri = 64,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP05",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "1 Nano SIM & 1 eSIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP05",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "2227 mAh, 20 W"
                },
                //
                new DinhLuong()
                {
                    MaSanPham = "SP06",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "IPS LCD, 6.1, Liquid Retina"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP06",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "iOS 14"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP06",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "2 camera 12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP06",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP06",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Apple A13 Bionic"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP06",
                    MaThuocTinh = "TT06",
                    GiaTri = 4,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP06",
                    MaThuocTinh = "TT07",
                    GiaTri = 64,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP06",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "1 Nano SIM & 1 eSIM, Hỗ trợ 4G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP06",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "3110 mAh, 18 W"
                },
                //
                new DinhLuong()
                {
                    MaSanPham = "SP07",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "IPS LCD, 6.1, Liquid Retina"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP07",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "iOS 14"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP07",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "12 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP07",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "7 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP07",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Apple A12 Bionic"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP07",
                    MaThuocTinh = "TT06",
                    GiaTri = 3,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP07",
                    MaThuocTinh = "TT07",
                    GiaTri = 64,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP07",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "1 Nano SIM & 1 eSIM, Hỗ trợ 4G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP07",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "2942 mAh, 15 W"
                },
                //
                new DinhLuong()
                {
                    MaSanPham = "SP08",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "AMOLED, 6.43, Full HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP08",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP08",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 64 MP & Phụ 8 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP08",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "32 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP08",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "MediaTek Dimensity 800U 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP08",
                    MaThuocTinh = "TT06",
                    GiaTri = 8,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP08",
                    MaThuocTinh = "TT07",
                    GiaTri = 128,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP08",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP08",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "4310 mAh, 30 W"
                },
                //
                new DinhLuong()
                {
                    MaSanPham = "SP09",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "AMOLED6.43, Full HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP09",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP09",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 48 MP & Phụ 2 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP09",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "16 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP09",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Snapdragon 662"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP09",
                    MaThuocTinh = "TT06",
                    GiaTri = 8,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP09",
                    MaThuocTinh = "TT07",
                    GiaTri = 128,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP09",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 4G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP09",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "5000 mAh, 30 W"
                }
                //
                ,new DinhLuong()
                {
                    MaSanPham = "SP010",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "AMOLED6.55, Full HD+"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP010",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP010",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 50 MP & Phụ 16 MP, 13 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP010",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "32 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP010",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Snapdragon 870 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP010",
                    MaThuocTinh = "TT06",
                    GiaTri = 12,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP010",
                    MaThuocTinh = "TT07",
                    GiaTri = 256,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP010",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP010",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "4500 mAh, 65 W"
                }
                //
                , new DinhLuong()
                {
                    MaSanPham = "SP011",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "AMOLED, 6.7, Quad HD+ (2K+)"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP011",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP011",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 50 MP & Phụ 50 MP, 13 MP, 3 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP011",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "32 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP011",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Snapdragon 888"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP011",
                    MaThuocTinh = "TT06",
                    GiaTri = 12,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP011",
                    MaThuocTinh = "TT07",
                    GiaTri = 256,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP011",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP011",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "4500 mAh, 65 W"
                }
                //
                ,new DinhLuong()
                {
                    MaSanPham = "SP012",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "AMOLED, 6.43, Full HD+"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP012",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP012",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 64 MP & Phụ 8 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP012",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "32 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP012",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "MediaTek Dimensity 900 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP012",
                    MaThuocTinh = "TT06",
                    GiaTri = 8,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP012",
                    MaThuocTinh = "TT07",
                    GiaTri = 128,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP012",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP012",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "4300 mAh, 65 W"
                }
                //
                ,new DinhLuong()
                {
                    MaSanPham = "SP013",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "AMOLED, 6.43, Full HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP013",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP013",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 64 MP & Phụ 8 MP, 2 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP013",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "32 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP013",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Snapdragon 765G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP013",
                    MaThuocTinh = "TT06",
                    GiaTri = 8,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP013",
                    MaThuocTinh = "TT07",
                    GiaTri = 128,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP013",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP013",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "4300 mAh, 65 W"
                }
                //
                , new DinhLuong()
                {
                    MaSanPham = "SP014",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "AMOLED, 6.5, Full HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP014",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 10"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP014",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 48 MP & Phụ 8 MP, 2 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP014",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "32 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP014",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Snapdragon 720G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP014",
                    MaThuocTinh = "TT06",
                    GiaTri = 8,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP014",
                    MaThuocTinh = "TT07",
                    GiaTri = 256,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP014",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 4G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP014",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "4000 mAh, 65 W"
                }
                //
                , new DinhLuong()
                {
                    MaSanPham = "SP015",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "IPS LCD, 6.52, HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP015",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP015",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 13 MP & Phụ 2 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP015",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "8 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP015",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "MediaTek Helio G35"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP015",
                    MaThuocTinh = "TT06",
                    GiaTri = 3,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP015",
                    MaThuocTinh = "TT07",
                    GiaTri = 32,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP015",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 4G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP015",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "5000 mAh, 10 W"
                }
                //
                , new DinhLuong()
                {
                    MaSanPham = "SP016",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "IPS LCD, 6.51 HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP016",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP016",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 13 MP & Phụ 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP016",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "8 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP016",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "MediaTek Helio P35"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP016",
                    MaThuocTinh = "TT06",
                    GiaTri = 4,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP016",
                    MaThuocTinh = "TT07",
                    GiaTri = 64,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP016",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 4G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP016",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "5000 mAh, 18 W"
                }
                //
                , new DinhLuong()
                {
                    MaSanPham = "SP017",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "IPS LCD, 6.56 HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP017",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP017",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 13 MP & Phụ 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP017",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "8 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP017",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "MediaTek Dimensity 1200"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP017",
                    MaThuocTinh = "TT06",
                    GiaTri = 12,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP017",
                    MaThuocTinh = "TT07",
                    GiaTri = 256,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP017",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP017",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "4500 mAh, 44 W"
                }
                //
                , new DinhLuong()
                {
                    MaSanPham = "SP018",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "IPS LCD, 6.44 HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP018",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP018",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 64 MP & Phụ 8 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP018",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "44 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP018",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "MediaTek Dimensity 800U 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP018",
                    MaThuocTinh = "TT06",
                    GiaTri = 8,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP018",
                    MaThuocTinh = "TT07",
                    GiaTri = 128,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP018",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP018",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "4000 mAh, 43 W"
                }
                //
                , new DinhLuong()
                {
                    MaSanPham = "SP019",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "IPS LCD, 6.44 HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP019",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP019",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 64 MP & Phụ 8 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP019",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "44 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP019",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "Snapdragon 730"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP019",
                    MaThuocTinh = "TT06",
                    GiaTri = 8,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP019",
                    MaThuocTinh = "TT07",
                    GiaTri = 128,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP019",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 4G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP019",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "4000 mAh, 33 W"
                }
                //
                , new DinhLuong()
                {
                    MaSanPham = "SP020",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "IPS LCD, 6.58 HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP020",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP020",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 64 MP & Phụ 8 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP020",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "16 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP020",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "MediaTek Dimensity 700"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP020",
                    MaThuocTinh = "TT06",
                    GiaTri = 8,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP020",
                    MaThuocTinh = "TT07",
                    GiaTri = 128,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP020",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM (SIM 2 chung khe thẻ nhớ) Hỗ trợ 5G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP020",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "5000 mAh, 18 W"
                }
                //
                , new DinhLuong()
                {
                    MaSanPham = "SP021",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "IPS LCD, 6.51 HD + "
                },
                new DinhLuong()
                {
                    MaSanPham = "SP021",
                    MaThuocTinh = "TT02",
                    GiaTri = 0,
                    DonVi = "Android 11"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP021",
                    MaThuocTinh = "TT03",
                    GiaTri = 0,
                    DonVi = "Chính 50 MP & Phụ 8 MP, 2 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP021",
                    MaThuocTinh = "TT04",
                    GiaTri = 0,
                    DonVi = "8 MP"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP021",
                    MaThuocTinh = "TT05",
                    GiaTri = 0,
                    DonVi = "MediaTek Dimensity G80"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP021",
                    MaThuocTinh = "TT06",
                    GiaTri = 6,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP021",
                    MaThuocTinh = "TT07",
                    GiaTri = 128,
                    DonVi = "GB"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP021",
                    MaThuocTinh = "TT08",
                    GiaTri = 0,
                    DonVi = "2 Nano SIM, Hỗ trợ 4G"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP021",
                    MaThuocTinh = "TT09",
                    GiaTri = 0,
                    DonVi = "5000 mAh, 18 W"
                },
                //
                new DinhLuong()
                {
                    MaSanPham = "SP022",
                    MaThuocTinh = "TT01",
                    GiaTri = 0,
                    DonVi = "SUPER AMOLED, 1.36 inch"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP022",
                    MaThuocTinh = "TT010",
                    GiaTri = 0,
                    DonVi = "Khoảng 1.5 ngày"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP022",
                    MaThuocTinh = "TT011",
                    GiaTri = 0,
                    DonVi = "Android dùng Google Mobile Service"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP022",
                    MaThuocTinh = "TT012",
                    GiaTri = 0,
                    DonVi = "Kính cường lực Gorrilla Glass Dx+, 44 mm"
                },
                new DinhLuong()
                {
                    MaSanPham = "SP022",
                    MaThuocTinh = "TT013",
                    GiaTri = 0,
                    DonVi = "Theo dõi giấc ngủ, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân"
                }
                );
            //Mẫu mã sản phẩm
             modelBuilder.Entity<MauMaSanPham>().HasData(
                new MauMaSanPham()
                {
                    MaMauMa = "MM01",
                    MaSanPham = "SP01",
                    TenMauMa = "Xanh riêu",
                    HinhAnh = "https://i.ibb.co/9WvYqLR/Samsung-galaxy-z-fold3-5g-1.jpg",
                },
                new MauMaSanPham()
                {
                    MaMauMa = "MM02",
                    MaSanPham = "SP01",
                    TenMauMa = "Bạc",
                    HinhAnh = "https://i.ibb.co/T2Ywg8N/Samsung-galaxy-z-fold-3-silver-gc-org.jpg",
                },
                new MauMaSanPham()
                {
                    MaMauMa = "MM03",
                    MaSanPham = "SP01",
                    TenMauMa = "Đen",
                    HinhAnh = "https://i.ibb.co/qyCNcw6/Samsung-galaxy-z-fold-3-1-org.jpg",
                },
                //
                new MauMaSanPham()
                {
                    MaMauMa = "MM04",
                    MaSanPham = "SP02",
                    TenMauMa = "Kem",
                    HinhAnh = "https://i.ibb.co/CPq556s/Samsung-galaxy-z-flip-3-kem-1-org.jpg",
                },
                new MauMaSanPham()
                 {
                     MaMauMa = "MM05",
                     MaSanPham = "SP02",
                     TenMauMa = "Đen",
                     HinhAnh = "https://i.ibb.co/0tXPPWn/Samsung-galaxy-z-flip-3-black-gc-org.jpg",
                 },
                new MauMaSanPham()
                 {
                     MaMauMa = "MM06",
                     MaSanPham = "SP02",
                     TenMauMa = "Xanh riêu",
                     HinhAnh = "https://i.ibb.co/9WvYqLR/Samsung-galaxy-z-fold3-5g-1.jpg",
                 },
                //
                new MauMaSanPham()
                  {
                      MaMauMa = "MM07",
                      MaSanPham = "SP03",
                      TenMauMa = "Đen",
                      HinhAnh = "https://i.ibb.co/0qYwZ5c/Iphone-12-64-GB-en.jpg",
                  },
                new MauMaSanPham()
                  {
                      MaMauMa = "MM08",
                      MaSanPham = "SP03",
                      TenMauMa = "Đỏ",
                      HinhAnh = "https://i.ibb.co/RNz8N1G/Iphone-12-64-GB.jpg",
                  },
                new MauMaSanPham()
                  {
                      MaMauMa = "MM09",
                      MaSanPham = "SP03",
                      TenMauMa = "Tím",
                      HinhAnh = "https://i.ibb.co/GC6Tdwd/Iphone-12-64-GB-T-m.jpg",
                  },
                new MauMaSanPham()
                  {
                      MaMauMa = "MM010",
                      MaSanPham = "SP03",
                      TenMauMa = "Trắng",
                      HinhAnh = "https://i.ibb.co/vsLZ8km/Iphone-12-mini-64-GB.jpg",
                  },
                new MauMaSanPham()
                   {
                       MaMauMa = "MM011",
                       MaSanPham = "SP03",
                       TenMauMa = "Xanh",
                       HinhAnh = "https://i.ibb.co/6XtyJbM/Iphone-12-64-GB-Xanh.jpg",
                   },
                new MauMaSanPham()
                   {
                       MaMauMa = "MM012",
                       MaSanPham = "SP03",
                       TenMauMa = "Xanh lá",
                       HinhAnh = "https://i.ibb.co/D5Xg9sQ/Iphone-12-64-GB-Xanh-l.jpg",
                   },
                //
                new MauMaSanPham()
                    {
                        MaMauMa = "MM013",
                        MaSanPham = "SP04",
                        TenMauMa = "Bạc",
                        HinhAnh = "https://i.ibb.co/pW2nvth/Iphone-12-pro-max-bac-1-org.jpg",
                    },
                new MauMaSanPham()
                    {
                        MaMauMa = "MM014",
                        MaSanPham = "SP04",
                        TenMauMa = "Vàng",
                        HinhAnh = "https://i.ibb.co/JQNGCzb/Iphone-12-pro-max-128-GB.jpg",
                    },
                new MauMaSanPham()
                    {
                        MaMauMa = "MM015",
                        MaSanPham = "SP04",
                        TenMauMa = "Xanh",
                        HinhAnh = "https://i.ibb.co/5LvRhJ4/Iphone-12-pro-max-xanh-duong-1-org.jpg",
                    },
                //
                new MauMaSanPham()
                    {
                        MaMauMa = "MM016",
                        MaSanPham = "SP05",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/crZFrkD/Iphone-12-mini-den-1-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM017",
                        MaSanPham = "SP05",
                        TenMauMa = "Đỏ",
                        HinhAnh = "https://i.ibb.co/jkmt501/Iphone-12-mini-1-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM018",
                        MaSanPham = "SP05",
                        TenMauMa = "Tím",
                        HinhAnh = "https://i.ibb.co/30KH8b2/Iphone-12-mini-tim-gc-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM019",
                        MaSanPham = "SP05",
                        TenMauMa = "Trắng",
                        HinhAnh = "https://i.ibb.co/5LRj1Wh/Iphone-12-mini-trang-1-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM020",
                        MaSanPham = "SP05",
                        TenMauMa = "Xanh dương",
                        HinhAnh = "https://i.ibb.co/Np97nN6/Iphone-12-mini-xanh-duong-1-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM021",
                        MaSanPham = "SP05",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/0stYCyp/Iphone-11-den-1-1-1-org.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM022",
                        MaSanPham = "SP06",
                        TenMauMa = "Đỏ",
                        HinhAnh = "https://i.ibb.co/WBH28Zh/Iphone-11-do-1-1-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM023",
                        MaSanPham = "SP06",
                        TenMauMa = "Tím",
                        HinhAnh = "https://i.ibb.co/Lnt4WzS/Iphone-11-tim-1-1-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM024",
                        MaSanPham = "SP06",
                        TenMauMa = "Trắng",
                        HinhAnh = "https://i.ibb.co/pLyJDFG/Iphone-11-trang-1-2-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM025",
                        MaSanPham = "SP06",
                        TenMauMa = "Vàng",
                        HinhAnh = "https://i.ibb.co/26xpZH9/Iphone-11-vang-1-2-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM026",
                        MaSanPham = "SP06",
                        TenMauMa = "Xanh lá",
                        HinhAnh = "https://i.ibb.co/hZS5MJ3/Iphone-11-64-GB.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM027",
                        MaSanPham = "SP07",
                        TenMauMa = "Cam",
                        HinhAnh = "https://i.ibb.co/8d4VJxn/mo-hop-iphone-xr-ban-mau-cam.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM028",
                        MaSanPham = "SP07",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/yWZQJPt/Iphone-XR-en.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM029",
                        MaSanPham = "SP07",
                        TenMauMa = "Vàng",
                        HinhAnh = "https://i.ibb.co/6y40G5v/20210416-6cec022bdb9abc311894b08e71bd0769-1618550179.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM030",
                        MaSanPham = "SP07",
                        TenMauMa = "Xanh",
                        HinhAnh = "https://i.ibb.co/2v36jLV/iphone-XR-64-GB.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM031",
                        MaSanPham = "SP08",
                        TenMauMa = "Bạc",
                        HinhAnh = "https://i.ibb.co/MNpLvHY/Oppo-reno6-z-5g-bac-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM032",
                        MaSanPham = "SP08",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/KXWZfKL/Oppo-reno6-z-5g-den-1-org.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM033",
                        MaSanPham = "SP09",
                        TenMauMa = "Xanh dương",
                        HinhAnh = "https://i.ibb.co/zRQB86R/Oppo-a74-xanh-duong-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM034",
                        MaSanPham = "SP09",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/M5Mk64X/Oppo-a74-den-5-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM035",
                        MaSanPham = "SP010",
                        TenMauMa = "Xanh dương",
                        HinhAnh = "https://i.ibb.co/jJ1XBWq/Oppo-reno6-pro-5g-xanh-duong-1.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM036",
                        MaSanPham = "SP010",
                        TenMauMa = "Xám",
                        HinhAnh = "https://i.ibb.co/yVs3g8T/Oppo-reno6-pro-5g-xam-1.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM037",
                        MaSanPham = "SP011",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/pw2Kqcp/Oppo-find-x3-pro-den-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM038",
                        MaSanPham = "SP011",
                        TenMauMa = "Xanh đen",
                        HinhAnh = "https://i.ibb.co/Rp3jcB3/Oppo-find-x3-pro-xanh-1-org.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM039",
                        MaSanPham = "SP012",
                        TenMauMa = "Bạc",
                        HinhAnh = "https://i.ibb.co/7YG6TFH/Oppo-reno6-bac-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM040",
                        MaSanPham = "SP012",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/zbPGb0s/Oppo-reno6-den-1-org.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM041",
                        MaSanPham = "SP013",
                        TenMauMa = "Bạc",
                        HinhAnh = "https://i.ibb.co/55BgPLp/Oppo-reno5-5g-bac-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM042",
                        MaSanPham = "SP013",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/MhHDY3L/Oppo-reno5-5g-den-org.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM043",
                        MaSanPham = "SP014",
                        TenMauMa = "Trắng",
                        HinhAnh = "https://i.ibb.co/94LDnqK/Oppo-reno4-pro-trang-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM044",
                        MaSanPham = "SP014",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/RBQ3zwg/Oppo-reno4-pro-den-1-org.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM045",
                        MaSanPham = "SP015",
                        TenMauMa = "Bạc",
                        HinhAnh = "https://i.ibb.co/vVV9xVR/Oppo-a16-1-2.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM044",
                        MaSanPham = "SP015",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/2M6JLdw/Oppo-a16-1-1.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM046",
                        MaSanPham = "SP016",
                        TenMauMa = "Trắng",
                        HinhAnh = "https://i.ibb.co/XWGXkDf/Vivo-y21-1-2.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM047",
                        MaSanPham = "SP016",
                        TenMauMa = "Xanh tím",
                        HinhAnh = "https://i.ibb.co/XYj2R7d/Vivo-y21-blue-gc-1-org.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM048",
                        MaSanPham = "SP017",
                        TenMauMa = "Xanh hồng",
                        HinhAnh = "https://i.ibb.co/TcQYYxs/Vivo-x70-pro-xanh-1-1.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM049",
                        MaSanPham = "SP017",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/NrnVRWj/Vivo-x70-pro-black-gc-org.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM050",
                        MaSanPham = "SP018",
                        TenMauMa = "Tím hồng",
                        HinhAnh = "https://i.ibb.co/S7Xy2TM/Vivo-v21-5g-tim-hong-1-3-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM051",
                        MaSanPham = "SP018",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/wwT6MVD/Vivo-v21-5g-xanh-den-1-org.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM052",
                        MaSanPham = "SP019",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/tcNjPQL/Vivo-v20-2021-den-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM053",
                        MaSanPham = "SP019",
                        TenMauMa = "Xanh hồng",
                        HinhAnh = "https://i.ibb.co/TLdWMdd/Vivo-v20-2021-xanh-hong-1-org.jpg",
                    },
                    //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM054",
                        MaSanPham = "SP020",
                        TenMauMa = "Đen",
                        HinhAnh = "https://i.ibb.co/mCbyxk9/Vivo-y72-5g-den-1-org.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM055",
                        MaSanPham = "SP020",
                        TenMauMa = "Xanh hồng",
                        HinhAnh = "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg",
                    }
                    , //
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM056",
                        MaSanPham = "SP021",
                        TenMauMa = "Trắng",
                        HinhAnh = "https://i.ibb.co/Yd1wV4H/Vivo-y21s-trang-1-1.jpg",
                    },
                    new MauMaSanPham()
                    {
                        MaMauMa = "MM057",
                        MaSanPham = "SP021",
                        TenMauMa = "Xanh",
                        HinhAnh = "https://i.ibb.co/5hkXcM1/Vivo-y21s-blue-gc-org.jpg",
                    }
                    );
            //Lịch sử giá
            modelBuilder.Entity<LichSuGia>().HasData(
                new LichSuGia()
                {
                    MaSanPham ="SP01",
                    DaXoa = true,
                    GiaMoi = 43990000,
                    NgayTao= DateTime.Parse("2021-10-16 00:00:00.0000000"),

                },
                new LichSuGia()
                {
                    MaSanPham ="SP02",
                    DaXoa = true,
                    GiaMoi = 24990000,
                    NgayTao= DateTime.Parse("2021-10-16 00:00:00.0000000"),

                },
                new LichSuGia()
                {
                    MaSanPham = "SP03",
                    DaXoa = true,
                    GiaMoi = 18700000,
                    NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                },
                new LichSuGia()
                {
                    MaSanPham = "SP04",
                    DaXoa = true,
                    GiaMoi = 31490000,
                    NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                },
                new LichSuGia()
                {
                    MaSanPham = "SP05",
                    DaXoa = true,
                    GiaMoi = 16490000,
                    NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                },
                new LichSuGia()
                {
                    MaSanPham = "SP06",
                    DaXoa = true,
                    GiaMoi = 16990000,
                    NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                },
                new LichSuGia()
                {
                    MaSanPham = "SP07",
                    DaXoa = true,
                    GiaMoi = 13490000,
                    NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                },
                new LichSuGia()
                {
                    MaSanPham = "SP08",
                    DaXoa = true,
                    GiaMoi = 9990000,
                    NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                },
                new LichSuGia()
                {
                    MaSanPham = "SP09",
                    DaXoa = true,
                    GiaMoi = 6990000,
                    NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                },
                new LichSuGia()
                {
                    MaSanPham = "SP010",
                    DaXoa = true,
                    GiaMoi = 18490000,
                    NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                },
                 //
                 new LichSuGia()
                 {
                     MaSanPham = "SP011",
                     DaXoa = true,
                     GiaMoi = 23990000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 },
                 //
                 new LichSuGia()
                 {
                     MaSanPham = "SP012",
                     DaXoa = true,
                     GiaMoi = 12990000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 },
                 //
                 new LichSuGia()
                 {
                     MaSanPham = "SP013",
                     DaXoa = true,
                     GiaMoi = 10990000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 },
                 //
                 new LichSuGia()
                 {
                     MaSanPham = "SP014",
                     DaXoa = true,
                     GiaMoi = 10490000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 },
                 //
                 new LichSuGia()
                 {
                     MaSanPham = "SP015",
                     DaXoa = true,
                     GiaMoi = 3990000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 },
                 //
                 new LichSuGia()
                 {
                     MaSanPham = "SP016",
                     DaXoa = true,
                     GiaMoi = 4290000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 },
                 //
                 new LichSuGia()
                 {
                     MaSanPham = "SP018",
                     DaXoa = true,
                     GiaMoi = 9490000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 },
                 //
                 new LichSuGia()
                 {
                     MaSanPham = "SP019",
                     DaXoa = true,
                     GiaMoi = 7790000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 },
                 //
                 new LichSuGia()
                 {
                     MaSanPham = "SP020",
                     DaXoa = true,
                     GiaMoi = 7590000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 },
                 //
                 new LichSuGia()
                 {
                     MaSanPham = "SP021",
                     DaXoa = true,
                     GiaMoi = 5990000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 },
                  //
                 new LichSuGia()
                 {
                     MaSanPham = "SP022",
                     DaXoa = true,
                     GiaMoi = 750000,
                     NgayTao = DateTime.Parse("2021-10-16 00:00:00.0000000"),

                 }
                );
            //ProductInDanhMuc
            //modelBuilder.Entity<ProductDanhMuc>().HasData(
            //    new ProductDanhMuc()
            //    {
            //        DanhMucId = "DM003",
            //        ProductId = "SP001"
            //    },
            //    new ProductDanhMuc()
            //    {
            //        DanhMucId = "DM003",
            //        ProductId = "SP002"
            //    });
            // any guid
            //var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            //modelBuilder.Entity<AppRole>().HasData(new AppRole
            //{
            //    Id = roleId,
            //    Name = "admin",
            //    NormalizedName = "admin",
            //    Description = "Administrator role"
            //});

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = adminId.ToString(),
                UserName = "havyclient1",
                NormalizedUserName = "havyclient1",
                Email = "yvonnetran.work@gmail.com",
                NormalizedEmail = "yvonnetran.work@gmail.com",
                PhoneNumber = "0905187524",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                Status = Enum.Status.Active
            },
            new ApplicationUser
            {
                Id = "04052000",
                UserName = "phamTVi0405",
                NormalizedUserName = "phamTVi0405",
                Email = "phamthivi459@gmail.com",
                NormalizedEmail = "phamthivi459@gmail.com",
                PhoneNumber = "0376437459",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "1810Abc$"),
                SecurityStamp = string.Empty,
                Status = Enum.Status.Active
            },
             new ApplicationUser
             {
                 Id = "123456789",
                 UserName = "danhVu",
                 NormalizedUserName = "danhVu",
                 Email = "danhVu@gmail.com",
                 NormalizedEmail = "danhVu@gmail.com",
                 PhoneNumber = "0376437459",
                 EmailConfirmed = true,
                 PasswordHash = hasher.HashPassword(null, "1234Abc$"),
                 SecurityStamp = string.Empty,
                 Status = Enum.Status.Active
             });

            modelBuilder.Entity<KhachHang>().HasData(new KhachHang
            {
                MaKhachHang = adminId.ToString(),
                Email = "yvonnetran.work@gmail.com",
                HoTen = "Yvonne Tran",
                GioiTinh = false,
                SDT = "0905187524",
            },
            new KhachHang
            {
                MaKhachHang = "KH01",
                Email = "phamthivi459@gmail.com",
                HoTen = "Phạm Thị Vi",
                GioiTinh = false,
                SDT = "0376437459",
            },
            new KhachHang
            {
                MaKhachHang = "KH02",
                Email = "danhVu@gmail.com",
                HoTen = "Danh Vũ",
                GioiTinh = false,
                SDT = "12345678",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                UserId = adminId
            });

            modelBuilder.Entity<BoPhan>().HasData(new BoPhan
            {
                MaBoPhan = "BP01",
                TenBoPhan = "Thu ngân",
            },
            new BoPhan
            {
                MaBoPhan = "BP02",
                TenBoPhan = "Nhân viên bán hàng",
            }, new BoPhan
            {
                MaBoPhan = "BP03",
                TenBoPhan = "Nhân viên Kho",
            },
            new BoPhan
            {
                 MaBoPhan = "BP04",
                 TenBoPhan = "Nhân viên kĩ thuật",
            });
            //Nhân viên
            modelBuilder.Entity<NhanVien>().HasData(
            new NhanVien()
            {
                MaNhanVien = "NV01",
                Username = "PhamTVi",
                TenNhanVien = "Phạm Thị Vi",
                DiaChi = "Quảng Ngãi",
                SDT ="0376437459",
                Mail = "phamthivi459@gmail.com",
                Status = Enum.Status.Active,
                NgaySinh = DateTime.Parse("04/05/2000"),
                NgayTao = DateTime.Now
            },
            new NhanVien()
            {
                MaNhanVien = "NV02",
                Username = "DanhVu",
                TenNhanVien = "Lê Danh Vũ",
                DiaChi = "Quảng Ngãi",
                SDT = "123456789",
                Mail = "danhvu@gmail.com",
                Status = Enum.Status.Active,
                NgaySinh = DateTime.Parse("06/05/2000"),
                NgayTao = DateTime.Now
            },
            new NhanVien()
            {
                MaNhanVien = "NV03",
                Username = "haVy",
                TenNhanVien = "Trần Nhật Hạ Vy",
                DiaChi = "Quảng Ngãi",
                Mail = "havy@gmail.com",
                SDT = "123456789",
                Status = Enum.Status.Active,
                NgaySinh = DateTime.Parse("07/05/2000"),
                NgayTao = DateTime.Now
            });
        modelBuilder.Entity<DiaChiKhachHang>().HasData(
             new DiaChiKhachHang()
             {
                 MaKhachHang = "KH01",
                 MaDiaChi ="DC01",
                 DiaChi ="Hẻm 1 Bùi Xuân Phái, Tây Thạnh, Tân Phú, HCM",
                 SDT = "0376437459",
                 NgayTao = DateTime.Now,
                 DaXoa = true,
             },
             new DiaChiKhachHang()
             {
                 MaKhachHang = "KH01",
                 MaDiaChi = "DC02",
                 DiaChi = "140 Lê Trọng Tấn,",
                 SDT = "0376437459",
                 NgayTao = DateTime.Now,
                 DaXoa = true,
             }) ;
        }
    }
}
