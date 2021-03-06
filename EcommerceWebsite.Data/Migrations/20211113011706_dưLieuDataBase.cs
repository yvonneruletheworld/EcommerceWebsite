using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class dưLieuDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    IdAuto = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BANNER",
                columns: table => new
                {
                    MaBanner = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HinhAnhBanner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANNER", x => x.MaBanner);
                });

            migrationBuilder.CreateTable(
                name: "BOPHAN",
                columns: table => new
                {
                    MaBoPhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenBoPhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOPHAN", x => x.MaBoPhan);
                });

            migrationBuilder.CreateTable(
                name: "DANHMUC",
                columns: table => new
                {
                    MaDanhMuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HienThiTrangHome = table.Column<bool>(type: "bit", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANHMUC", x => x.MaDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    MaKhachHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHACHHANG", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "KHUYENMAI",
                columns: table => new
                {
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhanTram = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHUYENMAI", x => x.MaKhuyenMai);
                });

            migrationBuilder.CreateTable(
                name: "NHACUNGCAP",
                columns: table => new
                {
                    MaNhaCungCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHACUNGCAP", x => x.MaNhaCungCap);
                });

            migrationBuilder.CreateTable(
                name: "NHANHIEU",
                columns: table => new
                {
                    MaHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANHIEU", x => x.MaHang);
                });

            migrationBuilder.CreateTable(
                name: "THUOCTINH",
                columns: table => new
                {
                    MaThuocTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenThuocTinh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUOCTINH", x => x.MaThuocTinh);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaBoPhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LoginString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANVIEN", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_NHANVIEN_BOPHAN_MaBoPhan",
                        column: x => x.MaBoPhan,
                        principalTable: "BOPHAN",
                        principalColumn: "MaBoPhan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIACHIKHACHHANG",
                columns: table => new
                {
                    MaDiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhPho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhuongXa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiDiaChi = table.Column<int>(type: "int", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    MacDinh = table.Column<bool>(type: "bit", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIACHIKHACHHANG", x => new { x.MaDiaChi, x.MaKhachHang });
                    table.ForeignKey(
                        name: "FK_DIACHIKHACHHANG_KHACHHANG_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Utility = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SANPHAM", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "FK_SANPHAM_DANHMUC_MaLoaiSanPham",
                        column: x => x.MaLoaiSanPham,
                        principalTable: "DANHMUC",
                        principalColumn: "MaDanhMuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SANPHAM_NHANHIEU_MaHang",
                        column: x => x.MaHang,
                        principalTable: "NHANHIEU",
                        principalColumn: "MaHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUNHAP",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaNhanVien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaNhaCungCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TongTien = table.Column<decimal>(type: "money", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIEUNHAP", x => x.MaPhieuNhap);
                    table.ForeignKey(
                        name: "FK_PHIEUNHAP_NHACUNGCAP_MaNhaCungCap",
                        column: x => x.MaNhaCungCap,
                        principalTable: "NHACUNGCAP",
                        principalColumn: "MaNhaCungCap",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PHIEUNHAP_NHANVIEN_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NHANVIEN",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TongCong = table.Column<decimal>(type: "money", nullable: false),
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaDiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThanhTien = table.Column<decimal>(type: "money", nullable: false),
                    TinhTrang = table.Column<int>(type: "int", nullable: false),
                    PhiGiaoHang = table.Column<decimal>(type: "money", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADON", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HOADON_DIACHIKHACHHANG_MaDiaChi_MaKhachHang",
                        columns: x => new { x.MaDiaChi, x.MaKhachHang },
                        principalTable: "DIACHIKHACHHANG",
                        principalColumns: new[] { "MaDiaChi", "MaKhachHang" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HOADON_KHACHHANG_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HOADON_KHUYENMAI_MaKhuyenMai",
                        column: x => x.MaKhuyenMai,
                        principalTable: "KHUYENMAI",
                        principalColumn: "MaKhuyenMai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BINHLUANSANPHAM",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoSao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BINHLUANSANPHAM", x => new { x.MaKhachHang, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_BINHLUANSANPHAM_KHACHHANG_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BINHLUANSANPHAM_SANPHAM_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DANHGIASANPHAM",
                columns: table => new
                {
                    MaDanhGia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnhDanhGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANHGIASANPHAM", x => x.MaDanhGia);
                    table.ForeignKey(
                        name: "FK_DANHGIASANPHAM_SANPHAM_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DINHLUONG",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaThuocTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTri = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DINHLUONG", x => new { x.MaThuocTinh, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_DINHLUONG_SANPHAM_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DINHLUONG_THUOCTINH_MaThuocTinh",
                        column: x => x.MaThuocTinh,
                        principalTable: "THUOCTINH",
                        principalColumn: "MaThuocTinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LICHSUGIA",
                columns: table => new
                {
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GiaMoi = table.Column<decimal>(type: "money", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LICHSUGIA", x => new { x.MaSanPham, x.NgayTao });
                    table.ForeignKey(
                        name: "FK_LICHSUGIA_SANPHAM_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MAUMASANPHAM",
                columns: table => new
                {
                    MaMauMa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenMauMa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAUMASANPHAM", x => new { x.MaSanPham, x.MaMauMa });
                    table.ForeignKey(
                        name: "FK_MAUMASANPHAM_SANPHAM_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAMYEUTHICH",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    trangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SANPHAMYEUTHICH", x => new { x.MaKhachHang, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_SANPHAMYEUTHICH_KHACHHANG_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SANPHAMYEUTHICH_SANPHAM_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETNHAPSANPHAM",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaNhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DonGia = table.Column<decimal>(type: "money", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETNHAPSANPHAM", x => new { x.MaNhap, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_CHITIETNHAPSANPHAM_PHIEUNHAP_MaNhap",
                        column: x => x.MaNhap,
                        principalTable: "PHIEUNHAP",
                        principalColumn: "MaPhieuNhap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETNHAPSANPHAM_SANPHAM_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETHOADON",
                columns: table => new
                {
                    HoaDonId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    GiaBan = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETHOADON", x => new { x.ProductId, x.HoaDonId });
                    table.ForeignKey(
                        name: "FK_CHITIETHOADON_HOADON_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HOADON",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETHOADON_SANPHAM_ProductId",
                        column: x => x.ProductId,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GIAOHANG",
                columns: table => new
                {
                    MaGiaoHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaHoaDon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThaiHienTai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTiepNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDuKienGiao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIAOHANG", x => x.MaGiaoHang);
                    table.ForeignKey(
                        name: "FK_GIAOHANG_HOADON_MaHoaDon",
                        column: x => x.MaHoaDon,
                        principalTable: "HOADON",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TINHTRANGIAOHANG",
                columns: table => new
                {
                    MaTinhTrangGiaoHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaGiaoHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TinhTrang = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSuaCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TINHTRANGIAOHANG", x => new { x.MaGiaoHang, x.MaTinhTrangGiaoHang });
                    table.ForeignKey(
                        name: "FK_TINHTRANGIAOHANG_GIAOHANG_MaGiaoHang",
                        column: x => x.MaGiaoHang,
                        principalTable: "GIAOHANG",
                        principalColumn: "MaGiaoHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountNumber", "ConcurrencyStamp", "CreateUserId", "DeleteTime", "DeleteUserId", "Discriminator", "Email", "EmailConfirmed", "IdAuto", "Ip", "IsDeleted", "LastModificationTime", "LastModificationUserId", "LockoutEnabled", "LockoutEnd", "LoginString", "NormalizedEmail", "NormalizedUserName", "OTPCode", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04052000", 0, null, "78a7d96d-c1af-410f-bfd6-4aeac7f07871", null, null, null, "ApplicationUser", "phamthivi459@gmail.com", true, null, null, false, null, null, false, null, null, "phamthivi459@gmail.com", "phamTVi0405", null, "AQAAAAEAACcQAAAAEPgtHQclacizGt8phXGUqfOFWLZ5Ck3Gy3QqRd3CmLTWp2oC0CGB4ku7l8qODPsd0Q==", "0376437459", false, "", 1, false, "phamTVi0405" },
                    { "8d04dce2-969a-435d-bba4-df3f325983dc", 0, null, "af7ba4bb-f603-439f-9e3f-cf2995d76d16", null, null, null, "ApplicationUser", "yvonnetran.work@gmail.com", true, null, null, false, null, null, false, null, null, "yvonnetran.work@gmail.com", "havyclient1", null, "AQAAAAEAACcQAAAAEJ1iuWC34zwgkjpP2Z/GCLqH2s6CERixLp8m8WPx9Ef3GSp9K4hIJ0I2O6TwWxVZSA==", "0905187524", false, "", 1, false, "havyclient1" },
                    { "123456789", 0, null, "52efe294-d096-4133-a02c-c470b35f5af1", null, null, null, "ApplicationUser", "danhVu@gmail.com", true, null, null, false, null, null, false, null, null, "danhVu@gmail.com", "danhVu", null, "AQAAAAEAACcQAAAAED1tEFdvwjBqi1jOysBSw4EpU4fCI3VaXaaayfjEW3U2u15xzNumgjL/DR3vfFuvMg==", "0376437459", false, "", 1, false, "danhVu" }
                });

            migrationBuilder.InsertData(
                table: "BOPHAN",
                columns: new[] { "MaBoPhan", "TenBoPhan" },
                values: new object[,]
                {
                    { "BP01", "Thu ngân" },
                    { "BP02", "Nhân viên bán hàng" },
                    { "BP03", "Nhân viên Kho" },
                    { "BP04", "Nhân viên kĩ thuật" }
                });

            migrationBuilder.InsertData(
                table: "DANHMUC",
                columns: new[] { "MaDanhMuc", "DaXoa", "HienThiTrangHome", "HinhAnh", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa", "ParentId", "Status", "TenDanhMuc" },
                values: new object[,]
                {
                    { "DM04", false, true, "https://i.ibb.co/QHfCkK1/28-11-2020-0-16065566805fc21c0855b09-0.jpg", null, new DateTime(2021, 11, 13, 1, 17, 5, 522, DateTimeKind.Utc).AddTicks(7767), null, null, "admin", null, "DM01", 1, "Phụ kiện" },
                    { "DM03", false, true, "https://i.ibb.co/3fWbd3c/Dong-ho-haylou-h3.jpg", null, new DateTime(2021, 11, 13, 1, 17, 5, 522, DateTimeKind.Utc).AddTicks(7838), null, null, "admin", null, "DM01", 1, "Đồng hồ" },
                    { "DM02", false, true, "https://i.ibb.co/sHxtWdf/Song-toi-gian-may-tinh-1.jpg", null, new DateTime(2021, 11, 13, 1, 17, 5, 522, DateTimeKind.Utc).AddTicks(7844), null, null, "admin", null, "DM01", 1, "PC, Máy in" },
                    { "DM01", false, true, "https://i.ibb.co/NSBhk4f/E5wft-Ni-Vk-AQHbh-S.jpg", null, new DateTime(2021, 11, 13, 1, 17, 5, 522, DateTimeKind.Utc).AddTicks(5947), null, null, "admin", null, null, 1, "Điện thoại" }
                });

            migrationBuilder.InsertData(
                table: "KHACHHANG",
                columns: new[] { "MaKhachHang", "DaXoa", "GioiTinh", "HinhAnh", "HoTen", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa" },
                values: new object[,]
                {
                    { "8d04dce2-969a-435d-bba4-df3f325983dc", false, false, null, "Yvonne Tran", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { "KH01", false, false, null, "Phạm Thị Vi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { "KH02", false, false, null, "Danh Vũ", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "KHUYENMAI",
                columns: new[] { "MaKhuyenMai", "DaXoa", "HinhAnh", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa", "PhanTram", "TenKhuyenMai" },
                values: new object[,]
                {
                    { "KM01", true, "https://cdn.tgdd.vn/2021/11/banner/830-300(1)-830x300.png", null, new DateTime(2021, 11, 13, 8, 17, 5, 565, DateTimeKind.Local).AddTicks(155), null, null, null, null, 35f, "Đồng hồ thời trang giảm 35%" },
                    { "KM02", true, "https://cdn.tgdd.vn/2021/10/banner/830-300-830x300-29.png", null, new DateTime(2021, 11, 13, 8, 17, 5, 565, DateTimeKind.Local).AddTicks(205), null, null, null, null, 15f, "Apple Watch S6 giảm đến 15%" },
                    { "KM03", true, "https://cdn.tgdd.vn/2021/11/banner/big11-pk-830-300-830x300.png", null, new DateTime(2021, 11, 13, 8, 17, 5, 565, DateTimeKind.Local).AddTicks(209), null, null, null, null, 50f, "Phụ kiện giảm đến 50%" },
                    { "KM04", true, "https://cdn.tgdd.vn/2021/11/banner/830-300-830x300-6.png", null, new DateTime(2021, 11, 13, 8, 17, 5, 565, DateTimeKind.Local).AddTicks(223), null, null, null, null, 25f, "Apple Watch S6 giảm đến 25%" }
                });

            migrationBuilder.InsertData(
                table: "NHANHIEU",
                columns: new[] { "MaHang", "HinhAnh", "TenHang" },
                values: new object[,]
                {
                    { "MH09", null, "HYDRUS" },
                    { "MH08", null, "NOKIA" },
                    { "MH07", null, "VSMAST" },
                    { "MH05", null, "XIAOMI" },
                    { "MH04", null, "VIVO" },
                    { "MH03", null, "OPPO" },
                    { "MH01", null, "IPHONE" },
                    { "MH02", null, "SAMSUNG" },
                    { "MH06", null, "REALME" }
                });

            migrationBuilder.InsertData(
                table: "NHANVIEN",
                columns: new[] { "MaNhanVien", "DaXoa", "DiaChi", "HinhAnh", "LoginString", "MaBoPhan", "Mail", "NgaySinh", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa", "SDT", "Status", "TenNhanVien", "Username" },
                values: new object[,]
                {
                    { "NV01", false, "Quảng Ngãi", null, null, null, "phamthivi459@gmail.com", new DateTime(2000, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 13, 8, 17, 5, 564, DateTimeKind.Local).AddTicks(2496), null, null, null, null, "0376437459", 1, "Phạm Thị Vi", "PhamTVi" },
                    { "NV03", false, "Quảng Ngãi", null, null, null, "havy@gmail.com", new DateTime(2000, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 13, 8, 17, 5, 564, DateTimeKind.Local).AddTicks(6141), null, null, null, null, "123456789", 1, "Trần Nhật Hạ Vy", "haVy" },
                    { "NV02", false, "Quảng Ngãi", null, null, null, "danhvu@gmail.com", new DateTime(2000, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 13, 8, 17, 5, 564, DateTimeKind.Local).AddTicks(6118), null, null, null, null, "123456789", 1, "Lê Danh Vũ", "DanhVu" }
                });

            migrationBuilder.InsertData(
                table: "THUOCTINH",
                columns: new[] { "MaThuocTinh", "TenThuocTinh" },
                values: new object[,]
                {
                    { "TT03", "Camera sau" },
                    { "TT04", "Camera trước" },
                    { "TT05", "Chip" },
                    { "TT01", "Màn hình" },
                    { "TT07", "Bộ nhớ trong" },
                    { "TT08", "SIM" },
                    { "TT09", "Pin, Sạc" },
                    { "TT010", "Trọng lượng Pin" },
                    { "TT011", "Kết nối với hệ điều hành" },
                    { "TT012", "Mặt" },
                    { "TT013", "Tính năng cho sức khỏe" }
                });

            migrationBuilder.InsertData(
                table: "THUOCTINH",
                columns: new[] { "MaThuocTinh", "TenThuocTinh" },
                values: new object[] { "TT02", "Hệ điều hành" });

            migrationBuilder.InsertData(
                table: "THUOCTINH",
                columns: new[] { "MaThuocTinh", "TenThuocTinh" },
                values: new object[] { "TT06", "RAM" });

            migrationBuilder.InsertData(
                table: "DIACHIKHACHHANG",
                columns: new[] { "MaDiaChi", "MaKhachHang", "DaXoa", "DiaChi", "Hoten", "LoaiDiaChi", "MacDinh", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa", "PhuongXa", "QuanHuyen", "SDT", "ThanhPho", "Tinh" },
                values: new object[,]
                {
                    { "DC01", "KH01", true, "Hẻm 1 Bùi Xuân Phái, Tây Thạnh, Tân Phú, HCM", null, 0, false, null, new DateTime(2021, 11, 13, 8, 17, 5, 564, DateTimeKind.Local).AddTicks(8239), null, null, null, null, null, null, "0376437459", null, null },
                    { "DC02", "KH01", true, "140 Lê Trọng Tấn,", null, 0, false, null, new DateTime(2021, 11, 13, 8, 17, 5, 564, DateTimeKind.Local).AddTicks(8292), null, null, null, null, null, null, "0376437459", null, null }
                });

            migrationBuilder.InsertData(
                table: "SANPHAM",
                columns: new[] { "MaSanPham", "DaXoa", "HinhAnh", "MaHang", "MaLoaiSanPham", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa", "SoLuongTon", "Status", "TenSanPham", "Utility" },
                values: new object[,]
                {
                    { "SP019", false, "https://i.ibb.co/TLdWMdd/Vivo-v20-2021-xanh-hong-1-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2955), null, null, "admin", null, 1, 1, "Vivo V20 (2021)", 0m },
                    { "SP018", false, "https://i.ibb.co/S7Xy2TM/Vivo-v21-5g-tim-hong-1-3-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2951), null, null, "admin", null, 1, 1, "Vivo V21 5G", 0m },
                    { "SP017", false, "https://i.ibb.co/NrnVRWj/Vivo-x70-pro-black-gc-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2943), null, null, "admin", null, 1, 1, "Vivo X70 Pro 5G", 0m },
                    { "SP016", false, "https://i.ibb.co/XWGXkDf/Vivo-y21-1-2.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2939), null, null, "admin", null, 1, 1, "OPPO A16", 0m },
                    { "SP015", false, "https://i.ibb.co/vVV9xVR/Oppo-a16-1-2.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2935), null, null, "admin", null, 1, 1, "OPPO A16", 0m },
                    { "SP014", false, "https://i.ibb.co/94LDnqK/Oppo-reno4-pro-trang-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2931), null, null, "admin", null, 1, 1, "OPPO Reno4 Pro", 0m },
                    { "SP013", false, "https://i.ibb.co/55BgPLp/Oppo-reno5-5g-bac-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2927), null, null, "admin", null, 1, 1, "OPPO Reno5 5G", 0m },
                    { "SP012", false, "https://i.ibb.co/zbPGb0s/Oppo-reno6-den-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2922), null, null, "admin", null, 1, 1, "OPPO Reno6 5G", 0m },
                    { "SP011", false, "https://i.ibb.co/pw2Kqcp/Oppo-find-x3-pro-den-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2918), null, null, "admin", null, 1, 1, "OPPO Find X3 Pro 5G", 0m },
                    { "SP010", false, "https://i.ibb.co/ydCdghQ/Oppo-reno6-pro-5g-xanh-duong-1.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2914), null, null, "admin", null, 1, 1, "OPPO Reno6 Pro 5G", 0m },
                    { "SP09", false, "https://i.ibb.co/zRQB86R/Oppo-a74-xanh-duong-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2907), null, null, "admin", null, 1, 1, "OPPO A74", 0m },
                    { "SP08", false, "https://i.ibb.co/1rp5mbM/Oppo-reno6-z-5g-bac-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2902), null, null, "admin", null, 1, 1, "OPPO Reno6 Z 5G", 0m },
                    { "SP026", false, "https://i.ibb.co/ydJ9XY5/Samsung-galaxy-watch-4-44mm-den-1-org.jpg", "MH02", "DM03", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2987), null, null, "admin", null, 1, 1, "Samsung Galaxy Watch 4 44mm ", 0m },
                    { "SP025", false, "https://i.ibb.co/9yR299t/Samsung-galaxy-watch-3-45mm-bac-2-org.jpg", "MH02", "DM03", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2981), null, null, "admin", null, 1, 1, "Samsung Galaxy Watch 3 45mm viền thép bạc dây da", 0m },
                    { "SP022", false, "https://i.ibb.co/k5rV9Vg/Samsung-galaxy-watch-4-44mm-den-1-org.jpg", "MH02", "DM03", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2968), null, null, "admin", null, 1, 1, "Samsung Galaxy Watch 4 44mm", 0m },
                    { "SP02", false, "https://i.ibb.co/CPq556s/Samsung-galaxy-z-flip-3-kem-1-org.jpg", "MH02", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2825), null, null, "admin", null, 1, 1, "Samsung Galaxy Z Flip3 5G 128GB", 0m },
                    { "SP01", false, "https://i.ibb.co/T2Ywg8N/Samsung-galaxy-z-fold-3-silver-gc-org.jpg", "MH02", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(1823), null, null, "admin", null, 1, 1, "Samsung Galaxy Z Fold3 5G 512GB", 0m },
                    { "SP028", false, "https://i.ibb.co/ZW5Wqpk/Apple-watch-s7-45mm-gps-do-1.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2995), null, null, "admin", null, 1, 1, "Apple Watch Series 7 GPS 45mm ", 0m },
                    { "SP027", false, "https://i.ibb.co/2YttfZB/Apple-watch-s6-lte-40mm-vien-thep-day-thep-vang-cont-1-org.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2991), null, null, "admin", null, 1, 1, "Apple Watch S6 LTE 40mm viền thép dây thép ", 0m },
                    { "SP024", false, "https://i.ibb.co/rcfS9Nm/Untitled-1-org.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2977), null, null, "admin", null, 1, 1, "Apple Watch SE 40mm viền nhôm dây cao su", 0m },
                    { "SP023", false, "https://i.ibb.co/bHRpNch/Apple-watch-s6-40mm-vien-nhom-day-cao-su-xanh-cont-1-org.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2973), null, null, "admin", null, 1, 1, "Apple Watch S6 40mm viền nhôm dây cao su", 0m },
                    { "SP07", false, "https://i.ibb.co/2v36jLV/iphone-XR-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2898), null, null, "admin", null, 1, 1, "iPhone XR 64GB", 0m },
                    { "SP06", false, "https://i.ibb.co/hZS5MJ3/Iphone-11-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2893), null, null, "admin", null, 1, 1, "iPhone 11 64GB", 0m },
                    { "SP05", false, "https://i.ibb.co/vsLZ8km/Iphone-12-mini-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2875), null, null, "admin", null, 1, 1, "iPhone 12 mini 64GB", 0m },
                    { "SP04", false, "https://i.ibb.co/JQNGCzb/Iphone-12-pro-max-128-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2871), null, null, "admin", null, 1, 1, "iPhone 12 Pro Max 128GB", 0m },
                    { "SP03", false, "https://i.ibb.co/RNz8N1G/Iphone-12-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2867), null, null, "admin", null, 1, 1, "iPhone 12 64GB", 0m },
                    { "SP020", false, "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2959), null, null, "admin", null, 1, 1, "Vivo Y72 5G", 0m },
                    { "SP021", false, "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 13, 1, 17, 5, 524, DateTimeKind.Utc).AddTicks(2964), null, null, "admin", null, 1, 1, "Vivo Y21s 6GB", 0m }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP03", "TT01", "OLED, 6.1, Super Retina XDR", 0f },
                    { "SP010", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP010", "TT09", "4500 mAh, 65 W", 0f },
                    { "SP011", "TT01", "AMOLED, 6.7, Quad HD+ (2K+)", 0f },
                    { "SP011", "TT02", "Android 11", 0f },
                    { "SP011", "TT03", "Chính 50 MP & Phụ 50 MP, 13 MP, 3 MP", 0f },
                    { "SP011", "TT04", "32 MP", 0f },
                    { "SP011", "TT05", "Snapdragon 888", 0f },
                    { "SP011", "TT06", "GB", 12f },
                    { "SP011", "TT07", "GB", 256f },
                    { "SP011", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP011", "TT09", "4500 mAh, 65 W", 0f },
                    { "SP012", "TT01", "AMOLED, 6.43, Full HD+", 0f },
                    { "SP012", "TT02", "Android 11", 0f },
                    { "SP012", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP012", "TT04", "32 MP", 0f },
                    { "SP012", "TT05", "MediaTek Dimensity 900 5G", 0f },
                    { "SP012", "TT06", "GB", 8f },
                    { "SP014", "TT02", "Android 10", 0f },
                    { "SP014", "TT01", "AMOLED, 6.5, Full HD + ", 0f },
                    { "SP013", "TT09", "4300 mAh, 65 W", 0f },
                    { "SP013", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP013", "TT07", "GB", 128f },
                    { "SP013", "TT06", "GB", 8f },
                    { "SP010", "TT07", "GB", 256f },
                    { "SP013", "TT05", "Snapdragon 765G", 0f },
                    { "SP013", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP, 2 MP", 0f },
                    { "SP013", "TT02", "Android 11", 0f },
                    { "SP013", "TT01", "AMOLED, 6.43, Full HD + ", 0f },
                    { "SP012", "TT09", "4300 mAh, 65 W", 0f },
                    { "SP012", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP012", "TT07", "GB", 128f },
                    { "SP013", "TT04", "32 MP", 0f },
                    { "SP014", "TT03", "Chính 48 MP & Phụ 8 MP, 2 MP, 2 MP", 0f },
                    { "SP010", "TT06", "GB", 12f },
                    { "SP010", "TT04", "32 MP", 0f },
                    { "SP022", "TT013", "Theo dõi giấc ngủ, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân", 0f },
                    { "SP025", "TT01", "SUPER AMOLED, 1.4 inch", 0f },
                    { "SP025", "TT010", "Khoảng 2 ngày", 0f },
                    { "SP025", "TT011", "Android 5.0 trở lên, iOS 9 trở lên", 0f },
                    { "SP025", "TT012", "Kính cường lực Gorrilla Glass Dx+, 45 mm", 0f },
                    { "SP025", "TT013", "Chế độ luyện tập, Theo dõi giấc ngủ, Tính lượng calories tiêu thụ, Tính quãng đường chạy, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân", 0f }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP026", "TT01", "SUPER AMOLED, 1.36 inch", 0f },
                    { "SP026", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP026", "TT011", "Android dùng Google Mobile Service", 0f },
                    { "SP026", "TT012", "Kính cường lực Gorrilla Glass Dx+, 44 mm", 0f },
                    { "SP026", "TT013", "Theo dõi giấc ngủ, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân", 0f },
                    { "SP08", "TT01", "AMOLED, 6.43, Full HD + ", 0f },
                    { "SP08", "TT02", "Android 11", 0f },
                    { "SP08", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP08", "TT05", "MediaTek Dimensity 800U 5G", 0f },
                    { "SP08", "TT06", "GB", 8f },
                    { "SP08", "TT07", "GB", 128f },
                    { "SP010", "TT03", "Chính 50 MP & Phụ 16 MP, 13 MP, 2 MP", 0f },
                    { "SP010", "TT02", "Android 11", 0f },
                    { "SP010", "TT01", "AMOLED6.55, Full HD+", 0f },
                    { "SP09", "TT09", "5000 mAh, 30 W", 0f },
                    { "SP09", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP09", "TT07", "GB", 128f },
                    { "SP010", "TT05", "Snapdragon 870 5G", 0f },
                    { "SP09", "TT06", "GB", 8f },
                    { "SP09", "TT04", "16 MP", 0f },
                    { "SP09", "TT03", "Chính 48 MP & Phụ 2 MP, 2 MP", 0f },
                    { "SP09", "TT02", "Android 11", 0f },
                    { "SP09", "TT01", "AMOLED6.43, Full HD + ", 0f },
                    { "SP08", "TT09", "4310 mAh, 30 W", 0f },
                    { "SP08", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP09", "TT05", "Snapdragon 662", 0f },
                    { "SP022", "TT012", "Kính cường lực Gorrilla Glass Dx+, 44 mm", 0f },
                    { "SP014", "TT04", "32 MP", 0f },
                    { "SP014", "TT06", "GB", 8f },
                    { "SP018", "TT06", "GB", 8f },
                    { "SP018", "TT07", "GB", 128f },
                    { "SP018", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP018", "TT09", "4000 mAh, 43 W", 0f },
                    { "SP019", "TT01", "IPS LCD, 6.44 HD + ", 0f },
                    { "SP019", "TT02", "Android 11", 0f },
                    { "SP019", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP019", "TT04", "44 MP", 0f },
                    { "SP019", "TT05", "Snapdragon 730", 0f },
                    { "SP019", "TT06", "GB", 8f },
                    { "SP019", "TT07", "GB", 128f },
                    { "SP019", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP019", "TT09", "4000 mAh, 33 W", 0f }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP020", "TT01", "IPS LCD, 6.58 HD + ", 0f },
                    { "SP020", "TT02", "Android 11", 0f },
                    { "SP020", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP020", "TT04", "16 MP", 0f },
                    { "SP021", "TT09", "5000 mAh, 18 W", 0f },
                    { "SP021", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP021", "TT07", "GB", 128f },
                    { "SP021", "TT06", "GB", 6f },
                    { "SP021", "TT05", "MediaTek Dimensity G80", 0f },
                    { "SP021", "TT04", "8 MP", 0f },
                    { "SP018", "TT05", "MediaTek Dimensity 800U 5G", 0f },
                    { "SP021", "TT03", "Chính 50 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP021", "TT01", "IPS LCD, 6.51 HD + ", 0f },
                    { "SP020", "TT09", "5000 mAh, 18 W", 0f },
                    { "SP020", "TT08", "2 Nano SIM (SIM 2 chung khe thẻ nhớ) Hỗ trợ 5G", 0f },
                    { "SP020", "TT07", "GB", 128f },
                    { "SP020", "TT06", "GB", 8f },
                    { "SP020", "TT05", "MediaTek Dimensity 700", 0f },
                    { "SP021", "TT02", "Android 11", 0f },
                    { "SP014", "TT05", "Snapdragon 720G", 0f },
                    { "SP018", "TT04", "44 MP", 0f },
                    { "SP018", "TT02", "Android 11", 0f },
                    { "SP014", "TT07", "GB", 256f },
                    { "SP014", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP014", "TT09", "4000 mAh, 65 W", 0f },
                    { "SP015", "TT01", "IPS LCD, 6.52, HD + ", 0f },
                    { "SP015", "TT02", "Android 11", 0f },
                    { "SP015", "TT03", "Chính 13 MP & Phụ 2 MP, 2 MP", 0f },
                    { "SP015", "TT04", "8 MP", 0f },
                    { "SP015", "TT05", "MediaTek Helio G35", 0f },
                    { "SP015", "TT06", "GB", 3f },
                    { "SP015", "TT07", "GB", 32f },
                    { "SP015", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP015", "TT09", "5000 mAh, 10 W", 0f },
                    { "SP016", "TT01", "IPS LCD, 6.51 HD + ", 0f },
                    { "SP016", "TT02", "Android 11", 0f },
                    { "SP016", "TT03", "Chính 13 MP & Phụ 2 MP", 0f },
                    { "SP016", "TT04", "8 MP", 0f },
                    { "SP016", "TT05", "MediaTek Helio P35", 0f },
                    { "SP018", "TT01", "IPS LCD, 6.44 HD + ", 0f },
                    { "SP017", "TT09", "4500 mAh, 44 W", 0f },
                    { "SP017", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP017", "TT07", "GB", 256f },
                    { "SP017", "TT06", "GB", 12f },
                    { "SP017", "TT05", "MediaTek Dimensity 1200", 0f },
                    { "SP018", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP017", "TT04", "8 MP", 0f },
                    { "SP017", "TT02", "Android 11", 0f },
                    { "SP017", "TT01", "IPS LCD, 6.56 HD + ", 0f },
                    { "SP016", "TT09", "5000 mAh, 18 W", 0f },
                    { "SP016", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP016", "TT07", "GB", 64f },
                    { "SP016", "TT06", "GB", 4f },
                    { "SP017", "TT03", "Chính 13 MP & Phụ 2 MP", 0f },
                    { "SP022", "TT011", "Android dùng Google Mobile Service", 0f },
                    { "SP08", "TT04", "32 MP", 0f },
                    { "SP022", "TT01", "SUPER AMOLED, 1.36 inch", 0f },
                    { "SP05", "TT03", "2 camera 12 MP", 0f },
                    { "SP027", "TT01", "OLED, 1.57 inch", 0f },
                    { "SP027", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP027", "TT011", "iOS 14 trở lên", 0f },
                    { "SP027", "TT012", "Kính cường lực Sapphire40 mm", 0f },
                    { "SP027", "TT013", "Chế độ luyện tập, Theo dõi giấc ngủ, Tính lượng calories tiêu thụ, Tính quãng đường chạy, Đo nhịp tim, Đếm số bước chân", 0f },
                    { "SP05", "TT04", "12 MP", 0f },
                    { "SP07", "TT04", "7 MP", 0f },
                    { "SP04", "TT04", "12 MP", 0f },
                    { "SP07", "TT03", "12 MP", 0f },
                    { "SP07", "TT02", "iOS 14", 0f },
                    { "SP04", "TT02", "iOS 14", 0f },
                    { "SP028", "TT01", "OLED, 1.77 inch", 0f },
                    { "SP028", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP028", "TT011", "iOS 14 trở lên", 0f },
                    { "SP028", "TT012", "Ion-X strengthened glass45 mm", 0f },
                    { "SP028", "TT013", "Chế độ luyện tập, Theo dõi giấc ngủ, Tính lượng calories tiêu thụ, Tính quãng đường chạy, Điện tâm đồ, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân", 0f },
                    { "SP07", "TT01", "IPS LCD, 6.1, Liquid Retina", 0f },
                    { "SP04", "TT03", "3 camera 12 MP", 0f },
                    { "SP04", "TT01", "OLED, 6.7, Super Retina XDR", 0f },
                    { "SP04", "TT05", "Apple A14 Bionic", 0f },
                    { "SP07", "TT05", "Apple A12 Bionic", 0f },
                    { "SP023", "TT01", "OLED, 1.57 inch", 0f },
                    { "SP023", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP023", "TT011", "iOS 14 trở lên", 0f },
                    { "SP023", "TT012", "Ion-X strengthened glass, 40 mm", 0f },
                    { "SP023", "TT013", "Chế độ luyện tập, Theo dõi giấc ngủ, Tính lượng calories tiêu thụ, Tính quãng đường chạy, Điện tâm đồ, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân", 0f }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP05", "TT02", "iOS 14", 0f },
                    { "SP07", "TT09", "2942 mAh, 15 W", 0f },
                    { "SP07", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 4G", 0f },
                    { "SP04", "TT06", "GB", 6f },
                    { "SP07", "TT07", "GB", 64f },
                    { "SP04", "TT09", "3687 mAh, 20 W", 0f },
                    { "SP04", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 5G", 0f },
                    { "SP04", "TT07", "GB", 128f },
                    { "SP024", "TT01", "OLED, 1.57 inch", 0f },
                    { "SP024", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP024", "TT011", "iOS 14 trở lên", 0f },
                    { "SP024", "TT012", "Ion-X strengthened glass, 40 mm", 0f },
                    { "SP024", "TT013", "Chế độ luyện tập, Theo dõi giấc ngủ, Tính lượng calories tiêu thụ, Tính quãng đường chạy, Đo nhịp tim, Đếm số bước chân", 0f },
                    { "SP07", "TT06", "GB", 3f },
                    { "SP022", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP05", "TT05", "Apple A14 Bionic", 0f },
                    { "SP05", "TT07", "GB", 64f },
                    { "SP03", "TT07", "GB", 64f },
                    { "SP03", "TT06", "GB", 4f },
                    { "SP03", "TT05", "Apple A14 Bionic", 0f },
                    { "SP06", "TT03", "2 camera 12 MP", 0f },
                    { "SP02", "TT02", "Android 11", 0f },
                    { "SP02", "TT03", "2 camera 12 MP", 0f },
                    { "SP02", "TT04", "10 MP", 0f },
                    { "SP02", "TT05", "Snapdragon 888", 0f },
                    { "SP02", "TT06", "GB", 8f },
                    { "SP03", "TT04", "12 MP", 0f },
                    { "SP06", "TT02", "iOS 14", 0f },
                    { "SP02", "TT07", "GB", 128f },
                    { "SP02", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 5G", 0f },
                    { "SP02", "TT09", "3300 mAh, 25 W", 0f },
                    { "SP03", "TT03", "2 camera 12 MP", 0f },
                    { "SP03", "TT02", "iOS 14", 0f },
                    { "SP06", "TT01", "IPS LCD, 6.1, Liquid Retina", 0f },
                    { "SP02", "TT01", "Dynamic AMOLED 2X, Chính 6.7 & Phụ 1.9, Full HD+", 0f },
                    { "SP05", "TT06", "GB", 4f },
                    { "SP03", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 5G", 0f },
                    { "SP01", "TT04", "10 MP & 4 MP", 0f },
                    { "SP05", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 5G", 0f },
                    { "SP05", "TT09", "2227 mAh, 20 W", 0f },
                    { "SP01", "TT01", "Dynamic AMOLED 2X, Chính 7.6 & Phụ 6.2, Full HD+", 0f },
                    { "SP01", "TT02", "Android 11", 0f }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP01", "TT03", "3 camera 12 MP", 0f },
                    { "SP03", "TT09", "2815 mAh, 20 W", 0f },
                    { "SP01", "TT05", "Snapdragon 888", 0f },
                    { "SP01", "TT06", "GB", 12f },
                    { "SP05", "TT01", "OLED, 5.4, Super Retina XDR", 0f },
                    { "SP06", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 4G", 0f },
                    { "SP06", "TT07", "GB", 64f },
                    { "SP01", "TT07", "GB", 512f },
                    { "SP01", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP01", "TT09", "4400 mAh, 25 W", 0f },
                    { "SP06", "TT06", "GB", 4f },
                    { "SP06", "TT05", "Apple A13 Bionic", 0f },
                    { "SP06", "TT04", "12 MP", 0f },
                    { "SP06", "TT09", "3110 mAh, 18 W", 0f }
                });

            migrationBuilder.InsertData(
                table: "LICHSUGIA",
                columns: new[] { "MaSanPham", "NgayTao", "DaXoa", "GiaMoi", "NgaySuaCuoi", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa" },
                values: new object[,]
                {
                    { "SP07", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 13490000m, null, null, null, null, null },
                    { "SP06", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 16990000m, null, null, null, null, null },
                    { "SP016", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4290000m, null, null, null, null, null },
                    { "SP05", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 16490000m, null, null, null, null, null },
                    { "SP015", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3990000m, null, null, null, null, null },
                    { "SP014", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10490000m, null, null, null, null, null },
                    { "SP011", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 23990000m, null, null, null, null, null },
                    { "SP027", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 16792000m, null, null, null, null, null },
                    { "SP01", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 43990000m, null, null, null, null, null },
                    { "SP08", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9990000m, null, null, null, null, null },
                    { "SP028", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12990000m, null, null, null, null, null },
                    { "SP010", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 18490000m, null, null, null, null, null },
                    { "SP03", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 18700000m, null, null, null, null, null },
                    { "SP026", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6990000m, null, null, null, null, null },
                    { "SP020", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7590000m, null, null, null, null, null },
                    { "SP019", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7790000m, null, null, null, null, null },
                    { "SP018", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9490000m, null, null, null, null, null },
                    { "SP025", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4990000m, null, null, null, null, null },
                    { "SP012", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12990000m, null, null, null, null, null },
                    { "SP04", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 31490000m, null, null, null, null, null },
                    { "SP02", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 24990000m, null, null, null, null, null },
                    { "SP022", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 750000m, null, null, null, null, null },
                    { "SP023", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9592000m, null, null, null, null, null },
                    { "SP021", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5990000m, null, null, null, null, null },
                    { "SP013", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10990000m, null, null, null, null, null },
                    { "SP024", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8450000m, null, null, null, null, null },
                    { "SP09", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6990000m, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "MAUMASANPHAM",
                columns: new[] { "MaMauMa", "MaSanPham", "HinhAnh", "TenMauMa" },
                values: new object[] { "MM054", "SP020", "https://i.ibb.co/mCbyxk9/Vivo-y72-5g-den-1-org.jpg", "Đen" });

            migrationBuilder.InsertData(
                table: "MAUMASANPHAM",
                columns: new[] { "MaMauMa", "MaSanPham", "HinhAnh", "TenMauMa" },
                values: new object[,]
                {
                    { "MM015", "SP04", "https://i.ibb.co/5LvRhJ4/Iphone-12-pro-max-xanh-duong-1-org.jpg", "Xanh" },
                    { "MM016", "SP05", "https://i.ibb.co/crZFrkD/Iphone-12-mini-den-1-1-org.jpg", "Đen" },
                    { "MM055", "SP020", "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg", "Xanh hồng" },
                    { "MM07", "SP03", "https://i.ibb.co/0qYwZ5c/Iphone-12-64-GB-en.jpg", "Đen" },
                    { "MM010", "SP03", "https://i.ibb.co/vsLZ8km/Iphone-12-mini-64-GB.jpg", "Trắng" },
                    { "MM048", "SP017", "https://i.ibb.co/TcQYYxs/Vivo-x70-pro-xanh-1-1.jpg", "Xanh hồng" },
                    { "MM09", "SP03", "https://i.ibb.co/GC6Tdwd/Iphone-12-64-GB-T-m.jpg", "Tím" },
                    { "MM049", "SP017", "https://i.ibb.co/NrnVRWj/Vivo-x70-pro-black-gc-org.jpg", "Đen" },
                    { "MM011", "SP03", "https://i.ibb.co/6XtyJbM/Iphone-12-64-GB-Xanh.jpg", "Xanh" },
                    { "MM012", "SP03", "https://i.ibb.co/D5Xg9sQ/Iphone-12-64-GB-Xanh-l.jpg", "Xanh lá" },
                    { "MM053", "SP019", "https://i.ibb.co/TLdWMdd/Vivo-v20-2021-xanh-hong-1-org.jpg", "Xanh hồng" },
                    { "MM052", "SP019", "https://i.ibb.co/tcNjPQL/Vivo-v20-2021-den-1-org.jpg", "Đen" },
                    { "MM017", "SP05", "https://i.ibb.co/jkmt501/Iphone-12-mini-1-1-org.jpg", "Đỏ" },
                    { "MM013", "SP04", "https://i.ibb.co/pW2nvth/Iphone-12-pro-max-bac-1-org.jpg", "Bạc" },
                    { "MM014", "SP04", "https://i.ibb.co/JQNGCzb/Iphone-12-pro-max-128-GB.jpg", "Vàng" },
                    { "MM051", "SP018", "https://i.ibb.co/wwT6MVD/Vivo-v21-5g-xanh-den-1-org.jpg", "Đen" },
                    { "MM050", "SP018", "https://i.ibb.co/S7Xy2TM/Vivo-v21-5g-tim-hong-1-3-org.jpg", "Tím hồng" },
                    { "MM08", "SP03", "https://i.ibb.co/RNz8N1G/Iphone-12-64-GB.jpg", "Đỏ" },
                    { "MM018", "SP05", "https://i.ibb.co/30KH8b2/Iphone-12-mini-tim-gc-1-org.jpg", "Tím" },
                    { "MM028", "SP07", "https://i.ibb.co/yWZQJPt/Iphone-XR-en.jpg", "Đen" },
                    { "MM020", "SP05", "https://i.ibb.co/Np97nN6/Iphone-12-mini-xanh-duong-1-1-org.jpg", "Xanh dương" },
                    { "MM069", "SP027", "https://i.ibb.co/2YttfZB/Apple-watch-s6-lte-40mm-vien-thep-day-thep-vang-cont-1-org.jpg", "vàng" },
                    { "MM036", "SP010", "https://i.ibb.co/yVs3g8T/Oppo-reno6-pro-5g-xam-1.jpg", "Xám" },
                    { "MM035", "SP010", "https://i.ibb.co/jJ1XBWq/Oppo-reno6-pro-5g-xanh-duong-1.jpg", "Xanh dương" },
                    { "MM070", "SP027", "https://i.ibb.co/JH2Fshs/Apple-watch-s6-lte-40mm-vien-thep-day-thep-den-cont-1-org.jpg", "Đen" },
                    { "MM071", "SP028", "https://i.ibb.co/mDSQcPD/Apple-watch-s7-45mm-gps-den-1.jpg", "Đen" },
                    { "MM072", "SP028", "https://i.ibb.co/BrWrjZh/Apple-watch-s7-45mm-gps-vang-1.jp", "Vàng" },
                    { "MM034", "SP09", "https://i.ibb.co/M5Mk64X/Oppo-a74-den-5-org.jpg", "Đen" },
                    { "MM033", "SP09", "https://i.ibb.co/zRQB86R/Oppo-a74-xanh-duong-1-org.jpg", "Xanh dương" },
                    { "MM073", "SP028", "https://i.ibb.co/ZW5Wqpk/Apple-watch-s7-45mm-gps-do-1.jpg", "Đỏ" },
                    { "MM074", "SP028", "https://i.ibb.co/Qjbqcqf/Apple-watch-s7-45mm-gps-xanh-duong-1.jpg", "Xanh Dương" },
                    { "MM075", "SP028", "ttps://i.ibb.co/V9d5FLq/apple-watch-s7-45mm-gps-xanh-la-1.jpg", "Xanh Lá" },
                    { "MM064", "SP024", "https://i.ibb.co/3dBt9bj/Se-40mm-vien-nhom-day-cao-su-hong-glr-1-org.jpg", "Đen" },
                    { "MM032", "SP08", "https://i.ibb.co/KXWZfKL/Oppo-reno6-z-5g-den-1-org.jpg", "Đen" },
                    { "MM01", "SP01", "https://i.ibb.co/9WvYqLR/Samsung-galaxy-z-fold3-5g-1.jpg", "Xanh riêu" },
                    { "MM056", "SP021", "https://i.ibb.co/Yd1wV4H/Vivo-y21s-trang-1-1.jpg", "Trắng" },
                    { "MM02", "SP01", "https://i.ibb.co/T2Ywg8N/Samsung-galaxy-z-fold-3-silver-gc-org.jpg", "Bạc" },
                    { "MM03", "SP01", "https://i.ibb.co/qyCNcw6/Samsung-galaxy-z-fold-3-1-org.jpg", "Đen" },
                    { "MM068", "SP026", "https://i.ibb.co/XVM9Mxj/Samsung-galaxy-watch-4-44mm-bac-1-org.jpg", "Bạc" },
                    { "MM067", "SP026", "https://i.ibb.co/s2mSnhK/Samsung-galaxy-watch-4-44mm-1-1.jpg", "Xanh lá" },
                    { "MM066", "SP026", "https://i.ibb.co/ydJ9XY5/Samsung-galaxy-watch-4-44mm-den-1-org.jpg", "Đen" },
                    { "MM065", "SP025", "https://i.ibb.co/9yR299t/Samsung-galaxy-watch-3-45mm-bac-2-org.jpg", "Bạc" }
                });

            migrationBuilder.InsertData(
                table: "MAUMASANPHAM",
                columns: new[] { "MaMauMa", "MaSanPham", "HinhAnh", "TenMauMa" },
                values: new object[,]
                {
                    { "MM04", "SP02", "https://i.ibb.co/CPq556s/Samsung-galaxy-z-flip-3-kem-1-org.jpg", "Kem" },
                    { "MM05", "SP02", "https://i.ibb.co/0tXPPWn/Samsung-galaxy-z-flip-3-black-gc-org.jpg", "Đen" },
                    { "MM06", "SP02", "https://i.ibb.co/9WvYqLR/Samsung-galaxy-z-fold3-5g-1.jpg", "Xanh riêu" },
                    { "MM031", "SP08", "https://i.ibb.co/MNpLvHY/Oppo-reno6-z-5g-bac-1-org.jpg", "Bạc" },
                    { "MM019", "SP05", "https://i.ibb.co/5LRj1Wh/Iphone-12-mini-trang-1-1-org.jpg", "Trắng" },
                    { "MM063", "SP024", "https://i.ibb.co/rcfS9Nm/Untitled-1-org.jpg", "Hồng" },
                    { "MM038", "SP011", "https://i.ibb.co/Rp3jcB3/Oppo-find-x3-pro-xanh-1-org.jpg", "Xanh đen" },
                    { "MM021", "SP05", "https://i.ibb.co/0stYCyp/Iphone-11-den-1-1-1-org.jpg", "Đen" },
                    { "MM047", "SP016", "https://i.ibb.co/XYj2R7d/Vivo-y21-blue-gc-1-org.jpg", "Xanh tím" },
                    { "MM046", "SP016", "https://i.ibb.co/XWGXkDf/Vivo-y21-1-2.jpg", "Trắng" },
                    { "MM044", "SP015", "https://i.ibb.co/2M6JLdw/Oppo-a16-1-1.jpg", "Đen" },
                    { "MM045", "SP015", "https://i.ibb.co/vVV9xVR/Oppo-a16-1-2.jpg", "Bạc" },
                    { "MM022", "SP06", "https://i.ibb.co/WBH28Zh/Iphone-11-do-1-1-1-org.jpg", "Đỏ" },
                    { "MM023", "SP06", "https://i.ibb.co/Lnt4WzS/Iphone-11-tim-1-1-1-org.jpg", "Tím" },
                    { "MM024", "SP06", "https://i.ibb.co/pLyJDFG/Iphone-11-trang-1-2-org.jpg", "Trắng" },
                    { "MM025", "SP06", "https://i.ibb.co/26xpZH9/Iphone-11-vang-1-2-org.jpg", "Vàng" },
                    { "MM026", "SP06", "https://i.ibb.co/hZS5MJ3/Iphone-11-64-GB.jpg", "Xanh lá" },
                    { "MM044", "SP014", "https://i.ibb.co/RBQ3zwg/Oppo-reno4-pro-den-1-org.jpg", "Đen" },
                    { "MM037", "SP011", "https://i.ibb.co/pw2Kqcp/Oppo-find-x3-pro-den-1-org.jpg", "Đen" },
                    { "MM043", "SP014", "https://i.ibb.co/94LDnqK/Oppo-reno4-pro-trang-1-org.jpg", "Trắng" },
                    { "MM029", "SP07", "https://i.ibb.co/6y40G5v/20210416-6cec022bdb9abc311894b08e71bd0769-1618550179.jpg", "Vàng" },
                    { "MM042", "SP013", "https://i.ibb.co/MhHDY3L/Oppo-reno5-5g-den-org.jpg", "Đen" },
                    { "MM041", "SP013", "https://i.ibb.co/55BgPLp/Oppo-reno5-5g-bac-1-org.jpg", "Bạc" },
                    { "MM030", "SP07", "https://i.ibb.co/2v36jLV/iphone-XR-64-GB.jpg", "Xanh" },
                    { "MM058", "SP023", "https://i.ibb.co/whQPQYR/Apple-watch-s6-40mm-vien-nhom-day-cao-su-hong-cont-1-org.jpg", "Hồng" },
                    { "MM059", "SP023", "https://i.ibb.co/bHRpNch/Apple-watch-s6-40mm-vien-nhom-day-cao-su-xanh-cont-1-org.jpg", "Xanh dương đậm" },
                    { "MM040", "SP012", "https://i.ibb.co/zbPGb0s/Oppo-reno6-den-1-org.jpg", "Đen" },
                    { "MM039", "SP012", "https://i.ibb.co/7YG6TFH/Oppo-reno6-bac-1-org.jpg", "Bạc" },
                    { "MM060", "SP023", "https://i.ibb.co/vV2zr9s/Apple-watch-s6-40mm-vien-nhom-day-cao-su-trang-cont-1-org.jpg", "Trắng" },
                    { "MM061", "SP023", "https://i.ibb.co/sPCkGSb/Apple-watch-s6-40mm-vien-nhom-day-cao-su-den-cont-1-org.jpg", "Đen" },
                    { "MM062", "SP023", "https://i.ibb.co/4TQV8yv/Apple-watch-s6-40mm-vien-nhom-day-cao-su-red-do-cont-1-org-org.jp", "Đỏ" },
                    { "MM027", "SP07", "https://i.ibb.co/8d4VJxn/mo-hop-iphone-xr-ban-mau-cam.jpg", "Cam" },
                    { "MM057", "SP021", "https://i.ibb.co/5hkXcM1/Vivo-y21s-blue-gc-org.jpg", "Xanh" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdAuto",
                table: "AspNetUsers",
                column: "IdAuto",
                unique: true,
                filter: "[IdAuto] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BINHLUANSANPHAM_MaSanPham",
                table: "BINHLUANSANPHAM",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETHOADON_HoaDonId",
                table: "CHITIETHOADON",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETNHAPSANPHAM_MaSanPham",
                table: "CHITIETNHAPSANPHAM",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DANHGIASANPHAM_MaSanPham",
                table: "DANHGIASANPHAM",
                column: "MaSanPham",
                unique: true,
                filter: "[MaSanPham] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DIACHIKHACHHANG_MaKhachHang",
                table: "DIACHIKHACHHANG",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DINHLUONG_MaSanPham",
                table: "DINHLUONG",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_GIAOHANG_MaHoaDon",
                table: "GIAOHANG",
                column: "MaHoaDon",
                unique: true,
                filter: "[MaHoaDon] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaDiaChi_MaKhachHang",
                table: "HOADON",
                columns: new[] { "MaDiaChi", "MaKhachHang" });

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaKhachHang",
                table: "HOADON",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaKhuyenMai",
                table: "HOADON",
                column: "MaKhuyenMai");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_MaBoPhan",
                table: "NHANVIEN",
                column: "MaBoPhan");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUNHAP_MaNhaCungCap",
                table: "PHIEUNHAP",
                column: "MaNhaCungCap");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUNHAP_MaNhanVien",
                table: "PHIEUNHAP",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_MaHang",
                table: "SANPHAM",
                column: "MaHang");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_MaLoaiSanPham",
                table: "SANPHAM",
                column: "MaLoaiSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAMYEUTHICH_MaSanPham",
                table: "SANPHAMYEUTHICH",
                column: "MaSanPham");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BANNER");

            migrationBuilder.DropTable(
                name: "BINHLUANSANPHAM");

            migrationBuilder.DropTable(
                name: "CHITIETHOADON");

            migrationBuilder.DropTable(
                name: "CHITIETNHAPSANPHAM");

            migrationBuilder.DropTable(
                name: "DANHGIASANPHAM");

            migrationBuilder.DropTable(
                name: "DINHLUONG");

            migrationBuilder.DropTable(
                name: "LICHSUGIA");

            migrationBuilder.DropTable(
                name: "MAUMASANPHAM");

            migrationBuilder.DropTable(
                name: "SANPHAMYEUTHICH");

            migrationBuilder.DropTable(
                name: "TINHTRANGIAOHANG");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PHIEUNHAP");

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
                name: "DANHMUC");

            migrationBuilder.DropTable(
                name: "NHANHIEU");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "BOPHAN");

            migrationBuilder.DropTable(
                name: "DIACHIKHACHHANG");

            migrationBuilder.DropTable(
                name: "KHUYENMAI");

            migrationBuilder.DropTable(
                name: "KHACHHANG");
        }
    }
}
