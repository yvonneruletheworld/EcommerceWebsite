using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class KhachHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Utility",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    LoginString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TongCong = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    ThanhTien = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    TinhTrang = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    HoaDonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => new { x.HoaDonId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "DeleteUserId", "DeleterTime", "IsDeleted", "IsShowInHome", "LastModificationTime", "LastModificationUserId", "Name", "ParentId", "Status" },
                values: new object[,]
                {
                    { "DM001", new DateTime(2021, 10, 9, 18, 53, 33, 643, DateTimeKind.Utc).AddTicks(4000), "admin", null, null, false, true, null, null, "Điện thoại", null, 1 },
                    { "DM002", new DateTime(2021, 10, 9, 18, 53, 33, 643, DateTimeKind.Utc).AddTicks(4822), "admin", null, null, false, true, null, null, "iPhone", "DM001", 1 },
                    { "DM003", new DateTime(2021, 10, 9, 18, 53, 33, 643, DateTimeKind.Utc).AddTicks(4867), "admin", null, null, false, true, null, null, "Samsung", "DM001", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Const", "CreateDate", "CreateUserId", "DeleteUserId", "DeleterTime", "Description", "IsDeleted", "LastModificationTime", "LastModificationUserId", "Name", "Price", "Status", "Stock", "Utility" },
                values: new object[,]
                {
                    { "SP001", "Samsung", 43990000m, new DateTime(2021, 10, 9, 18, 53, 33, 644, DateTimeKind.Utc).AddTicks(4363), "admin", null, null, " Z Fold 3 đi kèm với bút S Pen được thiết kế đặc thù, trang bị kính Victus Corning Gorilla Glass và khung điện thoại Armor Frame, cho độ bền tốt hơn. Fold mới sẽ có hai màn hình Dynamic AMOLED 2X, tốc độ làm mới 120 Hz với kích thước 6.28 inch", false, null, null, "Samsung Galaxy Z Fold3 5G 512GB", 44990000m, 1, 1, 0m },
                    { "SP002", "Samsung", 23990000m, new DateTime(2021, 10, 9, 18, 53, 33, 644, DateTimeKind.Utc).AddTicks(4972), "admin", null, null, " Biểu tượng thời trang độc đáo nằm gọn trong túi khi gập cho bạn thỏa sức tham gia các hoạt động yêu thích ở bất cứ nơi đâu. Siêu phẩm công nghệ khi mở để bạn đắm chìm trải nghiệm với tốc độ mạng 5G và khả năng gập ở nhiều góc độ linh hoạt chưa từng có.1 Không chỉ là điện thoại,đó là một ngôn ngữ thời trang cá tính", false, null, null, "Samsung Galaxy Z Flip3 5G 128GB", 24990000m, 1, 1, 0m }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { "DM003", "SP001" });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { "DM003", "SP002" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_ProductId",
                table: "ChiTietHoaDon",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKhachHang",
                table: "HoaDon",
                column: "MaKhachHang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM001");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM002");

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { "DM003", "SP001" });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { "DM003", "SP002" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DM003");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP001");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP002");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Utility",
                table: "Products");
        }
    }
}
