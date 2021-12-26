using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class addcolumnforHUICost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaBan",
                table: "HUICosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "LuotTruyCap",
                table: "HUICosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "ThucBan",
                table: "HUICosts",
                type: "decimal",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Utility",
                table: "HUICosts");
            migrationBuilder.DropColumn(
                    name: "LuotTruyCap",
                    table: "HUICosts");
            migrationBuilder.DropColumn(
                    name: "ThucBan",
                    table: "HUICosts");
        }
    }
}
