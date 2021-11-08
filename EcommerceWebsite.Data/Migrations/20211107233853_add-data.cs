using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountNumber", "ConcurrencyStamp", "CreateUserId", "DeleteTime", "DeleteUserId", "Discriminator", "Email", "EmailConfirmed", "IdAuto", "Ip", "IsDeleted", "LastModificationTime", "LastModificationUserId", "LockoutEnabled", "LockoutEnd", "LoginString", "NormalizedEmail", "NormalizedUserName", "OTPCode", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04052000", 0, null, "4e79af42-f9db-482a-869a-621eb0076e44", null, null, null, "ApplicationUser", "phamthivi459@gmail.com", true, null, null, false, null, null, false, null, null, "phamthivi459@gmail.com", "phamTVi0405", null, "AQAAAAEAACcQAAAAEPw7W5U0Fx+l4y+GH+pHH99ec1dPzZ0B5UjvpbQ24Ev5jJDKeKoeoyKfxlO+Ky6Qgg==", "0376437459", false, "", 1, false, "phamTVi0405" },
                    { "8d04dce2-969a-435d-bba4-df3f325983dc", 0, null, "9f73acf0-81db-416b-99c8-fe10954c1426", null, null, null, "ApplicationUser", "yvonnetran.work@gmail.com", true, null, null, false, null, null, false, null, null, "yvonnetran.work@gmail.com", "havyclient1", null, "AQAAAAEAACcQAAAAEP7vjqSppv2kqI4Rjrm90PJI0wYdfxnowoSxS58aHVe7NBvr7xL7Hcw0MvElzBPINA==", "0905187524", false, "", 1, false, "havyclient1" },
                    { "123456789", 0, null, "97841e85-6b4a-4bf7-9994-f202bac7af40", null, null, null, "ApplicationUser", "danhVu@gmail.com", true, null, null, false, null, null, false, null, null, "danhVu@gmail.com", "danhVu", null, "AQAAAAEAACcQAAAAELeWAl37ABdWrhrVhNkkS/gJ3UAbxIq1PDVean5lgeZM9UUAbwjlm7v2RZE8ePDGtA==", "0376437459", false, "", 1, false, "danhVu" }
                });

            migrationBuilder.InsertData(
                table: "BOPHAN",
                columns: new[] { "MaBoPhan", "TenBoPhan" },
                values: new object[,]
                {
                    { "BP01", "Thu ngân" },
                    { "BP02", "Nhân viên bán hàng" },
                    { "BP03", "Nhân viên Kho" },
                    { "BP04", "Nhân viên kĩ thuật" }
                });

            migrationBuilder.InsertData(
                table: "DANHMUC",
                columns: new[] { "MaDanhMuc", "DaXoa", "HienThiTrangHome", "HinhAnh", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa", "ParentId", "Status", "TenDanhMuc" },
                values: new object[,]
                {
                    { "DM04", false, true, "https://i.ibb.co/QHfCkK1/28-11-2020-0-16065566805fc21c0855b09-0.jpg", null, new DateTime(2021, 11, 7, 23, 38, 52, 412, DateTimeKind.Utc).AddTicks(7203), null, null, "admin", null, "DM01", 1, "Phụ kiện" },
                    { "DM03", false, true, "https://i.ibb.co/3fWbd3c/Dong-ho-haylou-h3.jpg", null, new DateTime(2021, 11, 7, 23, 38, 52, 412, DateTimeKind.Utc).AddTicks(7619), null, null, "admin", null, "DM01", 1, "Đồng hồ" },
                    { "DM02", false, true, "https://i.ibb.co/sHxtWdf/Song-toi-gian-may-tinh-1.jpg", null, new DateTime(2021, 11, 7, 23, 38, 52, 412, DateTimeKind.Utc).AddTicks(7624), null, null, "admin", null, "DM01", 1, "PC, Máy in" },
                    { "DM01", false, true, "https://i.ibb.co/NSBhk4f/E5wft-Ni-Vk-AQHbh-S.jpg", null, new DateTime(2021, 11, 7, 23, 38, 52, 412, DateTimeKind.Utc).AddTicks(6215), null, null, "admin", null, null, 1, "Điện thoại" }
                });

            migrationBuilder.InsertData(
                table: "KHACHHANG",
                columns: new[] { "MaKhachHang", "DaXoa", "GioiTinh", "HinhAnh", "HoTen", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa" },
                values: new object[,]
                {
                    { "8d04dce2-969a-435d-bba4-df3f325983dc", false, false, null, "Yvonne Tran", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { "KH01", false, false, null, "Phạm Thị Vi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { "KH02", false, false, null, "Danh Vũ", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "NHANHIEU",
                columns: new[] { "MaHang", "HinhAnh", "TenHang" },
                values: new object[,]
                {
                    { "MH08", null, "NOKIA" },
                    { "MH07", null, "VSMAST" },
                    { "MH09", null, "HYDRUS" },
                    { "MH05", null, "XIAOMI" },
                    { "MH04", null, "VIVO" },
                    { "MH01", null, "IPHONE" },
                    { "MH02", null, "SAMSUNG" },
                    { "MH03", null, "OPPO" },
                    { "MH06", null, "REALME" }
                });

            migrationBuilder.InsertData(
                table: "NHANVIEN",
                columns: new[] { "MaNhanVien", "DaXoa", "DiaChi", "HinhAnh", "LoginString", "MaBoPhan", "Mail", "NgaySinh", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa", "SDT", "Status", "TenNhanVien", "Username" },
                values: new object[,]
                {
                    { "NV03", false, "Quảng Ngãi", null, null, null, "havy@gmail.com", new DateTime(2000, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 8, 6, 38, 52, 443, DateTimeKind.Local).AddTicks(3488), null, null, null, null, "123456789", 1, "Trần Nhật Hạ Vy", "haVy" },
                    { "NV02", false, "Quảng Ngãi", null, null, null, "danhvu@gmail.com", new DateTime(2000, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 8, 6, 38, 52, 443, DateTimeKind.Local).AddTicks(3462), null, null, null, null, "123456789", 1, "Lê Danh Vũ", "DanhVu" },
                    { "NV01", false, "Quảng Ngãi", null, null, null, "phamthivi459@gmail.com", new DateTime(2000, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 8, 6, 38, 52, 442, DateTimeKind.Local).AddTicks(4442), null, null, null, null, "0376437459", 1, "Phạm Thị Vi", "PhamTVi" }
                });

            migrationBuilder.InsertData(
                table: "THUOCTINH",
                columns: new[] { "MaThuocTinh", "TenThuocTinh" },
                values: new object[,]
                {
                    { "TT03", "Camera sau" },
                    { "TT04", "Camera trước" },
                    { "TT05", "Chip" },
                    { "TT01", "Màn hình" },
                    { "TT07", "Bộ nhớ trong" },
                    { "TT08", "SIM" },
                    { "TT09", "Pin, Sạc" },
                    { "TT010", "Trọng lượng Pin" },
                    { "TT011", "Kết nối với hệ điều hành" },
                    { "TT012", "Mặt" },
                    { "TT013", "Tính năng cho sức khỏe" },
                    { "TT02", "Hệ điều hành" },
                    { "TT06", "RAM" }
                });

            migrationBuilder.InsertData(
                table: "DIACHIKHACHHANG",
                columns: new[] { "MaDiaChi", "MaKhachHang", "DaXoa", "DiaChi", "Hoten", "LoaiDiaChi", "MacDinh", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa", "PhuongXa", "QuanHuyen", "SDT", "ThanhPho", "Tinh" },
                values: new object[,]
                {
                    { "DC01", "KH01", true, "Hẻm 1 Bùi Xuân Phái, Tây Thạnh, Tân Phú, HCM", null, 0, false, null, new DateTime(2021, 11, 8, 6, 38, 52, 443, DateTimeKind.Local).AddTicks(5802), null, null, null, null, null, null, "0376437459", null, null },
                    { "DC02", "KH01", true, "140 Lê Trọng Tấn,", null, 0, false, null, new DateTime(2021, 11, 8, 6, 38, 52, 443, DateTimeKind.Local).AddTicks(5859), null, null, null, null, null, null, "0376437459", null, null }
                });

            migrationBuilder.InsertData(
                table: "SANPHAM",
                columns: new[] { "MaSanPham", "DaXoa", "HinhAnh", "MaHang", "MaLoaiSanPham", "NgaySuaCuoi", "NgayTao", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa", "SoLuongTon", "Status", "TenSanPham", "Utility" },
                values: new object[,]
                {
                    { "SP019", false, "https://i.ibb.co/TLdWMdd/Vivo-v20-2021-xanh-hong-1-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8681), null, null, "admin", null, 1, 1, "Vivo V20 (2021)", 0m },
                    { "SP018", false, "https://i.ibb.co/S7Xy2TM/Vivo-v21-5g-tim-hong-1-3-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8674), null, null, "admin", null, 1, 1, "Vivo V21 5G", 0m },
                    { "SP017", false, "https://i.ibb.co/NrnVRWj/Vivo-x70-pro-black-gc-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8664), null, null, "admin", null, 1, 1, "Vivo X70 Pro 5G", 0m },
                    { "SP016", false, "https://i.ibb.co/XWGXkDf/Vivo-y21-1-2.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8649), null, null, "admin", null, 1, 1, "OPPO A16", 0m },
                    { "SP015", false, "https://i.ibb.co/vVV9xVR/Oppo-a16-1-2.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8640), null, null, "admin", null, 1, 1, "OPPO A16", 0m },
                    { "SP014", false, "https://i.ibb.co/94LDnqK/Oppo-reno4-pro-trang-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8630), null, null, "admin", null, 1, 1, "OPPO Reno4 Pro", 0m },
                    { "SP013", false, "https://i.ibb.co/55BgPLp/Oppo-reno5-5g-bac-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8620), null, null, "admin", null, 1, 1, "OPPO Reno5 5G", 0m },
                    { "SP012", false, "https://i.ibb.co/zbPGb0s/Oppo-reno6-den-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8611), null, null, "admin", null, 1, 1, "OPPO Reno6 5G", 0m },
                    { "SP011", false, "https://i.ibb.co/pw2Kqcp/Oppo-find-x3-pro-den-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8600), null, null, "admin", null, 1, 1, "OPPO Find X3 Pro 5G", 0m },
                    { "SP010", false, "https://i.ibb.co/ydCdghQ/Oppo-reno6-pro-5g-xanh-duong-1.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8591), null, null, "admin", null, 1, 1, "OPPO Reno6 Pro 5G", 0m },
                    { "SP09", false, "https://i.ibb.co/zRQB86R/Oppo-a74-xanh-duong-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8582), null, null, "admin", null, 1, 1, "OPPO A74", 0m },
                    { "SP08", false, "https://i.ibb.co/1rp5mbM/Oppo-reno6-z-5g-bac-1-org.jpg", "MH03", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8561), null, null, "admin", null, 1, 1, "OPPO Reno6 Z 5G", 0m },
                    { "SP026", false, "https://i.ibb.co/ydJ9XY5/Samsung-galaxy-watch-4-44mm-den-1-org.jpg", "MH02", "DM03", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8780), null, null, "admin", null, 1, 1, "Samsung Galaxy Watch 4 44mm ", 0m },
                    { "SP025", false, "https://i.ibb.co/9yR299t/Samsung-galaxy-watch-3-45mm-bac-2-org.jpg", "MH02", "DM03", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8771), null, null, "admin", null, 1, 1, "Samsung Galaxy Watch 3 45mm viền thép bạc dây da", 0m },
                    { "SP022", false, "https://i.ibb.co/k5rV9Vg/Samsung-galaxy-watch-4-44mm-den-1-org.jpg", "MH02", "DM03", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8734), null, null, "admin", null, 1, 1, "Samsung Galaxy Watch 4 44mm", 0m },
                    { "SP02", false, "https://i.ibb.co/CPq556s/Samsung-galaxy-z-flip-3-kem-1-org.jpg", "MH02", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8409), null, null, "admin", null, 1, 1, "Samsung Galaxy Z Flip3 5G 128GB", 0m },
                    { "SP01", false, "https://i.ibb.co/T2Ywg8N/Samsung-galaxy-z-fold-3-silver-gc-org.jpg", "MH02", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(6098), null, null, "admin", null, 1, 1, "Samsung Galaxy Z Fold3 5G 512GB", 0m },
                    { "SP028", false, "https://i.ibb.co/ZW5Wqpk/Apple-watch-s7-45mm-gps-do-1.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8800), null, null, "admin", null, 1, 1, "Apple Watch Series 7 GPS 45mm ", 0m },
                    { "SP027", false, "https://i.ibb.co/2YttfZB/Apple-watch-s6-lte-40mm-vien-thep-day-thep-vang-cont-1-org.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8790), null, null, "admin", null, 1, 1, "Apple Watch S6 LTE 40mm viền thép dây thép ", 0m },
                    { "SP024", false, "https://i.ibb.co/rcfS9Nm/Untitled-1-org.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8753), null, null, "admin", null, 1, 1, "Apple Watch SE 40mm viền nhôm dây cao su", 0m },
                    { "SP023", false, "https://i.ibb.co/bHRpNch/Apple-watch-s6-40mm-vien-nhom-day-cao-su-xanh-cont-1-org.jpg", "MH01", "DM03", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8743), null, null, "admin", null, 1, 1, "Apple Watch S6 40mm viền nhôm dây cao su", 0m },
                    { "SP07", false, "https://i.ibb.co/2v36jLV/iphone-XR-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8551), null, null, "admin", null, 1, 1, "iPhone XR 64GB", 0m },
                    { "SP06", false, "https://i.ibb.co/hZS5MJ3/Iphone-11-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8542), null, null, "admin", null, 1, 1, "iPhone 11 64GB", 0m },
                    { "SP05", false, "https://i.ibb.co/vsLZ8km/Iphone-12-mini-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8533), null, null, "admin", null, 1, 1, "iPhone 12 mini 64GB", 0m },
                    { "SP04", false, "https://i.ibb.co/JQNGCzb/Iphone-12-pro-max-128-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8523), null, null, "admin", null, 1, 1, "iPhone 12 Pro Max 128GB", 0m },
                    { "SP03", false, "https://i.ibb.co/RNz8N1G/Iphone-12-64-GB.jpg", "MH01", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8509), null, null, "admin", null, 1, 1, "iPhone 12 64GB", 0m },
                    { "SP020", false, "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8715), null, null, "admin", null, 1, 1, "Vivo Y72 5G", 0m },
                    { "SP021", false, "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg", "MH04", "DM01", null, new DateTime(2021, 11, 7, 23, 38, 52, 415, DateTimeKind.Utc).AddTicks(8726), null, null, "admin", null, 1, 1, "Vivo Y21s 6GB", 0m }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP03", "TT01", "OLED, 6.1, Super Retina XDR", 0f },
                    { "SP010", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP010", "TT09", "4500 mAh, 65 W", 0f },
                    { "SP011", "TT01", "AMOLED, 6.7, Quad HD+ (2K+)", 0f },
                    { "SP011", "TT02", "Android 11", 0f },
                    { "SP011", "TT03", "Chính 50 MP & Phụ 50 MP, 13 MP, 3 MP", 0f },
                    { "SP011", "TT04", "32 MP", 0f },
                    { "SP011", "TT05", "Snapdragon 888", 0f },
                    { "SP011", "TT06", "GB", 12f },
                    { "SP011", "TT07", "GB", 256f },
                    { "SP011", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP011", "TT09", "4500 mAh, 65 W", 0f },
                    { "SP012", "TT01", "AMOLED, 6.43, Full HD+", 0f },
                    { "SP012", "TT02", "Android 11", 0f },
                    { "SP012", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP012", "TT04", "32 MP", 0f },
                    { "SP012", "TT05", "MediaTek Dimensity 900 5G", 0f },
                    { "SP012", "TT06", "GB", 8f },
                    { "SP014", "TT02", "Android 10", 0f },
                    { "SP014", "TT01", "AMOLED, 6.5, Full HD + ", 0f },
                    { "SP013", "TT09", "4300 mAh, 65 W", 0f },
                    { "SP013", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP013", "TT07", "GB", 128f },
                    { "SP013", "TT06", "GB", 8f },
                    { "SP010", "TT07", "GB", 256f },
                    { "SP013", "TT05", "Snapdragon 765G", 0f },
                    { "SP013", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP, 2 MP", 0f },
                    { "SP013", "TT02", "Android 11", 0f },
                    { "SP013", "TT01", "AMOLED, 6.43, Full HD + ", 0f },
                    { "SP012", "TT09", "4300 mAh, 65 W", 0f },
                    { "SP012", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP012", "TT07", "GB", 128f },
                    { "SP013", "TT04", "32 MP", 0f },
                    { "SP014", "TT03", "Chính 48 MP & Phụ 8 MP, 2 MP, 2 MP", 0f },
                    { "SP010", "TT06", "GB", 12f },
                    { "SP010", "TT04", "32 MP", 0f },
                    { "SP022", "TT013", "Theo dõi giấc ngủ, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân", 0f },
                    { "SP025", "TT01", "SUPER AMOLED, 1.4 inch", 0f },
                    { "SP025", "TT010", "Khoảng 2 ngày", 0f },
                    { "SP025", "TT011", "Android 5.0 trở lên, iOS 9 trở lên", 0f },
                    { "SP025", "TT012", "Kính cường lực Gorrilla Glass Dx+, 45 mm", 0f },
                    { "SP025", "TT013", "Chế độ luyện tập, Theo dõi giấc ngủ, Tính lượng calories tiêu thụ, Tính quãng đường chạy, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân", 0f }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP026", "TT01", "SUPER AMOLED, 1.36 inch", 0f },
                    { "SP026", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP026", "TT011", "Android dùng Google Mobile Service", 0f },
                    { "SP026", "TT012", "Kính cường lực Gorrilla Glass Dx+, 44 mm", 0f },
                    { "SP026", "TT013", "Theo dõi giấc ngủ, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân", 0f },
                    { "SP08", "TT01", "AMOLED, 6.43, Full HD + ", 0f },
                    { "SP08", "TT02", "Android 11", 0f },
                    { "SP08", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP08", "TT05", "MediaTek Dimensity 800U 5G", 0f },
                    { "SP08", "TT06", "GB", 8f },
                    { "SP08", "TT07", "GB", 128f },
                    { "SP010", "TT03", "Chính 50 MP & Phụ 16 MP, 13 MP, 2 MP", 0f },
                    { "SP010", "TT02", "Android 11", 0f },
                    { "SP010", "TT01", "AMOLED6.55, Full HD+", 0f },
                    { "SP09", "TT09", "5000 mAh, 30 W", 0f },
                    { "SP09", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP09", "TT07", "GB", 128f },
                    { "SP010", "TT05", "Snapdragon 870 5G", 0f },
                    { "SP09", "TT06", "GB", 8f },
                    { "SP09", "TT04", "16 MP", 0f },
                    { "SP09", "TT03", "Chính 48 MP & Phụ 2 MP, 2 MP", 0f },
                    { "SP09", "TT02", "Android 11", 0f },
                    { "SP09", "TT01", "AMOLED6.43, Full HD + ", 0f },
                    { "SP08", "TT09", "4310 mAh, 30 W", 0f },
                    { "SP08", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP09", "TT05", "Snapdragon 662", 0f },
                    { "SP022", "TT012", "Kính cường lực Gorrilla Glass Dx+, 44 mm", 0f },
                    { "SP014", "TT04", "32 MP", 0f },
                    { "SP014", "TT06", "GB", 8f },
                    { "SP018", "TT06", "GB", 8f },
                    { "SP018", "TT07", "GB", 128f },
                    { "SP018", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP018", "TT09", "4000 mAh, 43 W", 0f },
                    { "SP019", "TT01", "IPS LCD, 6.44 HD + ", 0f },
                    { "SP019", "TT02", "Android 11", 0f },
                    { "SP019", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP019", "TT04", "44 MP", 0f },
                    { "SP019", "TT05", "Snapdragon 730", 0f },
                    { "SP019", "TT06", "GB", 8f },
                    { "SP019", "TT07", "GB", 128f },
                    { "SP019", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP019", "TT09", "4000 mAh, 33 W", 0f }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP020", "TT01", "IPS LCD, 6.58 HD + ", 0f },
                    { "SP020", "TT02", "Android 11", 0f },
                    { "SP020", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP020", "TT04", "16 MP", 0f },
                    { "SP021", "TT09", "5000 mAh, 18 W", 0f },
                    { "SP021", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP021", "TT07", "GB", 128f },
                    { "SP021", "TT06", "GB", 6f },
                    { "SP021", "TT05", "MediaTek Dimensity G80", 0f },
                    { "SP021", "TT04", "8 MP", 0f },
                    { "SP018", "TT05", "MediaTek Dimensity 800U 5G", 0f },
                    { "SP021", "TT03", "Chính 50 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP021", "TT01", "IPS LCD, 6.51 HD + ", 0f },
                    { "SP020", "TT09", "5000 mAh, 18 W", 0f },
                    { "SP020", "TT08", "2 Nano SIM (SIM 2 chung khe thẻ nhớ) Hỗ trợ 5G", 0f },
                    { "SP020", "TT07", "GB", 128f },
                    { "SP020", "TT06", "GB", 8f },
                    { "SP020", "TT05", "MediaTek Dimensity 700", 0f },
                    { "SP021", "TT02", "Android 11", 0f },
                    { "SP014", "TT05", "Snapdragon 720G", 0f },
                    { "SP018", "TT04", "44 MP", 0f },
                    { "SP018", "TT02", "Android 11", 0f },
                    { "SP014", "TT07", "GB", 256f },
                    { "SP014", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP014", "TT09", "4000 mAh, 65 W", 0f },
                    { "SP015", "TT01", "IPS LCD, 6.52, HD + ", 0f },
                    { "SP015", "TT02", "Android 11", 0f },
                    { "SP015", "TT03", "Chính 13 MP & Phụ 2 MP, 2 MP", 0f },
                    { "SP015", "TT04", "8 MP", 0f },
                    { "SP015", "TT05", "MediaTek Helio G35", 0f },
                    { "SP015", "TT06", "GB", 3f },
                    { "SP015", "TT07", "GB", 32f },
                    { "SP015", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP015", "TT09", "5000 mAh, 10 W", 0f },
                    { "SP016", "TT01", "IPS LCD, 6.51 HD + ", 0f },
                    { "SP016", "TT02", "Android 11", 0f },
                    { "SP016", "TT03", "Chính 13 MP & Phụ 2 MP", 0f },
                    { "SP016", "TT04", "8 MP", 0f },
                    { "SP016", "TT05", "MediaTek Helio P35", 0f },
                    { "SP018", "TT01", "IPS LCD, 6.44 HD + ", 0f },
                    { "SP017", "TT09", "4500 mAh, 44 W", 0f },
                    { "SP017", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP017", "TT07", "GB", 256f },
                    { "SP017", "TT06", "GB", 12f },
                    { "SP017", "TT05", "MediaTek Dimensity 1200", 0f },
                    { "SP018", "TT03", "Chính 64 MP & Phụ 8 MP, 2 MP", 0f },
                    { "SP017", "TT04", "8 MP", 0f },
                    { "SP017", "TT02", "Android 11", 0f },
                    { "SP017", "TT01", "IPS LCD, 6.56 HD + ", 0f },
                    { "SP016", "TT09", "5000 mAh, 18 W", 0f },
                    { "SP016", "TT08", "2 Nano SIM, Hỗ trợ 4G", 0f },
                    { "SP016", "TT07", "GB", 64f },
                    { "SP016", "TT06", "GB", 4f },
                    { "SP017", "TT03", "Chính 13 MP & Phụ 2 MP", 0f },
                    { "SP022", "TT011", "Android dùng Google Mobile Service", 0f },
                    { "SP08", "TT04", "32 MP", 0f },
                    { "SP022", "TT01", "SUPER AMOLED, 1.36 inch", 0f },
                    { "SP05", "TT03", "2 camera 12 MP", 0f },
                    { "SP027", "TT01", "OLED, 1.57 inch", 0f },
                    { "SP027", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP027", "TT011", "iOS 14 trở lên", 0f },
                    { "SP027", "TT012", "Kính cường lực Sapphire40 mm", 0f },
                    { "SP027", "TT013", "Chế độ luyện tập, Theo dõi giấc ngủ, Tính lượng calories tiêu thụ, Tính quãng đường chạy, Đo nhịp tim, Đếm số bước chân", 0f },
                    { "SP05", "TT04", "12 MP", 0f },
                    { "SP07", "TT04", "7 MP", 0f },
                    { "SP04", "TT04", "12 MP", 0f },
                    { "SP07", "TT03", "12 MP", 0f },
                    { "SP07", "TT02", "iOS 14", 0f },
                    { "SP04", "TT02", "iOS 14", 0f },
                    { "SP028", "TT01", "OLED, 1.77 inch", 0f },
                    { "SP028", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP028", "TT011", "iOS 14 trở lên", 0f },
                    { "SP028", "TT012", "Ion-X strengthened glass45 mm", 0f },
                    { "SP028", "TT013", "Chế độ luyện tập, Theo dõi giấc ngủ, Tính lượng calories tiêu thụ, Tính quãng đường chạy, Điện tâm đồ, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân", 0f },
                    { "SP07", "TT01", "IPS LCD, 6.1, Liquid Retina", 0f },
                    { "SP04", "TT03", "3 camera 12 MP", 0f },
                    { "SP04", "TT01", "OLED, 6.7, Super Retina XDR", 0f },
                    { "SP04", "TT05", "Apple A14 Bionic", 0f },
                    { "SP07", "TT05", "Apple A12 Bionic", 0f },
                    { "SP023", "TT01", "OLED, 1.57 inch", 0f },
                    { "SP023", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP023", "TT011", "iOS 14 trở lên", 0f },
                    { "SP023", "TT012", "Ion-X strengthened glass, 40 mm", 0f },
                    { "SP023", "TT013", "Chế độ luyện tập, Theo dõi giấc ngủ, Tính lượng calories tiêu thụ, Tính quãng đường chạy, Điện tâm đồ, Đo nhịp tim, Đo nồng độ oxy (SpO2), Đếm số bước chân", 0f }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP05", "TT02", "iOS 14", 0f },
                    { "SP07", "TT09", "2942 mAh, 15 W", 0f },
                    { "SP07", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 4G", 0f },
                    { "SP04", "TT06", "GB", 6f },
                    { "SP07", "TT07", "GB", 64f },
                    { "SP04", "TT09", "3687 mAh, 20 W", 0f },
                    { "SP04", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 5G", 0f },
                    { "SP04", "TT07", "GB", 128f },
                    { "SP024", "TT01", "OLED, 1.57 inch", 0f },
                    { "SP024", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP024", "TT011", "iOS 14 trở lên", 0f },
                    { "SP024", "TT012", "Ion-X strengthened glass, 40 mm", 0f },
                    { "SP024", "TT013", "Chế độ luyện tập, Theo dõi giấc ngủ, Tính lượng calories tiêu thụ, Tính quãng đường chạy, Đo nhịp tim, Đếm số bước chân", 0f },
                    { "SP07", "TT06", "GB", 3f },
                    { "SP022", "TT010", "Khoảng 1.5 ngày", 0f },
                    { "SP05", "TT05", "Apple A14 Bionic", 0f },
                    { "SP05", "TT07", "GB", 64f },
                    { "SP03", "TT07", "GB", 64f },
                    { "SP03", "TT06", "GB", 4f },
                    { "SP03", "TT05", "Apple A14 Bionic", 0f },
                    { "SP06", "TT03", "2 camera 12 MP", 0f },
                    { "SP02", "TT02", "Android 11", 0f },
                    { "SP02", "TT03", "2 camera 12 MP", 0f },
                    { "SP02", "TT04", "10 MP", 0f },
                    { "SP02", "TT05", "Snapdragon 888", 0f },
                    { "SP02", "TT06", "GB", 8f },
                    { "SP03", "TT04", "12 MP", 0f },
                    { "SP06", "TT02", "iOS 14", 0f },
                    { "SP02", "TT07", "GB", 128f },
                    { "SP02", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 5G", 0f },
                    { "SP02", "TT09", "3300 mAh, 25 W", 0f },
                    { "SP03", "TT03", "2 camera 12 MP", 0f },
                    { "SP03", "TT02", "iOS 14", 0f },
                    { "SP06", "TT01", "IPS LCD, 6.1, Liquid Retina", 0f },
                    { "SP02", "TT01", "Dynamic AMOLED 2X, Chính 6.7 & Phụ 1.9, Full HD+", 0f },
                    { "SP05", "TT06", "GB", 4f },
                    { "SP03", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 5G", 0f },
                    { "SP01", "TT04", "10 MP & 4 MP", 0f },
                    { "SP05", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 5G", 0f },
                    { "SP05", "TT09", "2227 mAh, 20 W", 0f },
                    { "SP01", "TT01", "Dynamic AMOLED 2X, Chính 7.6 & Phụ 6.2, Full HD+", 0f },
                    { "SP01", "TT02", "Android 11", 0f }
                });

            migrationBuilder.InsertData(
                table: "DINHLUONG",
                columns: new[] { "MaSanPham", "MaThuocTinh", "DonVi", "GiaTri" },
                values: new object[,]
                {
                    { "SP01", "TT03", "3 camera 12 MP", 0f },
                    { "SP03", "TT09", "2815 mAh, 20 W", 0f },
                    { "SP01", "TT05", "Snapdragon 888", 0f },
                    { "SP01", "TT06", "GB", 12f },
                    { "SP05", "TT01", "OLED, 5.4, Super Retina XDR", 0f },
                    { "SP06", "TT08", "1 Nano SIM & 1 eSIM, Hỗ trợ 4G", 0f },
                    { "SP06", "TT07", "GB", 64f },
                    { "SP01", "TT07", "GB", 512f },
                    { "SP01", "TT08", "2 Nano SIM, Hỗ trợ 5G", 0f },
                    { "SP01", "TT09", "4400 mAh, 25 W", 0f },
                    { "SP06", "TT06", "GB", 4f },
                    { "SP06", "TT05", "Apple A13 Bionic", 0f },
                    { "SP06", "TT04", "12 MP", 0f },
                    { "SP06", "TT09", "3110 mAh, 18 W", 0f }
                });

            migrationBuilder.InsertData(
                table: "LICHSUGIA",
                columns: new[] { "MaSanPham", "NgayTao", "DaXoa", "GiaMoi", "NgaySuaCuoi", "NgayXoa", "NguoiSuaCuoi", "NguoiTao", "NguoiXoa" },
                values: new object[,]
                {
                    { "SP07", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 13490000m, null, null, null, null, null },
                    { "SP06", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 16990000m, null, null, null, null, null },
                    { "SP016", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4290000m, null, null, null, null, null },
                    { "SP05", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 16490000m, null, null, null, null, null },
                    { "SP015", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3990000m, null, null, null, null, null },
                    { "SP014", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10490000m, null, null, null, null, null },
                    { "SP011", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 23990000m, null, null, null, null, null },
                    { "SP027", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 16792000m, null, null, null, null, null },
                    { "SP01", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 43990000m, null, null, null, null, null },
                    { "SP08", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9990000m, null, null, null, null, null },
                    { "SP028", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12990000m, null, null, null, null, null },
                    { "SP010", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 18490000m, null, null, null, null, null },
                    { "SP03", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 18700000m, null, null, null, null, null },
                    { "SP026", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6990000m, null, null, null, null, null },
                    { "SP020", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7590000m, null, null, null, null, null },
                    { "SP019", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7790000m, null, null, null, null, null },
                    { "SP018", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9490000m, null, null, null, null, null },
                    { "SP025", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4990000m, null, null, null, null, null },
                    { "SP012", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12990000m, null, null, null, null, null },
                    { "SP04", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 31490000m, null, null, null, null, null },
                    { "SP02", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 24990000m, null, null, null, null, null },
                    { "SP022", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 750000m, null, null, null, null, null },
                    { "SP023", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9592000m, null, null, null, null, null },
                    { "SP021", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5990000m, null, null, null, null, null },
                    { "SP013", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10990000m, null, null, null, null, null },
                    { "SP024", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8450000m, null, null, null, null, null },
                    { "SP09", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6990000m, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "MAUMASANPHAM",
                columns: new[] { "MaSanPham", "TenMauMa", "HinhAnh", "MaMauMa" },
                values: new object[] { "SP020", "Đen", "https://i.ibb.co/mCbyxk9/Vivo-y72-5g-den-1-org.jpg", "MM054" });

            migrationBuilder.InsertData(
                table: "MAUMASANPHAM",
                columns: new[] { "MaSanPham", "TenMauMa", "HinhAnh", "MaMauMa" },
                values: new object[,]
                {
                    { "SP04", "Xanh", "https://i.ibb.co/5LvRhJ4/Iphone-12-pro-max-xanh-duong-1-org.jpg", "MM015" },
                    { "SP05", "Đen", "https://i.ibb.co/crZFrkD/Iphone-12-mini-den-1-1-org.jpg", "MM016" },
                    { "SP020", "Xanh hồng", "https://i.ibb.co/swGN954/Vivo-y72-5g-xanh-hong-1-1-org.jpg", "MM055" },
                    { "SP03", "Đen", "https://i.ibb.co/0qYwZ5c/Iphone-12-64-GB-en.jpg", "MM07" },
                    { "SP03", "Trắng", "https://i.ibb.co/vsLZ8km/Iphone-12-mini-64-GB.jpg", "MM010" },
                    { "SP017", "Xanh hồng", "https://i.ibb.co/TcQYYxs/Vivo-x70-pro-xanh-1-1.jpg", "MM048" },
                    { "SP03", "Tím", "https://i.ibb.co/GC6Tdwd/Iphone-12-64-GB-T-m.jpg", "MM09" },
                    { "SP017", "Đen", "https://i.ibb.co/NrnVRWj/Vivo-x70-pro-black-gc-org.jpg", "MM049" },
                    { "SP03", "Xanh", "https://i.ibb.co/6XtyJbM/Iphone-12-64-GB-Xanh.jpg", "MM011" },
                    { "SP03", "Xanh lá", "https://i.ibb.co/D5Xg9sQ/Iphone-12-64-GB-Xanh-l.jpg", "MM012" },
                    { "SP019", "Xanh hồng", "https://i.ibb.co/TLdWMdd/Vivo-v20-2021-xanh-hong-1-org.jpg", "MM053" },
                    { "SP019", "Đen", "https://i.ibb.co/tcNjPQL/Vivo-v20-2021-den-1-org.jpg", "MM052" },
                    { "SP05", "Đỏ", "https://i.ibb.co/jkmt501/Iphone-12-mini-1-1-org.jpg", "MM017" },
                    { "SP04", "Bạc", "https://i.ibb.co/pW2nvth/Iphone-12-pro-max-bac-1-org.jpg", "MM013" },
                    { "SP04", "Vàng", "https://i.ibb.co/JQNGCzb/Iphone-12-pro-max-128-GB.jpg", "MM014" },
                    { "SP018", "Đen", "https://i.ibb.co/wwT6MVD/Vivo-v21-5g-xanh-den-1-org.jpg", "MM051" },
                    { "SP018", "Tím hồng", "https://i.ibb.co/S7Xy2TM/Vivo-v21-5g-tim-hong-1-3-org.jpg", "MM050" },
                    { "SP03", "Đỏ", "https://i.ibb.co/RNz8N1G/Iphone-12-64-GB.jpg", "MM08" },
                    { "SP05", "Tím", "https://i.ibb.co/30KH8b2/Iphone-12-mini-tim-gc-1-org.jpg", "MM018" },
                    { "SP07", "Đen", "https://i.ibb.co/yWZQJPt/Iphone-XR-en.jpg", "MM028" },
                    { "SP05", "Xanh dương", "https://i.ibb.co/Np97nN6/Iphone-12-mini-xanh-duong-1-1-org.jpg", "MM020" },
                    { "SP027", "vàng", "https://i.ibb.co/2YttfZB/Apple-watch-s6-lte-40mm-vien-thep-day-thep-vang-cont-1-org.jpg", "MM069" },
                    { "SP010", "Xám", "https://i.ibb.co/yVs3g8T/Oppo-reno6-pro-5g-xam-1.jpg", "MM036" },
                    { "SP010", "Xanh dương", "https://i.ibb.co/jJ1XBWq/Oppo-reno6-pro-5g-xanh-duong-1.jpg", "MM035" },
                    { "SP027", "Đen", "https://i.ibb.co/JH2Fshs/Apple-watch-s6-lte-40mm-vien-thep-day-thep-den-cont-1-org.jpg", "MM070" },
                    { "SP028", "Đen", "https://i.ibb.co/mDSQcPD/Apple-watch-s7-45mm-gps-den-1.jpg", "MM071" },
                    { "SP028", "Vàng", "https://i.ibb.co/BrWrjZh/Apple-watch-s7-45mm-gps-vang-1.jp", "MM072" },
                    { "SP09", "Đen", "https://i.ibb.co/M5Mk64X/Oppo-a74-den-5-org.jpg", "MM034" },
                    { "SP09", "Xanh dương", "https://i.ibb.co/zRQB86R/Oppo-a74-xanh-duong-1-org.jpg", "MM033" },
                    { "SP028", "Đỏ", "https://i.ibb.co/ZW5Wqpk/Apple-watch-s7-45mm-gps-do-1.jpg", "MM073" },
                    { "SP028", "Xanh Dương", "https://i.ibb.co/Qjbqcqf/Apple-watch-s7-45mm-gps-xanh-duong-1.jpg", "MM074" },
                    { "SP028", "Xanh Lá", "ttps://i.ibb.co/V9d5FLq/apple-watch-s7-45mm-gps-xanh-la-1.jpg", "MM075" },
                    { "SP024", "Đen", "https://i.ibb.co/3dBt9bj/Se-40mm-vien-nhom-day-cao-su-hong-glr-1-org.jpg", "MM064" },
                    { "SP08", "Đen", "https://i.ibb.co/KXWZfKL/Oppo-reno6-z-5g-den-1-org.jpg", "MM032" },
                    { "SP01", "Xanh riêu", "https://i.ibb.co/9WvYqLR/Samsung-galaxy-z-fold3-5g-1.jpg", "MM01" },
                    { "SP021", "Trắng", "https://i.ibb.co/Yd1wV4H/Vivo-y21s-trang-1-1.jpg", "MM056" },
                    { "SP01", "Bạc", "https://i.ibb.co/T2Ywg8N/Samsung-galaxy-z-fold-3-silver-gc-org.jpg", "MM02" },
                    { "SP01", "Đen", "https://i.ibb.co/qyCNcw6/Samsung-galaxy-z-fold-3-1-org.jpg", "MM03" },
                    { "SP026", "Bạc", "https://i.ibb.co/XVM9Mxj/Samsung-galaxy-watch-4-44mm-bac-1-org.jpg", "MM068" },
                    { "SP026", "Xanh lá", "https://i.ibb.co/s2mSnhK/Samsung-galaxy-watch-4-44mm-1-1.jpg", "MM067" },
                    { "SP026", "Đen", "https://i.ibb.co/ydJ9XY5/Samsung-galaxy-watch-4-44mm-den-1-org.jpg", "MM066" },
                    { "SP025", "Bạc", "https://i.ibb.co/9yR299t/Samsung-galaxy-watch-3-45mm-bac-2-org.jpg", "MM065" }
                });

            migrationBuilder.InsertData(
                table: "MAUMASANPHAM",
                columns: new[] { "MaSanPham", "TenMauMa", "HinhAnh", "MaMauMa" },
                values: new object[,]
                {
                    { "SP02", "Kem", "https://i.ibb.co/CPq556s/Samsung-galaxy-z-flip-3-kem-1-org.jpg", "MM04" },
                    { "SP02", "Đen", "https://i.ibb.co/0tXPPWn/Samsung-galaxy-z-flip-3-black-gc-org.jpg", "MM05" },
                    { "SP02", "Xanh riêu", "https://i.ibb.co/9WvYqLR/Samsung-galaxy-z-fold3-5g-1.jpg", "MM06" },
                    { "SP08", "Bạc", "https://i.ibb.co/MNpLvHY/Oppo-reno6-z-5g-bac-1-org.jpg", "MM031" },
                    { "SP05", "Trắng", "https://i.ibb.co/5LRj1Wh/Iphone-12-mini-trang-1-1-org.jpg", "MM019" },
                    { "SP024", "Hồng", "https://i.ibb.co/rcfS9Nm/Untitled-1-org.jpg", "MM063" },
                    { "SP011", "Xanh đen", "https://i.ibb.co/Rp3jcB3/Oppo-find-x3-pro-xanh-1-org.jpg", "MM038" },
                    { "SP05", "Hologram", "https://i.ibb.co/0stYCyp/Iphone-11-den-1-1-1-org.jpg", "MM021" },
                    { "SP016", "Xanh tím", "https://i.ibb.co/XYj2R7d/Vivo-y21-blue-gc-1-org.jpg", "MM047" },
                    { "SP016", "Trắng", "https://i.ibb.co/XWGXkDf/Vivo-y21-1-2.jpg", "MM046" },
                    { "SP015", "Đen", "https://i.ibb.co/2M6JLdw/Oppo-a16-1-1.jpg", "MM044" },
                    { "SP015", "Bạc", "https://i.ibb.co/vVV9xVR/Oppo-a16-1-2.jpg", "MM045" },
                    { "SP06", "Đỏ", "https://i.ibb.co/WBH28Zh/Iphone-11-do-1-1-1-org.jpg", "MM022" },
                    { "SP06", "Tím", "https://i.ibb.co/Lnt4WzS/Iphone-11-tim-1-1-1-org.jpg", "MM023" },
                    { "SP06", "Trắng", "https://i.ibb.co/pLyJDFG/Iphone-11-trang-1-2-org.jpg", "MM024" },
                    { "SP06", "Vàng", "https://i.ibb.co/26xpZH9/Iphone-11-vang-1-2-org.jpg", "MM025" },
                    { "SP06", "Xanh lá", "https://i.ibb.co/hZS5MJ3/Iphone-11-64-GB.jpg", "MM026" },
                    { "SP014", "Đen", "https://i.ibb.co/RBQ3zwg/Oppo-reno4-pro-den-1-org.jpg", "MM044" },
                    { "SP011", "Đen", "https://i.ibb.co/pw2Kqcp/Oppo-find-x3-pro-den-1-org.jpg", "MM037" },
                    { "SP014", "Trắng", "https://i.ibb.co/94LDnqK/Oppo-reno4-pro-trang-1-org.jpg", "MM043" },
                    { "SP07", "Vàng", "https://i.ibb.co/6y40G5v/20210416-6cec022bdb9abc311894b08e71bd0769-1618550179.jpg", "MM029" },
                    { "SP013", "Đen", "https://i.ibb.co/MhHDY3L/Oppo-reno5-5g-den-org.jpg", "MM042" },
                    { "SP013", "Bạc", "https://i.ibb.co/55BgPLp/Oppo-reno5-5g-bac-1-org.jpg", "MM041" },
                    { "SP07", "Xanh", "https://i.ibb.co/2v36jLV/iphone-XR-64-GB.jpg", "MM030" },
                    { "SP023", "Hồng", "https://i.ibb.co/whQPQYR/Apple-watch-s6-40mm-vien-nhom-day-cao-su-hong-cont-1-org.jpg", "MM058" },
                    { "SP023", "Xanh dương đậm", "https://i.ibb.co/bHRpNch/Apple-watch-s6-40mm-vien-nhom-day-cao-su-xanh-cont-1-org.jpg", "MM059" },
                    { "SP012", "Đen", "https://i.ibb.co/zbPGb0s/Oppo-reno6-den-1-org.jpg", "MM040" },
                    { "SP012", "Bạc", "https://i.ibb.co/7YG6TFH/Oppo-reno6-bac-1-org.jpg", "MM039" },
                    { "SP023", "Trắng", "https://i.ibb.co/vV2zr9s/Apple-watch-s6-40mm-vien-nhom-day-cao-su-trang-cont-1-org.jpg", "MM060" },
                    { "SP023", "Đen", "https://i.ibb.co/sPCkGSb/Apple-watch-s6-40mm-vien-nhom-day-cao-su-den-cont-1-org.jpg", "MM061" },
                    { "SP023", "Đỏ", "https://i.ibb.co/4TQV8yv/Apple-watch-s6-40mm-vien-nhom-day-cao-su-red-do-cont-1-org-org.jp", "MM062" },
                    { "SP07", "Cam", "https://i.ibb.co/8d4VJxn/mo-hop-iphone-xr-ban-mau-cam.jpg", "MM027" },
                    { "SP021", "Xanh", "https://i.ibb.co/5hkXcM1/Vivo-y21s-blue-gc-org.jpg", "MM057" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04052000");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123456789");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc");

            migrationBuilder.DeleteData(
                table: "BOPHAN",
                keyColumn: "MaBoPhan",
                keyValue: "BP01");

            migrationBuilder.DeleteData(
                table: "BOPHAN",
                keyColumn: "MaBoPhan",
                keyValue: "BP02");

            migrationBuilder.DeleteData(
                table: "BOPHAN",
                keyColumn: "MaBoPhan",
                keyValue: "BP03");

            migrationBuilder.DeleteData(
                table: "BOPHAN",
                keyColumn: "MaBoPhan",
                keyValue: "BP04");

            migrationBuilder.DeleteData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM02");

            migrationBuilder.DeleteData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM04");

            migrationBuilder.DeleteData(
                table: "DIACHIKHACHHANG",
                keyColumns: new[] { "MaDiaChi", "MaKhachHang" },
                keyValues: new object[] { "DC01", "KH01" });

            migrationBuilder.DeleteData(
                table: "DIACHIKHACHHANG",
                keyColumns: new[] { "MaDiaChi", "MaKhachHang" },
                keyValues: new object[] { "DC02", "KH01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP01", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP010", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP011", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP012", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP013", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP014", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP015", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP016", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP017", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP018", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP019", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP02", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP020", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP021", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP022", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP023", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP024", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP025", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP026", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP027", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP028", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP03", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP04", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP05", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP06", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP07", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP08", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP09", "TT01" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP022", "TT010" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP023", "TT010" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP024", "TT010" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP025", "TT010" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP026", "TT010" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP027", "TT010" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP028", "TT010" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP022", "TT011" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP023", "TT011" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP024", "TT011" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP025", "TT011" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP026", "TT011" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP027", "TT011" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP028", "TT011" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP022", "TT012" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP023", "TT012" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP024", "TT012" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP025", "TT012" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP026", "TT012" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP027", "TT012" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP028", "TT012" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP022", "TT013" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP023", "TT013" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP024", "TT013" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP025", "TT013" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP026", "TT013" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP027", "TT013" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP028", "TT013" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP01", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP010", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP011", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP012", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP013", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP014", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP015", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP016", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP017", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP018", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP019", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP02", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP020", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP021", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP03", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP04", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP05", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP06", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP07", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP08", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP09", "TT02" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP01", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP010", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP011", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP012", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP013", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP014", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP015", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP016", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP017", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP018", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP019", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP02", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP020", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP021", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP03", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP04", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP05", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP06", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP07", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP08", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP09", "TT03" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP01", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP010", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP011", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP012", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP013", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP014", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP015", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP016", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP017", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP018", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP019", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP02", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP020", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP021", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP03", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP04", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP05", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP06", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP07", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP08", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP09", "TT04" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP01", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP010", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP011", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP012", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP013", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP014", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP015", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP016", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP017", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP018", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP019", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP02", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP020", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP021", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP03", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP04", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP05", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP06", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP07", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP08", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP09", "TT05" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP01", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP010", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP011", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP012", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP013", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP014", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP015", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP016", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP017", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP018", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP019", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP02", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP020", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP021", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP03", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP04", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP05", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP06", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP07", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP08", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP09", "TT06" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP01", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP010", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP011", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP012", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP013", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP014", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP015", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP016", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP017", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP018", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP019", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP02", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP020", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP021", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP03", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP04", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP05", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP06", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP07", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP08", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP09", "TT07" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP01", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP010", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP011", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP012", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP013", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP014", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP015", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP016", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP017", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP018", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP019", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP02", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP020", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP021", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP03", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP04", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP05", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP06", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP07", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP08", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP09", "TT08" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP01", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP010", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP011", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP012", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP013", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP014", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP015", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP016", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP017", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP018", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP019", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP02", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP020", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP021", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP03", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP04", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP05", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP06", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP07", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP08", "TT09" });

            migrationBuilder.DeleteData(
                table: "DINHLUONG",
                keyColumns: new[] { "MaSanPham", "MaThuocTinh" },
                keyValues: new object[] { "SP09", "TT09" });

            migrationBuilder.DeleteData(
                table: "KHACHHANG",
                keyColumn: "MaKhachHang",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc");

            migrationBuilder.DeleteData(
                table: "KHACHHANG",
                keyColumn: "MaKhachHang",
                keyValue: "KH02");

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP01", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP010", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP011", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP012", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP013", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP014", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP015", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP016", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP018", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP019", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP02", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP020", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP021", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP022", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP023", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP024", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP025", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP026", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP027", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP028", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP03", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP04", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP05", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP06", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP07", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP08", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "LICHSUGIA",
                keyColumns: new[] { "MaSanPham", "NgayTao" },
                keyValues: new object[] { "SP09", new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP01", "Bạc" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP01", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP01", "Xanh riêu" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP010", "Xám" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP010", "Xanh dương" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP011", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP011", "Xanh đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP012", "Bạc" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP012", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP013", "Bạc" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP013", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP014", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP014", "Trắng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP015", "Bạc" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP015", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP016", "Trắng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP016", "Xanh tím" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP017", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP017", "Xanh hồng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP018", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP018", "Tím hồng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP019", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP019", "Xanh hồng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP02", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP02", "Kem" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP02", "Xanh riêu" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP020", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP020", "Xanh hồng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP021", "Trắng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP021", "Xanh" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP023", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP023", "Đỏ" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP023", "Hồng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP023", "Trắng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP023", "Xanh dương đậm" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP024", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP024", "Hồng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP025", "Bạc" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP026", "Bạc" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP026", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP026", "Xanh lá" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP027", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP027", "vàng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP028", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP028", "Đỏ" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP028", "Vàng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP028", "Xanh Dương" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP028", "Xanh Lá" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP03", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP03", "Đỏ" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP03", "Tím" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP03", "Trắng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP03", "Xanh" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP03", "Xanh lá" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP04", "Bạc" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP04", "Vàng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP04", "Xanh" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP05", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP05", "Đỏ" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP05", "Hologram" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP05", "Tím" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP05", "Trắng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP05", "Xanh dương" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP06", "Đỏ" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP06", "Tím" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP06", "Trắng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP06", "Vàng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP06", "Xanh lá" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP07", "Cam" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP07", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP07", "Vàng" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP07", "Xanh" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP08", "Bạc" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP08", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP09", "Đen" });

            migrationBuilder.DeleteData(
                table: "MAUMASANPHAM",
                keyColumns: new[] { "MaSanPham", "TenMauMa" },
                keyValues: new object[] { "SP09", "Xanh dương" });

            migrationBuilder.DeleteData(
                table: "NHANHIEU",
                keyColumn: "MaHang",
                keyValue: "MH05");

            migrationBuilder.DeleteData(
                table: "NHANHIEU",
                keyColumn: "MaHang",
                keyValue: "MH06");

            migrationBuilder.DeleteData(
                table: "NHANHIEU",
                keyColumn: "MaHang",
                keyValue: "MH07");

            migrationBuilder.DeleteData(
                table: "NHANHIEU",
                keyColumn: "MaHang",
                keyValue: "MH08");

            migrationBuilder.DeleteData(
                table: "NHANHIEU",
                keyColumn: "MaHang",
                keyValue: "MH09");

            migrationBuilder.DeleteData(
                table: "NHANVIEN",
                keyColumn: "MaNhanVien",
                keyValue: "NV01");

            migrationBuilder.DeleteData(
                table: "NHANVIEN",
                keyColumn: "MaNhanVien",
                keyValue: "NV02");

            migrationBuilder.DeleteData(
                table: "NHANVIEN",
                keyColumn: "MaNhanVien",
                keyValue: "NV03");

            migrationBuilder.DeleteData(
                table: "KHACHHANG",
                keyColumn: "MaKhachHang",
                keyValue: "KH01");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP01");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP010");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP011");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP012");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP013");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP014");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP015");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP016");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP017");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP018");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP019");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP02");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP020");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP021");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP022");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP023");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP024");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP025");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP026");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP027");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP028");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP03");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP04");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP05");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP06");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP07");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP08");

            migrationBuilder.DeleteData(
                table: "SANPHAM",
                keyColumn: "MaSanPham",
                keyValue: "SP09");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT01");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT010");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT011");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT012");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT013");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT02");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT03");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT04");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT05");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT06");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT07");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT08");

            migrationBuilder.DeleteData(
                table: "THUOCTINH",
                keyColumn: "MaThuocTinh",
                keyValue: "TT09");

            migrationBuilder.DeleteData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM01");

            migrationBuilder.DeleteData(
                table: "DANHMUC",
                keyColumn: "MaDanhMuc",
                keyValue: "DM03");

            migrationBuilder.DeleteData(
                table: "NHANHIEU",
                keyColumn: "MaHang",
                keyValue: "MH01");

            migrationBuilder.DeleteData(
                table: "NHANHIEU",
                keyColumn: "MaHang",
                keyValue: "MH02");

            migrationBuilder.DeleteData(
                table: "NHANHIEU",
                keyColumn: "MaHang",
                keyValue: "MH03");

            migrationBuilder.DeleteData(
                table: "NHANHIEU",
                keyColumn: "MaHang",
                keyValue: "MH04");
        }
    }
}
