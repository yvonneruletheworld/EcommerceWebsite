using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class AltertableDanhMuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_LOAISANPHAM_MaLoaiSanPham",
                table: "SANPHAM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LOAISANPHAM",
                table: "LOAISANPHAM");

            migrationBuilder.RenameTable(
                name: "LOAISANPHAM",
                newName: "DANHMUC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DANHMUC",
                table: "DANHMUC",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd4c6b2b-4283-4738-881f-93e23b80944e", "AQAAAAEAACcQAAAAEGcL2cbnh9MT3g7Dn7JmQcGVmR79mxPSeT3tiBdovhSi9fuhzzR7di5AvPOQOZ/MwA==" });

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "Id",
                keyValue: "DM001",
                column: "NgayTao",
                value: new DateTime(2021, 10, 15, 23, 46, 22, 82, DateTimeKind.Utc).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "Id",
                keyValue: "DM002",
                column: "NgayTao",
                value: new DateTime(2021, 10, 15, 23, 46, 22, 82, DateTimeKind.Utc).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "Id",
                keyValue: "DM003",
                column: "NgayTao",
                value: new DateTime(2021, 10, 15, 23, 46, 22, 82, DateTimeKind.Utc).AddTicks(6492));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP001",
                column: "NgayTao",
                value: new DateTime(2021, 10, 15, 23, 46, 22, 83, DateTimeKind.Utc).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP002",
                column: "NgayTao",
                value: new DateTime(2021, 10, 15, 23, 46, 22, 83, DateTimeKind.Utc).AddTicks(7009));

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_DANHMUC_MaLoaiSanPham",
                table: "SANPHAM",
                column: "MaLoaiSanPham",
                principalTable: "DANHMUC",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_DANHMUC_MaLoaiSanPham",
                table: "SANPHAM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DANHMUC",
                table: "DANHMUC");

            migrationBuilder.RenameTable(
                name: "DANHMUC",
                newName: "LOAISANPHAM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LOAISANPHAM",
                table: "LOAISANPHAM",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54606f2e-02b4-498a-82fc-2c8aa05efae4", "AQAAAAEAACcQAAAAEJXP5ngUm1UvaOHLW3dn4KDIPxz43zHllX1v+l8HUKA3YuBkLLTL5QnldNfUW0UQCg==" });

            migrationBuilder.UpdateData(
                table: "LOAISANPHAM",
                keyColumn: "Id",
                keyValue: "DM001",
                column: "NgayTao",
                value: new DateTime(2021, 10, 15, 23, 42, 19, 720, DateTimeKind.Utc).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "LOAISANPHAM",
                keyColumn: "Id",
                keyValue: "DM002",
                column: "NgayTao",
                value: new DateTime(2021, 10, 15, 23, 42, 19, 720, DateTimeKind.Utc).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "LOAISANPHAM",
                keyColumn: "Id",
                keyValue: "DM003",
                column: "NgayTao",
                value: new DateTime(2021, 10, 15, 23, 42, 19, 720, DateTimeKind.Utc).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP001",
                column: "NgayTao",
                value: new DateTime(2021, 10, 15, 23, 42, 19, 721, DateTimeKind.Utc).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP002",
                column: "NgayTao",
                value: new DateTime(2021, 10, 15, 23, 42, 19, 721, DateTimeKind.Utc).AddTicks(2823));

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_LOAISANPHAM_MaLoaiSanPham",
                table: "SANPHAM",
                column: "MaLoaiSanPham",
                principalTable: "LOAISANPHAM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
