using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebsite.Data.Migrations
{
    public partial class capnhatlaisql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CTHOADON_HOADON_MaHD",
                table: "CTHOADON");

            migrationBuilder.DropForeignKey(
                name: "FK_CTHOADON_SANPHAM_MaSP",
                table: "CTHOADON");

            migrationBuilder.DropForeignKey(
                name: "FK_CTNHAPSP_SANPHAM_MaSP",
                table: "CTNHAPSP");

            migrationBuilder.DropForeignKey(
                name: "FK_DANHGIASP_SANPHAM_MaSP",
                table: "DANHGIASP");

            migrationBuilder.DropForeignKey(
                name: "FK_DIACHIKH_KHACHHANG_MaKH",
                table: "DIACHIKH");

            migrationBuilder.DropForeignKey(
                name: "FK_DINHLUONG_SANPHAM_MaSP",
                table: "DINHLUONG");

            migrationBuilder.DropForeignKey(
                name: "FK_DINHLUONG_THUOCTINH_MaTT",
                table: "DINHLUONG");

            migrationBuilder.DropForeignKey(
                name: "FK_GIAOHANG_HOADON_MaHD",
                table: "GIAOHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_HOADON_DIACHIKH_MaDiaChiKH_MaKH",
                table: "HOADON");

            migrationBuilder.DropForeignKey(
                name: "FK_HOADON_KHACHHANG_MaKH",
                table: "HOADON");

            migrationBuilder.DropForeignKey(
                name: "FK_HOADON_KHUYENMAI_MaKM",
                table: "HOADON");

            migrationBuilder.DropForeignKey(
                name: "FK_LICHSUGIA_SANPHAM_MaSP",
                table: "LICHSUGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_MAUSANPHAM_SANPHAM_MaSP",
                table: "MAUSANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANVIEN_BOPHAN_MaBP",
                table: "NHANVIEN");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANXETSP_KHACHHANG_MaKH",
                table: "NHANXETSP");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANXETSP_SANPHAM_MaSP",
                table: "NHANXETSP");

            migrationBuilder.DropForeignKey(
                name: "FK_NHAPSANPHAM_NHACUNGCAP_MaNCC",
                table: "NHAPSANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_NHAPSANPHAM_NHANVIEN_MaNV",
                table: "NHAPSANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_LOAISANPHAM_MaLoaiSP",
                table: "SANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_TINHTRANGIAOHANG_GIAOHANG_MaGH",
                table: "TINHTRANGIAOHANG");

            migrationBuilder.DropIndex(
                name: "IX_GIAOHANG_MaHD",
                table: "GIAOHANG");

            migrationBuilder.DropIndex(
                name: "IX_DANHGIASP_MaSP",
                table: "DANHGIASP");

            migrationBuilder.RenameColumn(
                name: "MaTTGH",
                table: "TINHTRANGIAOHANG",
                newName: "MaTinhTrangGH");

            migrationBuilder.RenameColumn(
                name: "MaGH",
                table: "TINHTRANGIAOHANG",
                newName: "MaGiaoHang");

            migrationBuilder.RenameColumn(
                name: "TenTT",
                table: "THUOCTINH",
                newName: "TenThuocTinh");

            migrationBuilder.RenameColumn(
                name: "MaTT",
                table: "THUOCTINH",
                newName: "MaThuocTinh");

            migrationBuilder.RenameColumn(
                name: "TenSP",
                table: "SANPHAM",
                newName: "TenSanPham");

            migrationBuilder.RenameColumn(
                name: "MaLoaiSP",
                table: "SANPHAM",
                newName: "MaLoai");

            migrationBuilder.RenameColumn(
                name: "MaSP",
                table: "SANPHAM",
                newName: "MaSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_SANPHAM_MaLoaiSP",
                table: "SANPHAM",
                newName: "IX_SANPHAM_MaLoai");

            migrationBuilder.RenameColumn(
                name: "MaNV",
                table: "NHAPSANPHAM",
                newName: "MaNhanVien");

            migrationBuilder.RenameColumn(
                name: "MaNCC",
                table: "NHAPSANPHAM",
                newName: "MaNhaCungCap");

            migrationBuilder.RenameIndex(
                name: "IX_NHAPSANPHAM_MaNV",
                table: "NHAPSANPHAM",
                newName: "IX_NHAPSANPHAM_MaNhanVien");

            migrationBuilder.RenameIndex(
                name: "IX_NHAPSANPHAM_MaNCC",
                table: "NHAPSANPHAM",
                newName: "IX_NHAPSANPHAM_MaNhaCungCap");

            migrationBuilder.RenameColumn(
                name: "MaSP",
                table: "NHANXETSP",
                newName: "MaSanPham");

            migrationBuilder.RenameColumn(
                name: "MaKH",
                table: "NHANXETSP",
                newName: "MaKhachHang");

            migrationBuilder.RenameIndex(
                name: "IX_NHANXETSP_MaSP",
                table: "NHANXETSP",
                newName: "IX_NHANXETSP_MaSanPham");

            migrationBuilder.RenameColumn(
                name: "TenNV",
                table: "NHANVIEN",
                newName: "TenNhanVien");

            migrationBuilder.RenameColumn(
                name: "MaBP",
                table: "NHANVIEN",
                newName: "MaBoPhan");

            migrationBuilder.RenameColumn(
                name: "MaNV",
                table: "NHANVIEN",
                newName: "MaNhanVien");

            migrationBuilder.RenameIndex(
                name: "IX_NHANVIEN_MaBP",
                table: "NHANVIEN",
                newName: "IX_NHANVIEN_MaBoPhan");

            migrationBuilder.RenameColumn(
                name: "TenNCC",
                table: "NHACUNGCAP",
                newName: "TenNhaCungCap");

            migrationBuilder.RenameColumn(
                name: "MaNCC",
                table: "NHACUNGCAP",
                newName: "MaNhaCungCap");

            migrationBuilder.RenameColumn(
                name: "MaSP",
                table: "MAUSANPHAM",
                newName: "MaSanPham");

            migrationBuilder.RenameColumn(
                name: "MaSP",
                table: "LICHSUGIA",
                newName: "MaSanPham");

            migrationBuilder.RenameColumn(
                name: "TenKM",
                table: "KHUYENMAI",
                newName: "TenKhuyenMai");

            migrationBuilder.RenameColumn(
                name: "MaKM",
                table: "KHUYENMAI",
                newName: "MaKhuyenMai");

            migrationBuilder.RenameColumn(
                name: "TenKH",
                table: "KHACHHANG",
                newName: "TenKhachHang");

            migrationBuilder.RenameColumn(
                name: "MaKH",
                table: "KHACHHANG",
                newName: "MaKhachHang");

            migrationBuilder.RenameColumn(
                name: "MaKM",
                table: "HOADON",
                newName: "MaKhuyenMai");

            migrationBuilder.RenameColumn(
                name: "MaKH",
                table: "HOADON",
                newName: "MaKhachHang");

            migrationBuilder.RenameColumn(
                name: "MaHD",
                table: "HOADON",
                newName: "MaHoaDon");

            migrationBuilder.RenameIndex(
                name: "IX_HOADON_MaKM",
                table: "HOADON",
                newName: "IX_HOADON_MaKhuyenMai");

            migrationBuilder.RenameIndex(
                name: "IX_HOADON_MaKH",
                table: "HOADON",
                newName: "IX_HOADON_MaKhachHang");

            migrationBuilder.RenameIndex(
                name: "IX_HOADON_MaDiaChiKH_MaKH",
                table: "HOADON",
                newName: "IX_HOADON_MaDiaChiKH_MaKhachHang");

            migrationBuilder.RenameColumn(
                name: "MaHD",
                table: "GIAOHANG",
                newName: "MaHoaDon");

            migrationBuilder.RenameColumn(
                name: "MaGH",
                table: "GIAOHANG",
                newName: "MaGiaoHanh");

            migrationBuilder.RenameColumn(
                name: "MaSP",
                table: "DINHLUONG",
                newName: "MaSanPham");

            migrationBuilder.RenameColumn(
                name: "MaTT",
                table: "DINHLUONG",
                newName: "MaThuocTinh");

            migrationBuilder.RenameIndex(
                name: "IX_DINHLUONG_MaSP",
                table: "DINHLUONG",
                newName: "IX_DINHLUONG_MaSanPham");

            migrationBuilder.RenameColumn(
                name: "MaKH",
                table: "DIACHIKH",
                newName: "MaKhachHang");

            migrationBuilder.RenameIndex(
                name: "IX_DIACHIKH_MaKH",
                table: "DIACHIKH",
                newName: "IX_DIACHIKH_MaKhachHang");

            migrationBuilder.RenameColumn(
                name: "MaSP",
                table: "DANHGIASP",
                newName: "MaSanPham");

            migrationBuilder.RenameColumn(
                name: "MaDG",
                table: "DANHGIASP",
                newName: "MaDanhGia");

            migrationBuilder.RenameColumn(
                name: "MaSP",
                table: "CTNHAPSP",
                newName: "MaSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_CTNHAPSP_MaSP",
                table: "CTNHAPSP",
                newName: "IX_CTNHAPSP_MaSanPham");

            migrationBuilder.RenameColumn(
                name: "MaSP",
                table: "CTHOADON",
                newName: "MaSanPham");

            migrationBuilder.RenameColumn(
                name: "MaHD",
                table: "CTHOADON",
                newName: "MaHoaDon");

            migrationBuilder.RenameIndex(
                name: "IX_CTHOADON_MaSP",
                table: "CTHOADON",
                newName: "IX_CTHOADON_MaSanPham");

            migrationBuilder.RenameColumn(
                name: "TenBP",
                table: "BOPHAN",
                newName: "TenBoPhan");

            migrationBuilder.RenameColumn(
                name: "MaBP",
                table: "BOPHAN",
                newName: "MaBoPhan");

            migrationBuilder.CreateIndex(
                name: "IX_GIAOHANG_MaHoaDon",
                table: "GIAOHANG",
                column: "MaHoaDon",
                unique: true,
                filter: "[MaHoaDon] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DANHGIASP_MaSanPham",
                table: "DANHGIASP",
                column: "MaSanPham",
                unique: true,
                filter: "[MaSanPham] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CTHOADON_HOADON_MaHoaDon",
                table: "CTHOADON",
                column: "MaHoaDon",
                principalTable: "HOADON",
                principalColumn: "MaHoaDon",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CTHOADON_SANPHAM_MaSanPham",
                table: "CTHOADON",
                column: "MaSanPham",
                principalTable: "SANPHAM",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CTNHAPSP_SANPHAM_MaSanPham",
                table: "CTNHAPSP",
                column: "MaSanPham",
                principalTable: "SANPHAM",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DANHGIASP_SANPHAM_MaSanPham",
                table: "DANHGIASP",
                column: "MaSanPham",
                principalTable: "SANPHAM",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DIACHIKH_KHACHHANG_MaKhachHang",
                table: "DIACHIKH",
                column: "MaKhachHang",
                principalTable: "KHACHHANG",
                principalColumn: "MaKhachHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DINHLUONG_SANPHAM_MaSanPham",
                table: "DINHLUONG",
                column: "MaSanPham",
                principalTable: "SANPHAM",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DINHLUONG_THUOCTINH_MaThuocTinh",
                table: "DINHLUONG",
                column: "MaThuocTinh",
                principalTable: "THUOCTINH",
                principalColumn: "MaThuocTinh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GIAOHANG_HOADON_MaHoaDon",
                table: "GIAOHANG",
                column: "MaHoaDon",
                principalTable: "HOADON",
                principalColumn: "MaHoaDon",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HOADON_DIACHIKH_MaDiaChiKH_MaKhachHang",
                table: "HOADON",
                columns: new[] { "MaDiaChiKH", "MaKhachHang" },
                principalTable: "DIACHIKH",
                principalColumns: new[] { "MaDiaChiKH", "MaKhachHang" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HOADON_KHACHHANG_MaKhachHang",
                table: "HOADON",
                column: "MaKhachHang",
                principalTable: "KHACHHANG",
                principalColumn: "MaKhachHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HOADON_KHUYENMAI_MaKhuyenMai",
                table: "HOADON",
                column: "MaKhuyenMai",
                principalTable: "KHUYENMAI",
                principalColumn: "MaKhuyenMai",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LICHSUGIA_SANPHAM_MaSanPham",
                table: "LICHSUGIA",
                column: "MaSanPham",
                principalTable: "SANPHAM",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MAUSANPHAM_SANPHAM_MaSanPham",
                table: "MAUSANPHAM",
                column: "MaSanPham",
                principalTable: "SANPHAM",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANVIEN_BOPHAN_MaBoPhan",
                table: "NHANVIEN",
                column: "MaBoPhan",
                principalTable: "BOPHAN",
                principalColumn: "MaBoPhan",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANXETSP_KHACHHANG_MaKhachHang",
                table: "NHANXETSP",
                column: "MaKhachHang",
                principalTable: "KHACHHANG",
                principalColumn: "MaKhachHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANXETSP_SANPHAM_MaSanPham",
                table: "NHANXETSP",
                column: "MaSanPham",
                principalTable: "SANPHAM",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHAPSANPHAM_NHACUNGCAP_MaNhaCungCap",
                table: "NHAPSANPHAM",
                column: "MaNhaCungCap",
                principalTable: "NHACUNGCAP",
                principalColumn: "MaNhaCungCap",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NHAPSANPHAM_NHANVIEN_MaNhanVien",
                table: "NHAPSANPHAM",
                column: "MaNhanVien",
                principalTable: "NHANVIEN",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_LOAISANPHAM_MaLoai",
                table: "SANPHAM",
                column: "MaLoai",
                principalTable: "LOAISANPHAM",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TINHTRANGIAOHANG_GIAOHANG_MaGiaoHang",
                table: "TINHTRANGIAOHANG",
                column: "MaGiaoHang",
                principalTable: "GIAOHANG",
                principalColumn: "MaGiaoHanh",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CTHOADON_HOADON_MaHoaDon",
                table: "CTHOADON");

            migrationBuilder.DropForeignKey(
                name: "FK_CTHOADON_SANPHAM_MaSanPham",
                table: "CTHOADON");

            migrationBuilder.DropForeignKey(
                name: "FK_CTNHAPSP_SANPHAM_MaSanPham",
                table: "CTNHAPSP");

            migrationBuilder.DropForeignKey(
                name: "FK_DANHGIASP_SANPHAM_MaSanPham",
                table: "DANHGIASP");

            migrationBuilder.DropForeignKey(
                name: "FK_DIACHIKH_KHACHHANG_MaKhachHang",
                table: "DIACHIKH");

            migrationBuilder.DropForeignKey(
                name: "FK_DINHLUONG_SANPHAM_MaSanPham",
                table: "DINHLUONG");

            migrationBuilder.DropForeignKey(
                name: "FK_DINHLUONG_THUOCTINH_MaThuocTinh",
                table: "DINHLUONG");

            migrationBuilder.DropForeignKey(
                name: "FK_GIAOHANG_HOADON_MaHoaDon",
                table: "GIAOHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_HOADON_DIACHIKH_MaDiaChiKH_MaKhachHang",
                table: "HOADON");

            migrationBuilder.DropForeignKey(
                name: "FK_HOADON_KHACHHANG_MaKhachHang",
                table: "HOADON");

            migrationBuilder.DropForeignKey(
                name: "FK_HOADON_KHUYENMAI_MaKhuyenMai",
                table: "HOADON");

            migrationBuilder.DropForeignKey(
                name: "FK_LICHSUGIA_SANPHAM_MaSanPham",
                table: "LICHSUGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_MAUSANPHAM_SANPHAM_MaSanPham",
                table: "MAUSANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANVIEN_BOPHAN_MaBoPhan",
                table: "NHANVIEN");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANXETSP_KHACHHANG_MaKhachHang",
                table: "NHANXETSP");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANXETSP_SANPHAM_MaSanPham",
                table: "NHANXETSP");

            migrationBuilder.DropForeignKey(
                name: "FK_NHAPSANPHAM_NHACUNGCAP_MaNhaCungCap",
                table: "NHAPSANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_NHAPSANPHAM_NHANVIEN_MaNhanVien",
                table: "NHAPSANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_LOAISANPHAM_MaLoai",
                table: "SANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_TINHTRANGIAOHANG_GIAOHANG_MaGiaoHang",
                table: "TINHTRANGIAOHANG");

            migrationBuilder.DropIndex(
                name: "IX_GIAOHANG_MaHoaDon",
                table: "GIAOHANG");

            migrationBuilder.DropIndex(
                name: "IX_DANHGIASP_MaSanPham",
                table: "DANHGIASP");

            migrationBuilder.RenameColumn(
                name: "MaTinhTrangGH",
                table: "TINHTRANGIAOHANG",
                newName: "MaTTGH");

            migrationBuilder.RenameColumn(
                name: "MaGiaoHang",
                table: "TINHTRANGIAOHANG",
                newName: "MaGH");

            migrationBuilder.RenameColumn(
                name: "TenThuocTinh",
                table: "THUOCTINH",
                newName: "TenTT");

            migrationBuilder.RenameColumn(
                name: "MaThuocTinh",
                table: "THUOCTINH",
                newName: "MaTT");

            migrationBuilder.RenameColumn(
                name: "TenSanPham",
                table: "SANPHAM",
                newName: "TenSP");

            migrationBuilder.RenameColumn(
                name: "MaLoai",
                table: "SANPHAM",
                newName: "MaLoaiSP");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "SANPHAM",
                newName: "MaSP");

            migrationBuilder.RenameIndex(
                name: "IX_SANPHAM_MaLoai",
                table: "SANPHAM",
                newName: "IX_SANPHAM_MaLoaiSP");

            migrationBuilder.RenameColumn(
                name: "MaNhanVien",
                table: "NHAPSANPHAM",
                newName: "MaNV");

            migrationBuilder.RenameColumn(
                name: "MaNhaCungCap",
                table: "NHAPSANPHAM",
                newName: "MaNCC");

            migrationBuilder.RenameIndex(
                name: "IX_NHAPSANPHAM_MaNhanVien",
                table: "NHAPSANPHAM",
                newName: "IX_NHAPSANPHAM_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_NHAPSANPHAM_MaNhaCungCap",
                table: "NHAPSANPHAM",
                newName: "IX_NHAPSANPHAM_MaNCC");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "NHANXETSP",
                newName: "MaSP");

            migrationBuilder.RenameColumn(
                name: "MaKhachHang",
                table: "NHANXETSP",
                newName: "MaKH");

            migrationBuilder.RenameIndex(
                name: "IX_NHANXETSP_MaSanPham",
                table: "NHANXETSP",
                newName: "IX_NHANXETSP_MaSP");

            migrationBuilder.RenameColumn(
                name: "TenNhanVien",
                table: "NHANVIEN",
                newName: "TenNV");

            migrationBuilder.RenameColumn(
                name: "MaBoPhan",
                table: "NHANVIEN",
                newName: "MaBP");

            migrationBuilder.RenameColumn(
                name: "MaNhanVien",
                table: "NHANVIEN",
                newName: "MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_NHANVIEN_MaBoPhan",
                table: "NHANVIEN",
                newName: "IX_NHANVIEN_MaBP");

            migrationBuilder.RenameColumn(
                name: "TenNhaCungCap",
                table: "NHACUNGCAP",
                newName: "TenNCC");

            migrationBuilder.RenameColumn(
                name: "MaNhaCungCap",
                table: "NHACUNGCAP",
                newName: "MaNCC");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "MAUSANPHAM",
                newName: "MaSP");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "LICHSUGIA",
                newName: "MaSP");

            migrationBuilder.RenameColumn(
                name: "TenKhuyenMai",
                table: "KHUYENMAI",
                newName: "TenKM");

            migrationBuilder.RenameColumn(
                name: "MaKhuyenMai",
                table: "KHUYENMAI",
                newName: "MaKM");

            migrationBuilder.RenameColumn(
                name: "TenKhachHang",
                table: "KHACHHANG",
                newName: "TenKH");

            migrationBuilder.RenameColumn(
                name: "MaKhachHang",
                table: "KHACHHANG",
                newName: "MaKH");

            migrationBuilder.RenameColumn(
                name: "MaKhuyenMai",
                table: "HOADON",
                newName: "MaKM");

            migrationBuilder.RenameColumn(
                name: "MaKhachHang",
                table: "HOADON",
                newName: "MaKH");

            migrationBuilder.RenameColumn(
                name: "MaHoaDon",
                table: "HOADON",
                newName: "MaHD");

            migrationBuilder.RenameIndex(
                name: "IX_HOADON_MaKhuyenMai",
                table: "HOADON",
                newName: "IX_HOADON_MaKM");

            migrationBuilder.RenameIndex(
                name: "IX_HOADON_MaKhachHang",
                table: "HOADON",
                newName: "IX_HOADON_MaKH");

            migrationBuilder.RenameIndex(
                name: "IX_HOADON_MaDiaChiKH_MaKhachHang",
                table: "HOADON",
                newName: "IX_HOADON_MaDiaChiKH_MaKH");

            migrationBuilder.RenameColumn(
                name: "MaHoaDon",
                table: "GIAOHANG",
                newName: "MaHD");

            migrationBuilder.RenameColumn(
                name: "MaGiaoHanh",
                table: "GIAOHANG",
                newName: "MaGH");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "DINHLUONG",
                newName: "MaSP");

            migrationBuilder.RenameColumn(
                name: "MaThuocTinh",
                table: "DINHLUONG",
                newName: "MaTT");

            migrationBuilder.RenameIndex(
                name: "IX_DINHLUONG_MaSanPham",
                table: "DINHLUONG",
                newName: "IX_DINHLUONG_MaSP");

            migrationBuilder.RenameColumn(
                name: "MaKhachHang",
                table: "DIACHIKH",
                newName: "MaKH");

            migrationBuilder.RenameIndex(
                name: "IX_DIACHIKH_MaKhachHang",
                table: "DIACHIKH",
                newName: "IX_DIACHIKH_MaKH");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "DANHGIASP",
                newName: "MaSP");

            migrationBuilder.RenameColumn(
                name: "MaDanhGia",
                table: "DANHGIASP",
                newName: "MaDG");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "CTNHAPSP",
                newName: "MaSP");

            migrationBuilder.RenameIndex(
                name: "IX_CTNHAPSP_MaSanPham",
                table: "CTNHAPSP",
                newName: "IX_CTNHAPSP_MaSP");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "CTHOADON",
                newName: "MaSP");

            migrationBuilder.RenameColumn(
                name: "MaHoaDon",
                table: "CTHOADON",
                newName: "MaHD");

            migrationBuilder.RenameIndex(
                name: "IX_CTHOADON_MaSanPham",
                table: "CTHOADON",
                newName: "IX_CTHOADON_MaSP");

            migrationBuilder.RenameColumn(
                name: "TenBoPhan",
                table: "BOPHAN",
                newName: "TenBP");

            migrationBuilder.RenameColumn(
                name: "MaBoPhan",
                table: "BOPHAN",
                newName: "MaBP");

            migrationBuilder.CreateIndex(
                name: "IX_GIAOHANG_MaHD",
                table: "GIAOHANG",
                column: "MaHD",
                unique: true,
                filter: "[MaHD] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DANHGIASP_MaSP",
                table: "DANHGIASP",
                column: "MaSP",
                unique: true,
                filter: "[MaSP] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CTHOADON_HOADON_MaHD",
                table: "CTHOADON",
                column: "MaHD",
                principalTable: "HOADON",
                principalColumn: "MaHD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CTHOADON_SANPHAM_MaSP",
                table: "CTHOADON",
                column: "MaSP",
                principalTable: "SANPHAM",
                principalColumn: "MaSP",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CTNHAPSP_SANPHAM_MaSP",
                table: "CTNHAPSP",
                column: "MaSP",
                principalTable: "SANPHAM",
                principalColumn: "MaSP",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DANHGIASP_SANPHAM_MaSP",
                table: "DANHGIASP",
                column: "MaSP",
                principalTable: "SANPHAM",
                principalColumn: "MaSP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DIACHIKH_KHACHHANG_MaKH",
                table: "DIACHIKH",
                column: "MaKH",
                principalTable: "KHACHHANG",
                principalColumn: "MaKH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DINHLUONG_SANPHAM_MaSP",
                table: "DINHLUONG",
                column: "MaSP",
                principalTable: "SANPHAM",
                principalColumn: "MaSP",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DINHLUONG_THUOCTINH_MaTT",
                table: "DINHLUONG",
                column: "MaTT",
                principalTable: "THUOCTINH",
                principalColumn: "MaTT",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GIAOHANG_HOADON_MaHD",
                table: "GIAOHANG",
                column: "MaHD",
                principalTable: "HOADON",
                principalColumn: "MaHD",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HOADON_DIACHIKH_MaDiaChiKH_MaKH",
                table: "HOADON",
                columns: new[] { "MaDiaChiKH", "MaKH" },
                principalTable: "DIACHIKH",
                principalColumns: new[] { "MaDiaChiKH", "MaKH" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HOADON_KHACHHANG_MaKH",
                table: "HOADON",
                column: "MaKH",
                principalTable: "KHACHHANG",
                principalColumn: "MaKH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HOADON_KHUYENMAI_MaKM",
                table: "HOADON",
                column: "MaKM",
                principalTable: "KHUYENMAI",
                principalColumn: "MaKM",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LICHSUGIA_SANPHAM_MaSP",
                table: "LICHSUGIA",
                column: "MaSP",
                principalTable: "SANPHAM",
                principalColumn: "MaSP",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MAUSANPHAM_SANPHAM_MaSP",
                table: "MAUSANPHAM",
                column: "MaSP",
                principalTable: "SANPHAM",
                principalColumn: "MaSP",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANVIEN_BOPHAN_MaBP",
                table: "NHANVIEN",
                column: "MaBP",
                principalTable: "BOPHAN",
                principalColumn: "MaBP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANXETSP_KHACHHANG_MaKH",
                table: "NHANXETSP",
                column: "MaKH",
                principalTable: "KHACHHANG",
                principalColumn: "MaKH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANXETSP_SANPHAM_MaSP",
                table: "NHANXETSP",
                column: "MaSP",
                principalTable: "SANPHAM",
                principalColumn: "MaSP",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHAPSANPHAM_NHACUNGCAP_MaNCC",
                table: "NHAPSANPHAM",
                column: "MaNCC",
                principalTable: "NHACUNGCAP",
                principalColumn: "MaNCC",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NHAPSANPHAM_NHANVIEN_MaNV",
                table: "NHAPSANPHAM",
                column: "MaNV",
                principalTable: "NHANVIEN",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_LOAISANPHAM_MaLoaiSP",
                table: "SANPHAM",
                column: "MaLoaiSP",
                principalTable: "LOAISANPHAM",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TINHTRANGIAOHANG_GIAOHANG_MaGH",
                table: "TINHTRANGIAOHANG",
                column: "MaGH",
                principalTable: "GIAOHANG",
                principalColumn: "MaGH",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
