using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class AspNetCoreIdentity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "CreateUserId", "DeleteUserId", "DeleterTime", "Email", "EmailConfirmed", "GioiTinh", "HoTen", "IsDeleted", "LastModificationTime", "LastModificationUserId", "LockoutEnabled", "LockoutEnd", "LoginString", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8d04dce2-969a-435d-bba4-df3f325983dc", 0, "6b62b005-d378-4d84-a492-d9b33883b464", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "yvonnetran.work@gmail.com", true, false, "Yvonne Tran", false, null, null, false, null, null, "yvonnetran.work@gmail.com", "admin", "AQAAAAEAACcQAAAAENUXu2THdXTLcpg9R8aMxLNWFYIqodfF5ytjGCLAYoJANvT3LX97xdoOpCKlSSjVlw==", null, false, "", 1, false, "admin" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles");

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumn: "UserId",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM001",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 6, 50, 29, 212, DateTimeKind.Utc).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM002",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 6, 50, 29, 212, DateTimeKind.Utc).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM003",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 6, 50, 29, 212, DateTimeKind.Utc).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP001",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 6, 50, 29, 213, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP002",
                column: "CreateDate",
                value: new DateTime(2021, 10, 10, 6, 50, 29, 213, DateTimeKind.Utc).AddTicks(6901));
        }
    }
}
