using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class addAccountNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleterTime",
                table: "AspNetUsers",
                newName: "DeleteTime");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "837f7f56-fcbf-4029-b998-ad644f7faa13", "AQAAAAEAACcQAAAAEA2HehmF8AZ0xY5m1BAwQdtxqWIQF2N3Qk2ih1ZODCjAXjRkcOAudu5nqnsQ9tAyrg==" });

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "Id",
                keyValue: "DM001",
                column: "NgayTao",
                value: new DateTime(2021, 10, 19, 0, 16, 22, 642, DateTimeKind.Utc).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "Id",
                keyValue: "DM002",
                column: "NgayTao",
                value: new DateTime(2021, 10, 19, 0, 16, 22, 642, DateTimeKind.Utc).AddTicks(3173));

            migrationBuilder.UpdateData(
                table: "DANHMUC",
                keyColumn: "Id",
                keyValue: "DM003",
                column: "NgayTao",
                value: new DateTime(2021, 10, 19, 0, 16, 22, 642, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP001",
                column: "NgayTao",
                value: new DateTime(2021, 10, 19, 0, 16, 22, 643, DateTimeKind.Utc).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP002",
                column: "NgayTao",
                value: new DateTime(2021, 10, 19, 0, 16, 22, 643, DateTimeKind.Utc).AddTicks(3048));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "AspNetUsers",
                newName: "DeleterTime");

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
        }
    }
}
