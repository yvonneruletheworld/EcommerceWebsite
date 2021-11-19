using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class capNhat : Migration
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
                name: "BANNER",
                columns: table => new
                {
                    MaBanner = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HinhAnhBanner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANNER", x => x.MaBanner);
                    table.ForeignKey(
                        name: "FK_BANNER_KHUYENMAI_MaKhuyenMai",
                        column: x => x.MaKhuyenMai,
                        principalTable: "KHUYENMAI",
                        principalColumn: "MaKhuyenMai",
                        onDelete: ReferentialAction.Restrict);
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
                    MaDinhLuong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTri = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaThuocTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DINHLUONG", x => x.MaDinhLuong);
                    table.ForeignKey(
                        name: "FK_DINHLUONG_SANPHAM_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DINHLUONG_THUOCTINH_MaThuocTinh",
                        column: x => x.MaThuocTinh,
                        principalTable: "THUOCTINH",
                        principalColumn: "MaThuocTinh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MAUMASANPHAM",
                columns: table => new
                {
                    MaMauMa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenMauMa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAUMASANPHAM", x => x.MaMauMa);
                    table.ForeignKey(
                        name: "FK_MAUMASANPHAM_SANPHAM_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Restrict);
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
                name: "LICHSUGIA",
                columns: table => new
                {
                    MaLichSuGia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GiaMoi = table.Column<decimal>(type: "money", nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaDinhLuong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaMauMa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_LICHSUGIA", x => x.MaLichSuGia);
                    table.ForeignKey(
                        name: "FK_LICHSUGIA_DINHLUONG_MaDinhLuong",
                        column: x => x.MaDinhLuong,
                        principalTable: "DINHLUONG",
                        principalColumn: "MaDinhLuong",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LICHSUGIA_MAUMASANPHAM_MaMauMa",
                        column: x => x.MaMauMa,
                        principalTable: "MAUMASANPHAM",
                        principalColumn: "MaMauMa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LICHSUGIA_SANPHAM_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSanPham",
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
                    { "04052000", 0, null, "c3bb1c87-1ab5-4c6c-a0a1-11adfbc41cec", null, null, null, "ApplicationUser", "phamthivi459@gmail.com", true, null, null, false, null, null, false, null, null, "phamthivi459@gmail.com", "phamTVi0405", null, "AQAAAAEAACcQAAAAEP6nSMkSdohshf87cK7PtTOwGX2PmQQY5J6dgnMD9BInLuM7UL7HrVNKHnWDlSP9yQ==", "0376437459", false, "", 1, false, "phamTVi0405" },
                    { "8d04dce2-969a-435d-bba4-df3f325983dc", 0, null, "82bcc2cf-3035-4ef1-900b-287a2896b042", null, null, null, "ApplicationUser", "yvonnetran.work@gmail.com", true, null, null, false, null, null, false, null, null, "yvonnetran.work@gmail.com", "havyclient1", null, "AQAAAAEAACcQAAAAEKy9axqkn7DM1DDQdRmngixY8f1G/a53wMMdcyDFRfZ6gTbdw4+HmPWEhDO1b0hdcg==", "0905187524", false, "", 1, false, "havyclient1" },
                    { "123456789", 0, null, "0aa41cef-f45b-4dd9-b039-eaab3b242859", null, null, null, "ApplicationUser", "danhVu@gmail.com", true, null, null, false, null, null, false, null, null, "danhVu@gmail.com", "danhVu", null, "AQAAAAEAACcQAAAAEGLwLGqK3PcMk3KSZogeLl51b978hUIipB7K9vRfHhtN6wSLv8FjevX4W+9qXJbJjw==", "0376437459", false, "", 1, false, "danhVu" }
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
                    { "DM04", false, true, "https://i.ibb.co/QHfCkK1/28-11-2020-0-16065566805fc21c0855b09-0.jpg", null, new DateTime(2021, 11, 19, 13, 13, 11, 664, DateTimeKind.Utc).AddTicks(1261), null, null, "admin", null, "DM01", 1, "Phụ kiện" },
                    { "DM03", false, true, "https://i.ibb.co/3fWbd3c/Dong-ho-haylou-h3.jpg", null, new DateTime(2021, 11, 19, 13, 13, 11, 664, DateTimeKind.Utc).AddTicks(1320), null, null, "admin", null, "DM01", 1, "Đồng hồ" },
                    { "DM02", false, true, "https://i.ibb.co/sHxtWdf/Song-toi-gian-may-tinh-1.jpg", null, new DateTime(2021, 11, 19, 13, 13, 11, 664, DateTimeKind.Utc).AddTicks(1336), null, null, "admin", null, "DM01", 1, "PC, Máy in" },
                    { "DM01", false, true, "https://i.ibb.co/NSBhk4f/E5wft-Ni-Vk-AQHbh-S.jpg", null, new DateTime(2021, 11, 19, 13, 13, 11, 663, DateTimeKind.Utc).AddTicks(9886), null, null, "admin", null, null, 1, "Điện thoại" }
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
                    { "KM01", true, "https://cdn.tgdd.vn/2021/11/banner/830-300(1)-830x300.png", null, new DateTime(2021, 11, 19, 20, 13, 11, 709, DateTimeKind.Local).AddTicks(9782), null, null, null, null, 35f, "Đồng hồ thời trang giảm 35%" },
                    { "KM02", true, "https://cdn.tgdd.vn/2021/10/banner/830-300-830x300-29.png", null, new DateTime(2021, 11, 19, 20, 13, 11, 709, DateTimeKind.Local).AddTicks(9867), null, null, null, null, 15f, "Apple Watch S6 giảm đến 15%" },
                    { "KM03", true, "https://cdn.tgdd.vn/2021/11/banner/big11-pk-830-300-830x300.png", null, new DateTime(2021, 11, 19, 20, 13, 11, 709, DateTimeKind.Local).AddTicks(9875), null, null, null, null, 50f, "Phụ kiện giảm đến 50%" },
                    { "KM04", true, "https://cdn.tgdd.vn/2021/11/banner/830-300-830x300-6.png", null, new DateTime(2021, 11, 19, 20, 13, 11, 709, DateTimeKind.Local).AddTicks(9880), null, null, null, null, 25f, "Apple Watch S6 giảm đến 25%" }
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
                    { "NV01", false, "Quảng Ngãi", null, null, null, "phamthivi459@gmail.com", new DateTime(2000, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 19, 20, 13, 11, 708, DateTimeKind.Local).AddTicks(8968), null, null, null, null, "0376437459", 1, "Phạm Thị Vi", "PhamTVi" },
                    { "NV03", false, "Quảng Ngãi", null, null, null, "havy@gmail.com", new DateTime(2000, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 19, 20, 13, 11, 709, DateTimeKind.Local).AddTicks(3598), null, null, null, null, "123456789", 1, "Trần Nhật Hạ Vy", "haVy" },
                    { "NV02", false, "Quảng Ngãi", null, null, null, "danhvu@gmail.com", new DateTime(2000, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 19, 20, 13, 11, 709, DateTimeKind.Local).AddTicks(3563), null, null, null, null, "123456789", 1, "Lê Danh Vũ", "DanhVu" }
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
                    { "DC01", "KH01", true, "Hẻm 1 Bùi Xuân Phái, Tây Thạnh, Tân Phú, HCM", null, 0, false, null, new DateTime(2021, 11, 19, 20, 13, 11, 709, DateTimeKind.Local).AddTicks(7085), null, null, null, null, null, null, "0376437459", null, null },
                    { "DC02", "KH01", true, "140 Lê Trọng Tấn,", null, 0, false, null, new DateTime(2021, 11, 19, 20, 13, 11, 709, DateTimeKind.Local).AddTicks(7222), null, null, null, null, null, null, "0376437459", null, null }
                });

            migrationBuilder.InsertData(
                table: "SANPHAM",
                columns: new[] { "MaSanPham", "DaXoa", "HinhAnh", "MaHang", "MaLoaiSanPham", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa", "SoLuongTon", "Status", "TenSanPham", "Utility" },
                values: new object[,]
                {
                    { "SP019", false, "https://i.ibb.co/TLdWMdd/Vivo-v20-2021-xanh-hong-1-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4520), null, null, "admin", null, 1, 1, "Vivo V20 (2021)", 0m },
                    { "SP018", false, "https://i.ibb.co/S7Xy2TM/Vivo-v21-5g-tim-hong-1-3-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4516), null, null, "admin", null, 1, 1, "Vivo V21 5G", 0m },
                    { "SP017", false, "https://i.ibb.co/NrnVRWj/Vivo-x70-pro-black-gc-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4503), null, null, "admin", null, 1, 1, "Vivo X70 Pro 5G", 0m },
                    { "SP016", false, "https://i.ibb.co/XWGXkDf/Vivo-y21-1-2.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4500), null, null, "admin", null, 1, 1, "OPPO A16", 0m },
                    { "SP015", false, "https://i.ibb.co/vVV9xVR/Oppo-a16-1-2.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4496), null, null, "admin", null, 1, 1, "OPPO A16", 0m },
                    { "SP014", false, "https://i.ibb.co/94LDnqK/Oppo-reno4-pro-trang-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4492), null, null, "admin", null, 1, 1, "OPPO Reno4 Pro", 0m },
                    { "SP013", false, "https://i.ibb.co/55BgPLp/Oppo-reno5-5g-bac-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4489), null, null, "admin", null, 1, 1, "OPPO Reno5 5G", 0m },
                    { "SP012", false, "https://i.ibb.co/zbPGb0s/Oppo-reno6-den-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4486), null, null, "admin", null, 1, 1, "OPPO Reno6 5G", 0m },
                    { "SP011", false, "https://i.ibb.co/pw2Kqcp/Oppo-find-x3-pro-den-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4479), null, null, "admin", null, 1, 1, "OPPO Find X3 Pro 5G", 0m },
                    { "SP010", false, "https://i.ibb.co/ydCdghQ/Oppo-reno6-pro-5g-xanh-duong-1.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4475), null, null, "admin", null, 1, 1, "OPPO Reno6 Pro 5G", 0m },
                    { "SP09", false, "https://i.ibb.co/zRQB86R/Oppo-a74-xanh-duong-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4471), null, null, "admin", null, 1, 1, "OPPO A74", 0m },
                    { "SP08", false, "https://i.ibb.co/1rp5mbM/Oppo-reno6-z-5g-bac-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4468), null, null, "admin", null, 1, 1, "OPPO Reno6 Z 5G", 0m },
                    { "SP026", false, "https://i.ibb.co/ydJ9XY5/Samsung-galaxy-watch-4-44mm-den-1-org.jpg", "MH02", "DM03", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4546), null, null, "admin", null, 1, 1, "Samsung Galaxy Watch 4 44mm ", 0m },
                    { "SP025", false, "https://i.ibb.co/9yR299t/Samsung-galaxy-watch-3-45mm-bac-2-org.jpg", "MH02", "DM03", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4543), null, null, "admin", null, 1, 1, "Samsung Galaxy Watch 3 45mm viền thép bạc dây da", 0m },
                    { "SP022", false, "https://i.ibb.co/k5rV9Vg/Samsung-galaxy-watch-4-44mm-den-1-org.jpg", "MH02", "DM03", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4533), null, null, "admin", null, 1, 1, "Samsung Galaxy Watch 4 44mm", 0m },
                    { "SP02", false, "https://i.ibb.co/CPq556s/Samsung-galaxy-z-flip-3-kem-1-org.jpg", "MH02", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4405), null, null, "admin", null, 1, 1, "Samsung Galaxy Z Flip3 5G 128GB", 0m },
                    { "SP01", false, "https://i.ibb.co/T2Ywg8N/Samsung-galaxy-z-fold-3-silver-gc-org.jpg", "MH02", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(3542), null, null, "admin", null, 1, 1, "Samsung Galaxy Z Fold3 5G 512GB", 0m },
                    { "SP028", false, "https://i.ibb.co/ZW5Wqpk/Apple-watch-s7-45mm-gps-do-1.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4556), null, null, "admin", null, 1, 1, "Apple Watch Series 7 GPS 45mm ", 0m },
                    { "SP027", false, "https://i.ibb.co/2YttfZB/Apple-watch-s6-lte-40mm-vien-thep-day-thep-vang-cont-1-org.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4551), null, null, "admin", null, 1, 1, "Apple Watch S6 LTE 40mm viền thép dây thép ", 0m },
                    { "SP024", false, "https://i.ibb.co/rcfS9Nm/Untitled-1-org.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4539), null, null, "admin", null, 1, 1, "Apple Watch SE 40mm viền nhôm dây cao su", 0m },
                    { "SP023", false, "https://i.ibb.co/bHRpNch/Apple-watch-s6-40mm-vien-nhom-day-cao-su-xanh-cont-1-org.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4536), null, null, "admin", null, 1, 1, "Apple Watch S6 40mm viền nhôm dây cao su", 0m },
                    { "SP07", false, "https://i.ibb.co/2v36jLV/iphone-XR-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4464), null, null, "admin", null, 1, 1, "iPhone XR 64GB", 0m },
                    { "SP06", false, "https://i.ibb.co/hZS5MJ3/Iphone-11-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4461), null, null, "admin", null, 1, 1, "iPhone 11 64GB", 0m },
                    { "SP05", false, "https://i.ibb.co/vsLZ8km/Iphone-12-mini-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4457), null, null, "admin", null, 1, 1, "iPhone 12 mini 64GB", 0m },
                    { "SP04", false, "https://i.ibb.co/JQNGCzb/Iphone-12-pro-max-128-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4453), null, null, "admin", null, 1, 1, "iPhone 12 Pro Max 128GB", 0m },
                    { "SP03", false, "https://i.ibb.co/RNz8N1G/Iphone-12-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4440), null, null, "admin", null, 1, 1, "iPhone 12 64GB", 0m },
                    { "SP020", false, "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4526), null, null, "admin", null, 1, 1, "Vivo Y72 5G", 0m },
                    { "SP021", false, "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 19, 13, 13, 11, 665, DateTimeKind.Utc).AddTicks(4529), null, null, "admin", null, 1, 1, "Vivo Y21s 6GB", 0m }
                });

            migrationBuilder.InsertData(
                table: "MAUMASANPHAM",
                columns: new[] { "MaMauMa", "HinhAnh", "MaSanPham", "TenMauMa" },
                values: new object[,]
                {
                    { "MM07", "https://i.ibb.co/0qYwZ5c/Iphone-12-64-GB-en.jpg", "SP03", "Đen" },
                    { "MM036", "https://i.ibb.co/yVs3g8T/Oppo-reno6-pro-5g-xam-1.jpg", "SP010", "Xám" },
                    { "MM035", "https://i.ibb.co/jJ1XBWq/Oppo-reno6-pro-5g-xanh-duong-1.jpg", "SP010", "Xanh dương" },
                    { "MM034", "https://i.ibb.co/M5Mk64X/Oppo-a74-den-5-org.jpg", "SP09", "Đen" },
                    { "MM033", "https://i.ibb.co/zRQB86R/Oppo-a74-xanh-duong-1-org.jpg", "SP09", "Xanh dương" },
                    { "MM032", "https://i.ibb.co/KXWZfKL/Oppo-reno6-z-5g-den-1-org.jpg", "SP08", "Đen" },
                    { "MM031", "https://i.ibb.co/MNpLvHY/Oppo-reno6-z-5g-bac-1-org.jpg", "SP08", "Bạc" },
                    { "MM068", "https://i.ibb.co/XVM9Mxj/Samsung-galaxy-watch-4-44mm-bac-1-org.jpg", "SP026", "Bạc" },
                    { "MM067", "https://i.ibb.co/s2mSnhK/Samsung-galaxy-watch-4-44mm-1-1.jpg", "SP026", "Xanh lá" },
                    { "MM066", "https://i.ibb.co/ydJ9XY5/Samsung-galaxy-watch-4-44mm-den-1-org.jpg", "SP026", "Đen" },
                    { "MM065", "https://i.ibb.co/9yR299t/Samsung-galaxy-watch-3-45mm-bac-2-org.jpg", "SP025", "Bạc" },
                    { "MM06", "https://i.ibb.co/9WvYqLR/Samsung-galaxy-z-fold3-5g-1.jpg", "SP02", "Xanh riêu" },
                    { "MM05", "https://i.ibb.co/0tXPPWn/Samsung-galaxy-z-flip-3-black-gc-org.jpg", "SP02", "Đen" },
                    { "MM04", "https://i.ibb.co/CPq556s/Samsung-galaxy-z-flip-3-kem-1-org.jpg", "SP02", "Kem" },
                    { "MM03", "https://i.ibb.co/qyCNcw6/Samsung-galaxy-z-fold-3-1-org.jpg", "SP01", "Đen" },
                    { "MM02", "https://i.ibb.co/T2Ywg8N/Samsung-galaxy-z-fold-3-silver-gc-org.jpg", "SP01", "Bạc" },
                    { "MM037", "https://i.ibb.co/pw2Kqcp/Oppo-find-x3-pro-den-1-org.jpg", "SP011", "Đen" },
                    { "MM01", "https://i.ibb.co/9WvYqLR/Samsung-galaxy-z-fold3-5g-1.jpg", "SP01", "Xanh riêu" },
                    { "MM038", "https://i.ibb.co/Rp3jcB3/Oppo-find-x3-pro-xanh-1-org.jpg", "SP011", "Xanh đen" },
                    { "MM040", "https://i.ibb.co/zbPGb0s/Oppo-reno6-den-1-org.jpg", "SP012", "Đen" },
                    { "MM055", "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg", "SP020", "Xanh hồng" },
                    { "MM054", "https://i.ibb.co/mCbyxk9/Vivo-y72-5g-den-1-org.jpg", "SP020", "Đen" },
                    { "MM053", "https://i.ibb.co/TLdWMdd/Vivo-v20-2021-xanh-hong-1-org.jpg", "SP019", "Xanh hồng" },
                    { "MM052", "https://i.ibb.co/tcNjPQL/Vivo-v20-2021-den-1-org.jpg", "SP019", "Đen" },
                    { "MM051", "https://i.ibb.co/wwT6MVD/Vivo-v21-5g-xanh-den-1-org.jpg", "SP018", "Đen" },
                    { "MM050", "https://i.ibb.co/S7Xy2TM/Vivo-v21-5g-tim-hong-1-3-org.jpg", "SP018", "Tím hồng" },
                    { "MM049", "https://i.ibb.co/NrnVRWj/Vivo-x70-pro-black-gc-org.jpg", "SP017", "Đen" },
                    { "MM048", "https://i.ibb.co/TcQYYxs/Vivo-x70-pro-xanh-1-1.jpg", "SP017", "Xanh hồng" },
                    { "MM047", "https://i.ibb.co/XYj2R7d/Vivo-y21-blue-gc-1-org.jpg", "SP016", "Xanh tím" },
                    { "MM046", "https://i.ibb.co/XWGXkDf/Vivo-y21-1-2.jpg", "SP016", "Trắng" },
                    { "MM045", "https://i.ibb.co/vVV9xVR/Oppo-a16-1-2.jpg", "SP015", "Bạc" },
                    { "MM044", "https://i.ibb.co/RBQ3zwg/Oppo-reno4-pro-den-1-org.jpg", "SP014", "Đen" },
                    { "MM043", "https://i.ibb.co/94LDnqK/Oppo-reno4-pro-trang-1-org.jpg", "SP014", "Trắng" },
                    { "MM042", "https://i.ibb.co/MhHDY3L/Oppo-reno5-5g-den-org.jpg", "SP013", "Đen" },
                    { "MM041", "https://i.ibb.co/55BgPLp/Oppo-reno5-5g-bac-1-org.jpg", "SP013", "Bạc" },
                    { "MM039", "https://i.ibb.co/7YG6TFH/Oppo-reno6-bac-1-org.jpg", "SP012", "Bạc" },
                    { "MM056", "https://i.ibb.co/Yd1wV4H/Vivo-y21s-trang-1-1.jpg", "SP021", "Trắng" },
                    { "MM075", "ttps://i.ibb.co/V9d5FLq/apple-watch-s7-45mm-gps-xanh-la-1.jpg", "SP028", "Xanh Lá" },
                    { "MM073", "https://i.ibb.co/ZW5Wqpk/Apple-watch-s7-45mm-gps-do-1.jpg", "SP028", "Đỏ" },
                    { "MM022", "https://i.ibb.co/WBH28Zh/Iphone-11-do-1-1-1-org.jpg", "SP06", "Đỏ" },
                    { "MM021", "https://i.ibb.co/0stYCyp/Iphone-11-den-1-1-1-org.jpg", "SP05", "Đen" },
                    { "MM020", "https://i.ibb.co/Np97nN6/Iphone-12-mini-xanh-duong-1-1-org.jpg", "SP05", "Xanh dương" }
                });

            migrationBuilder.InsertData(
                table: "MAUMASANPHAM",
                columns: new[] { "MaMauMa", "HinhAnh", "MaSanPham", "TenMauMa" },
                values: new object[,]
                {
                    { "MM019", "https://i.ibb.co/5LRj1Wh/Iphone-12-mini-trang-1-1-org.jpg", "SP05", "Trắng" },
                    { "MM018", "https://i.ibb.co/30KH8b2/Iphone-12-mini-tim-gc-1-org.jpg", "SP05", "Tím" },
                    { "MM017", "https://i.ibb.co/jkmt501/Iphone-12-mini-1-1-org.jpg", "SP05", "Đỏ" },
                    { "MM016", "https://i.ibb.co/crZFrkD/Iphone-12-mini-den-1-1-org.jpg", "SP05", "Hologram" },
                    { "MM015", "https://i.ibb.co/5LvRhJ4/Iphone-12-pro-max-xanh-duong-1-org.jpg", "SP04", "Xanh" },
                    { "MM014", "https://i.ibb.co/JQNGCzb/Iphone-12-pro-max-128-GB.jpg", "SP04", "Vàng" },
                    { "MM013", "https://i.ibb.co/pW2nvth/Iphone-12-pro-max-bac-1-org.jpg", "SP04", "Bạc" },
                    { "MM012", "https://i.ibb.co/D5Xg9sQ/Iphone-12-64-GB-Xanh-l.jpg", "SP03", "Xanh lá" },
                    { "MM011", "https://i.ibb.co/6XtyJbM/Iphone-12-64-GB-Xanh.jpg", "SP03", "Xanh" },
                    { "MM010", "https://i.ibb.co/vsLZ8km/Iphone-12-mini-64-GB.jpg", "SP03", "Trắng" },
                    { "MM09", "https://i.ibb.co/GC6Tdwd/Iphone-12-64-GB-T-m.jpg", "SP03", "Tím" },
                    { "MM08", "https://i.ibb.co/RNz8N1G/Iphone-12-64-GB.jpg", "SP03", "Đỏ" },
                    { "MM023", "https://i.ibb.co/Lnt4WzS/Iphone-11-tim-1-1-1-org.jpg", "SP06", "Tím" },
                    { "MM074", "https://i.ibb.co/Qjbqcqf/Apple-watch-s7-45mm-gps-xanh-duong-1.jpg", "SP028", "Xanh Dương" },
                    { "MM024", "https://i.ibb.co/pLyJDFG/Iphone-11-trang-1-2-org.jpg", "SP06", "Trắng" },
                    { "MM026", "https://i.ibb.co/hZS5MJ3/Iphone-11-64-GB.jpg", "SP06", "Xanh lá" },
                    { "MM072", "https://i.ibb.co/BrWrjZh/Apple-watch-s7-45mm-gps-vang-1.jp", "SP028", "Vàng" },
                    { "MM071", "https://i.ibb.co/mDSQcPD/Apple-watch-s7-45mm-gps-den-1.jpg", "SP028", "Đen" },
                    { "MM070", "https://i.ibb.co/JH2Fshs/Apple-watch-s6-lte-40mm-vien-thep-day-thep-den-cont-1-org.jpg", "SP027", "Đen" },
                    { "MM069", "https://i.ibb.co/2YttfZB/Apple-watch-s6-lte-40mm-vien-thep-day-thep-vang-cont-1-org.jpg", "SP027", "vàng" },
                    { "MM064", "https://i.ibb.co/3dBt9bj/Se-40mm-vien-nhom-day-cao-su-hong-glr-1-org.jpg", "SP024", "Đen" },
                    { "MM063", "https://i.ibb.co/rcfS9Nm/Untitled-1-org.jpg", "SP024", "Hồng" },
                    { "MM062", "https://i.ibb.co/4TQV8yv/Apple-watch-s6-40mm-vien-nhom-day-cao-su-red-do-cont-1-org-org.jp", "SP023", "Đỏ" },
                    { "MM061", "https://i.ibb.co/sPCkGSb/Apple-watch-s6-40mm-vien-nhom-day-cao-su-den-cont-1-org.jpg", "SP023", "Đen" },
                    { "MM060", "https://i.ibb.co/vV2zr9s/Apple-watch-s6-40mm-vien-nhom-day-cao-su-trang-cont-1-org.jpg", "SP023", "Trắng" },
                    { "MM059", "https://i.ibb.co/bHRpNch/Apple-watch-s6-40mm-vien-nhom-day-cao-su-xanh-cont-1-org.jpg", "SP023", "Xanh dương đậm" },
                    { "MM058", "https://i.ibb.co/whQPQYR/Apple-watch-s6-40mm-vien-nhom-day-cao-su-hong-cont-1-org.jpg", "SP023", "Hồng" },
                    { "MM030", "https://i.ibb.co/2v36jLV/iphone-XR-64-GB.jpg", "SP07", "Xanh" },
                    { "MM029", "https://i.ibb.co/6y40G5v/20210416-6cec022bdb9abc311894b08e71bd0769-1618550179.jpg", "SP07", "Vàng" },
                    { "MM028", "https://i.ibb.co/yWZQJPt/Iphone-XR-en.jpg", "SP07", "Đen" },
                    { "MM027", "https://i.ibb.co/8d4VJxn/mo-hop-iphone-xr-ban-mau-cam.jpg", "SP07", "Cam" },
                    { "MM025", "https://i.ibb.co/26xpZH9/Iphone-11-vang-1-2-org.jpg", "SP06", "Vàng" },
                    { "MM057", "https://i.ibb.co/5hkXcM1/Vivo-y21s-blue-gc-org.jpg", "SP021", "Xanh" }
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
                name: "IX_BANNER_MaKhuyenMai",
                table: "BANNER",
                column: "MaKhuyenMai");

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
                name: "IX_DINHLUONG_MaThuocTinh",
                table: "DINHLUONG",
                column: "MaThuocTinh");

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
                name: "IX_LICHSUGIA_MaDinhLuong",
                table: "LICHSUGIA",
                column: "MaDinhLuong");

            migrationBuilder.CreateIndex(
                name: "IX_LICHSUGIA_MaMauMa",
                table: "LICHSUGIA",
                column: "MaMauMa");

            migrationBuilder.CreateIndex(
                name: "IX_LICHSUGIA_MaSanPham",
                table: "LICHSUGIA",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_MAUMASANPHAM_MaSanPham",
                table: "MAUMASANPHAM",
                column: "MaSanPham");

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
                name: "LICHSUGIA");

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
                name: "DINHLUONG");

            migrationBuilder.DropTable(
                name: "MAUMASANPHAM");

            migrationBuilder.DropTable(
                name: "GIAOHANG");

            migrationBuilder.DropTable(
                name: "NHACUNGCAP");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "THUOCTINH");

            migrationBuilder.DropTable(
                name: "SANPHAM");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "BOPHAN");

            migrationBuilder.DropTable(
                name: "DANHMUC");

            migrationBuilder.DropTable(
                name: "NHANHIEU");

            migrationBuilder.DropTable(
                name: "DIACHIKHACHHANG");

            migrationBuilder.DropTable(
                name: "KHUYENMAI");

            migrationBuilder.DropTable(
                name: "KHACHHANG");
        }
    }
}
