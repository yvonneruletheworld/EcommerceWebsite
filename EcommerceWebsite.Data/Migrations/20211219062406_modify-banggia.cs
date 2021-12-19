using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class modifybanggia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "BANGGIASANPHAM",
                columns: table => new
                {
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaDinhLuong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_BANGGIASANPHAM", x => new { x.MaDinhLuong, x.NgayTao });
                    table.ForeignKey(
                        name: "FK_BANGGIASANPHAM_DINHLUONG_MaDinhLuong",
                        column: x => x.MaDinhLuong,
                        principalTable: "DINHLUONG",
                        principalColumn: "MaDinhLuong",
                        onDelete: ReferentialAction.Cascade);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "BANGGIASANPHAM");
        }
    }
}
