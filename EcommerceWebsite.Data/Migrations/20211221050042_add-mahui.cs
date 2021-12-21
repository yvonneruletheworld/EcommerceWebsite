using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class addmahui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CHITIETHOADON",
                table: "CHITIETHOADON");

            migrationBuilder.AddColumn<string>(
                name: "MaHUI",
                table: "CHITIETHOADON",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CHITIETHOADON",
                table: "CHITIETHOADON",
                columns: new[] { "ProductId", "HoaDonId", "MaHUI" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CHITIETHOADON",
                table: "CHITIETHOADON");

            migrationBuilder.DropColumn(
                name: "MaHUI",
                table: "CHITIETHOADON");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CHITIETHOADON",
                table: "CHITIETHOADON",
                columns: new[] { "ProductId", "HoaDonId" });

        }
    }
}
