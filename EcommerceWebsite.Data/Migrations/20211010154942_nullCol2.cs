using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class nullCol2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HoTen",
                table: "KhachHang",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Categories",
                type: "int",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a090112d-9d71-4303-9251-5a7b810ade41", "AQAAAAEAACcQAAAAEJjYyaT3wzH1DCMj14sCzsH7NdbcbjUcRQ8KvaRPpnD0Um0GUIkuT8XwdO5Hxcid5Q==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM001",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 49, 41, 734, DateTimeKind.Utc).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM002",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 49, 41, 734, DateTimeKind.Utc).AddTicks(3961));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM003",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 49, 41, 734, DateTimeKind.Utc).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP001",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 49, 41, 735, DateTimeKind.Utc).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP002",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 49, 41, 735, DateTimeKind.Utc).AddTicks(4290));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HoTen",
                table: "KhachHang",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ab8a2348-221d-42f8-9880-686ea0de42f2", "AQAAAAEAACcQAAAAEOOrFwGgp0/CA/Wgumo9WhLnttJS2kZa32b5ERhw5s3KiPrMpzeyq8S/sXxbUYl0nA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM001",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 22, 26, 487, DateTimeKind.Utc).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM002",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 22, 26, 487, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM003",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 22, 26, 487, DateTimeKind.Utc).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP001",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 22, 26, 488, DateTimeKind.Utc).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP002",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 22, 26, 488, DateTimeKind.Utc).AddTicks(6727));
        }
    }
}
