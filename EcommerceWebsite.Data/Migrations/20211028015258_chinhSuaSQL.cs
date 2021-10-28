using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class chinhSuaSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "NHANHIEU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "DANHMUC",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BANNER",
                columns: table => new
                {
                    MaBanner = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HinhAnhBanner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenBanner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANNER", x => x.MaBanner);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04052000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e422c961-a735-4c9c-9b1c-02777416ed76", "AQAAAAEAACcQAAAAEGge7h6Wh7YiXtNXAUAa26kYPXX2ywxuWG5o1+0OgmDyKbKFX3TFHdS9qHlXFuAk4w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92f222a2-aeaa-49ca-a533-6dc2ad25022e", "AQAAAAEAACcQAAAAEMnkAm4408fGyE+DmuLw48hY7AXBbGo4PHTc3ZBk9AOGrQR6fxNfeKzAcFdcBqduZA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7be6905-4fcb-4980-be84-b030668b04c8", "AQAAAAEAACcQAAAAEG90K5yyqcBhoaxQCIC+W9m2/6Pk0Ayxf1YjXDoS21XfJvo0D8/Vn2pyDKKT6G9j4A==" });

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM01",
                columns: new[] { "HinhAnh", "NgayTao" },
                values: new object[] { "", new DateTime(2021, 10, 28, 1, 52, 55, 884, DateTimeKind.Utc).AddTicks(4914) });

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM02",
                columns: new[] { "HinhAnh", "NgayTao" },
                values: new object[] { "https://i.ibb.co/hKbXPTb/56bd682737d0d355fe665d380783371c.jpg", new DateTime(2021, 10, 28, 1, 52, 55, 884, DateTimeKind.Utc).AddTicks(7012) });

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM03",
                columns: new[] { "HinhAnh", "NgayTao" },
                values: new object[] { "https://i.ibb.co/CmZS7bp/ng-h-th-ng-min.jpg", new DateTime(2021, 10, 28, 1, 52, 55, 884, DateTimeKind.Utc).AddTicks(7116) });

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM04",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 884, DateTimeKind.Utc).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "DIACHIKHACHHANG",
                keyColumns: new[] { "MaDiaChi", "MaKhachHang" },
                keyValues: new object[] { "DC01", "KH01" },
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 8, 52, 55, 949, DateTimeKind.Local).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "DIACHIKHACHHANG",
                keyColumns: new[] { "MaDiaChi", "MaKhachHang" },
                keyValues: new object[] { "DC02", "KH01" },
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 8, 52, 55, 949, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "NHANVIEN",
                keyColumn: "MaNhanVien",
                keyValue: "NV01",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 8, 52, 55, 948, DateTimeKind.Local).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "NHANVIEN",
                keyColumn: "MaNhanVien",
                keyValue: "NV02",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 8, 52, 55, 949, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "NHANVIEN",
                keyColumn: "MaNhanVien",
                keyValue: "NV03",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 8, 52, 55, 949, DateTimeKind.Local).AddTicks(4210));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP01",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP010",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP011",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP012",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP013",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP014",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP015",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP016",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP017",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP018",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP019",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP02",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP020",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP021",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP022",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP03",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP04",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP05",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP06",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP07",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP08",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP09",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 52, 55, 886, DateTimeKind.Utc).AddTicks(7393));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANNER");

            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "NHANHIEU");

            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "DANHMUC");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04052000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "026e1d8e-e416-498c-85ae-ed5ee72742e9", "AQAAAAEAACcQAAAAEB9rLByksIopYunzC7It6X+/h+9daSxn3jA3d1/+bwOdGIJC+2eIoU/Wsgyu6WwK+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94da1b44-3753-442b-a075-2fdaeab1caa0", "AQAAAAEAACcQAAAAELeFsQ5joFjq1Lslbcqk4cPshFWSS+X2qL9dR5E4/H9BYzAq4gpAGElG39Mn+BNfWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e36df0dd-058e-4f27-a727-e4234fc71ee9", "AQAAAAEAACcQAAAAEBdfZcRNV1eNiST03FHX6TU1sGHQMbp35+Z3BZFHk34hcMajQeEcTEZKslol5UUTZA==" });

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM01",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 0, DateTimeKind.Utc).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM02",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 0, DateTimeKind.Utc).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM03",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 0, DateTimeKind.Utc).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM04",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 0, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "DIACHIKHACHHANG",
                keyColumns: new[] { "MaDiaChi", "MaKhachHang" },
                keyValues: new object[] { "DC01", "KH01" },
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 8, 15, 0, 75, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "DIACHIKHACHHANG",
                keyColumns: new[] { "MaDiaChi", "MaKhachHang" },
                keyValues: new object[] { "DC02", "KH01" },
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 8, 15, 0, 75, DateTimeKind.Local).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "NHANVIEN",
                keyColumn: "MaNhanVien",
                keyValue: "NV01",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 8, 15, 0, 74, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "NHANVIEN",
                keyColumn: "MaNhanVien",
                keyValue: "NV02",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 8, 15, 0, 74, DateTimeKind.Local).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "NHANVIEN",
                keyColumn: "MaNhanVien",
                keyValue: "NV03",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 8, 15, 0, 74, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP01",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 2, DateTimeKind.Utc).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP010",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP011",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP012",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP013",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(929));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP014",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(957));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP015",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP016",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP017",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP018",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP019",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP02",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP020",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP021",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP022",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP03",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(840));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP04",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP05",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(855));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP06",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP07",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP08",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP09",
                column: "NgayTao",
                value: new DateTime(2021, 10, 28, 1, 15, 0, 3, DateTimeKind.Utc).AddTicks(898));
        }
    }
}
