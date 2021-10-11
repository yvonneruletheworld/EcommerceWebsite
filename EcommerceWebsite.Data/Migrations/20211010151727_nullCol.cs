using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class nullCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd10b35a-fba2-43e3-93a7-a509ddaa531a", "AQAAAAEAACcQAAAAEDccPDwZ5IxgaNr3ttjIA8mvGEFp+LqtiGbZP3Y5A4RFPnOYELbHknseRWBdM928YA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM001",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 17, 26, 754, DateTimeKind.Utc).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM002",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 17, 26, 754, DateTimeKind.Utc).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM003",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 17, 26, 754, DateTimeKind.Utc).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP001",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 17, 26, 755, DateTimeKind.Utc).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP002",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 15, 17, 26, 755, DateTimeKind.Utc).AddTicks(7762));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b62b005-d378-4d84-a492-d9b33883b464", "AQAAAAEAACcQAAAAENUXu2THdXTLcpg9R8aMxLNWFYIqodfF5ytjGCLAYoJANvT3LX97xdoOpCKlSSjVlw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM001",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 7, 20, 35, 752, DateTimeKind.Utc).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM002",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 7, 20, 35, 753, DateTimeKind.Utc).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM003",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 7, 20, 35, 753, DateTimeKind.Utc).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP001",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 7, 20, 35, 754, DateTimeKind.Utc).AddTicks(2347));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP002",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 7, 20, 35, 754, DateTimeKind.Utc).AddTicks(3021));
        }
    }
}
