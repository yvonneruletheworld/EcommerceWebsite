﻿// <auto-generated />
using System;
using EcommerceWebsite.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcommerceWebsite.Data.Migrations
{
    [DbContext(typeof(EcomWebDbContext))]
    [Migration("20211011142926_capnhatlaisql")]
    partial class capnhatlaisql
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.BoPhan", b =>
                {
                    b.Property<string>("MaBoPhan")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenBoPhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaBoPhan");

                    b.ToTable("BOPHAN");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.CTHoaDon", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaSanPham")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("DonGia")
                        .HasColumnType("money");

                    b.Property<int>("SoLuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("money");

                    b.HasKey("MaHoaDon", "MaSanPham");

                    b.HasIndex("MaSanPham");

                    b.ToTable("CTHOADON");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.CTNhapSP", b =>
                {
                    b.Property<string>("MaNhap")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaSanPham")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("DonGia")
                        .HasColumnType("money");

                    b.Property<int>("SoLuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("money");

                    b.HasKey("MaNhap", "MaSanPham");

                    b.HasIndex("MaSanPham");

                    b.ToTable("CTNHAPSP");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.DanhGiaSP", b =>
                {
                    b.Property<string>("MaDanhGia")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HinhAnhDG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaSanPham")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDanhGia");

                    b.HasIndex("MaSanPham")
                        .IsUnique()
                        .HasFilter("[MaSanPham] IS NOT NULL");

                    b.ToTable("DANHGIASP");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.DiaChiKH", b =>
                {
                    b.Property<string>("MaDiaChiKH")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaKhachHang")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DiaChiGH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("MaDiaChiKH", "MaKhachHang");

                    b.HasIndex("MaKhachHang");

                    b.ToTable("DIACHIKH");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.DinhLuong", b =>
                {
                    b.Property<string>("MaThuocTinh")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaSanPham")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DonVi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("GiaTri")
                        .HasColumnType("real");

                    b.HasKey("MaThuocTinh", "MaSanPham");

                    b.HasIndex("MaSanPham");

                    b.ToTable("DINHLUONG");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.GiaoHang", b =>
                {
                    b.Property<string>("MaGiaoHanh")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaHoaDon")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgayDuKienGiao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayGiao")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("NgayTiepNhan")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrangThaiHienTai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaGiaoHanh");

                    b.HasIndex("MaHoaDon")
                        .IsUnique()
                        .HasFilter("[MaHoaDon] IS NOT NULL");

                    b.ToTable("GIAOHANG");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.HangSanPham", b =>
                {
                    b.Property<string>("MaHang")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaHang");

                    b.ToTable("HANGSANPHAM");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.HoaDon", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaDiaChiKH")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaKhachHang")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaKhuyenMai")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PhiGH")
                        .HasColumnType("money");

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("money");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("money");

                    b.Property<string>("TrangThaiTT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("MaKhachHang");

                    b.HasIndex("MaKhuyenMai");

                    b.HasIndex("MaDiaChiKH", "MaKhachHang");

                    b.ToTable("HOADON");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.KhachHang", b =>
                {
                    b.Property<string>("MaKhachHang")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaKhachHang");

                    b.ToTable("KHACHHANG");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.KhuyenMai", b =>
                {
                    b.Property<string>("MaKhuyenMai")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayBD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKT")
                        .HasColumnType("datetime2");

                    b.Property<float>("PhanTram")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<string>("TenKhuyenMai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKhuyenMai");

                    b.ToTable("KHUYENMAI");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.LichSuGia", b =>
                {
                    b.Property<string>("MaSanPham")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgayBD")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Gia")
                        .HasColumnType("money");

                    b.HasKey("MaSanPham", "NgayBD");

                    b.ToTable("LICHSUGIA");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.LoaiSanPham", b =>
                {
                    b.Property<string>("MaLoai")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaLoai");

                    b.ToTable("LOAISANPHAM");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.MauSanPham", b =>
                {
                    b.Property<string>("MaSanPham")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenMau")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSanPham", "TenMau");

                    b.ToTable("MAUSANPHAM");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.NhaCungCap", b =>
                {
                    b.Property<string>("MaNhaCungCap")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("TenNhaCungCap")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaNhaCungCap");

                    b.ToTable("NHACUNGCAP");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.NhanVien", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaBoPhan")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaNhanVien");

                    b.HasIndex("MaBoPhan");

                    b.ToTable("NHANVIEN");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.NhanXetSP", b =>
                {
                    b.Property<string>("MaKhachHang")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaSanPham")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("soSao")
                        .HasColumnType("int");

                    b.HasKey("MaKhachHang", "MaSanPham");

                    b.HasIndex("MaSanPham");

                    b.ToTable("NHANXETSP");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.NhapSanPham", b =>
                {
                    b.Property<string>("MaNhap")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaNhaCungCap")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaNhanVien")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("money");

                    b.HasKey("MaNhap");

                    b.HasIndex("MaNhaCungCap");

                    b.HasIndex("MaNhanVien");

                    b.ToTable("NHAPSANPHAM");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.SanPham", b =>
                {
                    b.Property<string>("MaSanPham")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaHang")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaLoai")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("0");

                    b.Property<int>("SoLuongTon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("MaSanPham");

                    b.HasIndex("MaHang");

                    b.HasIndex("MaLoai");

                    b.ToTable("SANPHAM");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.ThuocTinh", b =>
                {
                    b.Property<string>("MaThuocTinh")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenThuocTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaThuocTinh");

                    b.ToTable("THUOCTINH");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.TinhTrangGH", b =>
                {
                    b.Property<string>("MaGiaoHang")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaTinhTrangGH")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgayThucHien")
                        .HasColumnType("datetime2");

                    b.Property<string>("TinhTrang")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaGiaoHang", "MaTinhTrangGH");

                    b.ToTable("TINHTRANGIAOHANG");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.CTHoaDon", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.HoaDon", "hoaDon")
                        .WithMany("cTHoaDons")
                        .HasForeignKey("MaHoaDon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceWebsite.Data.Entities.SanPham", "sanPham")
                        .WithMany("cTHoaDons")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hoaDon");

                    b.Navigation("sanPham");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.CTNhapSP", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.NhapSanPham", "nhapSanPham")
                        .WithMany("cTNhapSPs")
                        .HasForeignKey("MaNhap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceWebsite.Data.Entities.SanPham", "sanPham")
                        .WithMany("cTNhapSPs")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("nhapSanPham");

                    b.Navigation("sanPham");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.DanhGiaSP", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.SanPham", "sanPhams")
                        .WithOne("danhGiaSP")
                        .HasForeignKey("EcommerceWebsite.Data.Entities.DanhGiaSP", "MaSanPham");

                    b.Navigation("sanPhams");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.DiaChiKH", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.KhachHang", "khachHang")
                        .WithMany("diaChiKHs")
                        .HasForeignKey("MaKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("khachHang");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.DinhLuong", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.SanPham", "sanPham")
                        .WithMany("dinhLuongs")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceWebsite.Data.Entities.ThuocTinh", "thuocTinh")
                        .WithMany("dinhLuongs")
                        .HasForeignKey("MaThuocTinh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sanPham");

                    b.Navigation("thuocTinh");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.GiaoHang", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.HoaDon", "hoaDons")
                        .WithOne("giaoHang")
                        .HasForeignKey("EcommerceWebsite.Data.Entities.GiaoHang", "MaHoaDon");

                    b.Navigation("hoaDons");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.HoaDon", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.KhachHang", "khachHangs")
                        .WithMany("hoaDons")
                        .HasForeignKey("MaKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceWebsite.Data.Entities.KhuyenMai", "khuyenMais")
                        .WithMany("hoaDons")
                        .HasForeignKey("MaKhuyenMai");

                    b.HasOne("EcommerceWebsite.Data.Entities.DiaChiKH", "diaChiKHs")
                        .WithMany("hoaDons")
                        .HasForeignKey("MaDiaChiKH", "MaKhachHang");

                    b.Navigation("diaChiKHs");

                    b.Navigation("khachHangs");

                    b.Navigation("khuyenMais");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.LichSuGia", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.SanPham", "sanPham")
                        .WithMany("lishSuGias")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sanPham");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.MauSanPham", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.SanPham", "sanPham")
                        .WithMany("mauSanPhams")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sanPham");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.NhanVien", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.BoPhan", "BoPhan")
                        .WithMany("nhanViens")
                        .HasForeignKey("MaBoPhan");

                    b.Navigation("BoPhan");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.NhanXetSP", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.KhachHang", "KhachHangs")
                        .WithMany("nhanXetSPs")
                        .HasForeignKey("MaKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceWebsite.Data.Entities.SanPham", "sanPhams")
                        .WithMany("nhanXetSPs")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHangs");

                    b.Navigation("sanPhams");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.NhapSanPham", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.NhaCungCap", "nhaCungCaps")
                        .WithMany("nhapSanPhams")
                        .HasForeignKey("MaNhaCungCap");

                    b.HasOne("EcommerceWebsite.Data.Entities.NhanVien", "nhanViens")
                        .WithMany("nhapSanPhams")
                        .HasForeignKey("MaNhanVien");

                    b.Navigation("nhaCungCaps");

                    b.Navigation("nhanViens");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.SanPham", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.HangSanPham", "hangSanPhams")
                        .WithMany("sanPhams")
                        .HasForeignKey("MaHang");

                    b.HasOne("EcommerceWebsite.Data.Entities.LoaiSanPham", "loaiSanPhams")
                        .WithMany("sanPhams")
                        .HasForeignKey("MaLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hangSanPhams");

                    b.Navigation("loaiSanPhams");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.TinhTrangGH", b =>
                {
                    b.HasOne("EcommerceWebsite.Data.Entities.GiaoHang", "giaoHangs")
                        .WithMany("tinhTrangGHs")
                        .HasForeignKey("MaGiaoHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("giaoHangs");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.BoPhan", b =>
                {
                    b.Navigation("nhanViens");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.DiaChiKH", b =>
                {
                    b.Navigation("hoaDons");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.GiaoHang", b =>
                {
                    b.Navigation("tinhTrangGHs");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.HangSanPham", b =>
                {
                    b.Navigation("sanPhams");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.HoaDon", b =>
                {
                    b.Navigation("cTHoaDons");

                    b.Navigation("giaoHang");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.KhachHang", b =>
                {
                    b.Navigation("diaChiKHs");

                    b.Navigation("hoaDons");

                    b.Navigation("nhanXetSPs");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.KhuyenMai", b =>
                {
                    b.Navigation("hoaDons");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.LoaiSanPham", b =>
                {
                    b.Navigation("sanPhams");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.NhaCungCap", b =>
                {
                    b.Navigation("nhapSanPhams");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.NhanVien", b =>
                {
                    b.Navigation("nhapSanPhams");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.NhapSanPham", b =>
                {
                    b.Navigation("cTNhapSPs");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.SanPham", b =>
                {
                    b.Navigation("cTHoaDons");

                    b.Navigation("cTNhapSPs");

                    b.Navigation("danhGiaSP");

                    b.Navigation("dinhLuongs");

                    b.Navigation("lishSuGias");

                    b.Navigation("mauSanPhams");

                    b.Navigation("nhanXetSPs");
                });

            modelBuilder.Entity("EcommerceWebsite.Data.Entities.ThuocTinh", b =>
                {
                    b.Navigation("dinhLuongs");
                });
#pragma warning restore 612, 618
        }
    }
}
