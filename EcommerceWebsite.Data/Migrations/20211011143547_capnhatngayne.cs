using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class capnhatngayne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
               name: "NgayGiao",
               table: "GIAOHANG",
               type: "DateTime",
               nullable: true,
               oldClrType: typeof(DateTime),
               oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayGiao",
                table: "GIAOHANG",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }
    }
}
