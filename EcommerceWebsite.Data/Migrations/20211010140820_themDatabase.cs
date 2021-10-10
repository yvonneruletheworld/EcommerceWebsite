using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class themDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOPHAN",
                columns: table => new
                {
                    MaBP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenBP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOPHAN", x => x.MaBP);
                });

            migrationBuilder.CreateTable(
                name: "HANGSANPHAM",
                columns: table => new
                {
                    MaHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HANGSANPHAM", x => x.MaHang);
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHACHHANG", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "KHUYENMAI",
                columns: table => new
                {
                    MaKM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenKM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhanTram = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHUYENMAI", x => x.MaKM);
                });

            migrationBuilder.CreateTable(
                name: "LOAISANPHAM",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAISANPHAM", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "NHACUNGCAP",
                columns: table => new
                {
                    MaNCC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenNCC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHACUNGCAP", x => x.MaNCC);
                });

            migrationBuilder.CreateTable(
                name: "THUOCTINH",
                columns: table => new
                {
                    MaTT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenTT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUOCTINH", x => x.MaTT);
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenNV = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaBP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANVIEN", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NHANVIEN_BOPHAN_MaBP",
                        column: x => x.MaBP,
                        principalTable: "BOPHAN",
                        principalColumn: "MaBP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIACHIKH",
                columns: table => new
                {
                    MaDiaChiKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChiGH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIACHIKH", x => new { x.MaDiaChiKH, x.MaKH });
                    table.ForeignKey(
                        name: "FK_DIACHIKH_KHACHHANG_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "0"),
                    MaHang = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SANPHAM", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SANPHAM_HANGSANPHAM_MaHang",
                        column: x => x.MaHang,
                        principalTable: "HANGSANPHAM",
                        principalColumn: "MaHang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SANPHAM_LOAISANPHAM_MaLoaiSP",
                        column: x => x.MaLoaiSP,
                        principalTable: "LOAISANPHAM",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NHAPSANPHAM",
                columns: table => new
                {
                    MaNhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaNV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaNCC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHAPSANPHAM", x => x.MaNhap);
                    table.ForeignKey(
                        name: "FK_NHAPSANPHAM_NHACUNGCAP_MaNCC",
                        column: x => x.MaNCC,
                        principalTable: "NHACUNGCAP",
                        principalColumn: "MaNCC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NHAPSANPHAM_NHANVIEN_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NHANVIEN",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaDiaChiKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "money", nullable: false),
                    PhiGH = table.Column<decimal>(type: "money", nullable: false),
                    TongTien = table.Column<decimal>(type: "money", nullable: false),
                    TrangThaiTT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADON", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HOADON_DIACHIKH_MaDiaChiKH_MaKH",
                        columns: x => new { x.MaDiaChiKH, x.MaKH },
                        principalTable: "DIACHIKH",
                        principalColumns: new[] { "MaDiaChiKH", "MaKH" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HOADON_KHACHHANG_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HOADON_KHUYENMAI_MaKM",
                        column: x => x.MaKM,
                        principalTable: "KHUYENMAI",
                        principalColumn: "MaKM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DANHGIASP",
                columns: table => new
                {
                    MaDG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnhDG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANHGIASP", x => x.MaDG);
                    table.ForeignKey(
                        name: "FK_DANHGIASP_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DINHLUONG",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaTT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTri = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DINHLUONG", x => new { x.MaTT, x.MaSP });
                    table.ForeignKey(
                        name: "FK_DINHLUONG_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DINHLUONG_THUOCTINH_MaTT",
                        column: x => x.MaTT,
                        principalTable: "THUOCTINH",
                        principalColumn: "MaTT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LICHSUGIA",
                columns: table => new
                {
                    NgayBD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gia = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LICHSUGIA", x => new { x.MaSP, x.NgayBD });
                    table.ForeignKey(
                        name: "FK_LICHSUGIA_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MAUSANPHAM",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenMau = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAUSANPHAM", x => new { x.MaSP, x.TenMau });
                    table.ForeignKey(
                        name: "FK_MAUSANPHAM_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NHANXETSP",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soSao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANXETSP", x => new { x.MaKH, x.MaSP });
                    table.ForeignKey(
                        name: "FK_NHANXETSP_KHACHHANG_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NHANXETSP_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTNHAPSP",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaNhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DonGia = table.Column<decimal>(type: "money", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTNHAPSP", x => new { x.MaNhap, x.MaSP });
                    table.ForeignKey(
                        name: "FK_CTNHAPSP_NHAPSANPHAM_MaNhap",
                        column: x => x.MaNhap,
                        principalTable: "NHAPSANPHAM",
                        principalColumn: "MaNhap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTNHAPSP_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTHOADON",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DonGia = table.Column<decimal>(type: "money", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTHOADON", x => new { x.MaHD, x.MaSP });
                    table.ForeignKey(
                        name: "FK_CTHOADON_HOADON_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HOADON",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTHOADON_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GIAOHANG",
                columns: table => new
                {
                    MaGH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaHD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThaiHienTai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTiepNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDuKienGiao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIAOHANG", x => x.MaGH);
                    table.ForeignKey(
                        name: "FK_GIAOHANG_HOADON_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HOADON",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TINHTRANGIAOHANG",
                columns: table => new
                {
                    MaTTGH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaGH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayThucHien = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TINHTRANGIAOHANG", x => new { x.MaGH, x.MaTTGH });
                    table.ForeignKey(
                        name: "FK_TINHTRANGIAOHANG_GIAOHANG_MaGH",
                        column: x => x.MaGH,
                        principalTable: "GIAOHANG",
                        principalColumn: "MaGH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CTHOADON_MaSP",
                table: "CTHOADON",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_CTNHAPSP_MaSP",
                table: "CTNHAPSP",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_DANHGIASP_MaSP",
                table: "DANHGIASP",
                column: "MaSP",
                unique: true,
                filter: "[MaSP] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DIACHIKH_MaKH",
                table: "DIACHIKH",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_DINHLUONG_MaSP",
                table: "DINHLUONG",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_GIAOHANG_MaHD",
                table: "GIAOHANG",
                column: "MaHD",
                unique: true,
                filter: "[MaHD] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaDiaChiKH_MaKH",
                table: "HOADON",
                columns: new[] { "MaDiaChiKH", "MaKH" });

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaKH",
                table: "HOADON",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaKM",
                table: "HOADON",
                column: "MaKM");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_MaBP",
                table: "NHANVIEN",
                column: "MaBP");

            migrationBuilder.CreateIndex(
                name: "IX_NHANXETSP_MaSP",
                table: "NHANXETSP",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_NHAPSANPHAM_MaNCC",
                table: "NHAPSANPHAM",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_NHAPSANPHAM_MaNV",
                table: "NHAPSANPHAM",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_MaHang",
                table: "SANPHAM",
                column: "MaHang");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_MaLoaiSP",
                table: "SANPHAM",
                column: "MaLoaiSP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CTHOADON");

            migrationBuilder.DropTable(
                name: "CTNHAPSP");

            migrationBuilder.DropTable(
                name: "DANHGIASP");

            migrationBuilder.DropTable(
                name: "DINHLUONG");

            migrationBuilder.DropTable(
                name: "LICHSUGIA");

            migrationBuilder.DropTable(
                name: "MAUSANPHAM");

            migrationBuilder.DropTable(
                name: "NHANXETSP");

            migrationBuilder.DropTable(
                name: "TINHTRANGIAOHANG");

            migrationBuilder.DropTable(
                name: "NHAPSANPHAM");

            migrationBuilder.DropTable(
                name: "THUOCTINH");

            migrationBuilder.DropTable(
                name: "SANPHAM");

            migrationBuilder.DropTable(
                name: "GIAOHANG");

            migrationBuilder.DropTable(
                name: "NHACUNGCAP");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "HANGSANPHAM");

            migrationBuilder.DropTable(
                name: "LOAISANPHAM");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "BOPHAN");

            migrationBuilder.DropTable(
                name: "DIACHIKH");

            migrationBuilder.DropTable(
                name: "KHUYENMAI");

            migrationBuilder.DropTable(
                name: "KHACHHANG");
        }
    }
}
