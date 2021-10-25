using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Catagory
            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc()
                {
                    Id = "DM001",
                    Name = "Điện thoại",
                    Status = Enum.Status.Active,
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    DaXoa = false,
                    IsShowInHome = true,
                    ParentId = null,
                },
                new DanhMuc()
                {
                    Id = "DM002",
                    Name = "iPhone",
                    Status = Enum.Status.Active,
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    DaXoa = false,
                    IsShowInHome = true,
                    ParentId = "DM001",
                },
                new DanhMuc()
                {
                    Id = "DM003",
                    Name = "Samsung",
                    Status = Enum.Status.Active,
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    DaXoa = false,
                    IsShowInHome = true,
                    ParentId = "DM001",
                });
            //Product
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham()
                {
                    MaSanPham = "SP001",
                    TenSanPham = "Samsung Galaxy Z Fold3 5G 512GB",
                    NhanHieu = "Samsung",
                    NgayTao = DateTime.UtcNow,
                    MaLoaiSanPham = "DM003",
                    NguoiTao = "admin",
                    //Mota = " Z Fold 3 đi kèm với bút S Pen được thiết kế đặc thù, trang bị kính Victus Corning Gorilla Glass và khung điện thoại Armor Frame, cho độ bền tốt hơn. Fold mới sẽ có hai màn hình Dynamic AMOLED 2X, tốc độ làm mới 120 Hz với kích thước 6.28 inch",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                },
                new SanPham()
                {
                    MaSanPham = "SP002",
                    TenSanPham = "Samsung Galaxy Z Flip3 5G 128GB",
                    //Price = 24990000,
                    //Const = 23990000,
                    NhanHieu = "Samsung",
                    NgayTao = DateTime.UtcNow,
                    NguoiTao = "admin",
                    MaLoaiSanPham = "DM003",
                    //Description = " Biểu tượng thời trang độc đáo nằm gọn trong túi khi gập cho bạn thỏa sức tham gia các hoạt động yêu thích ở bất cứ nơi đâu. Siêu phẩm công nghệ khi mở để bạn đắm chìm trải nghiệm với tốc độ mạng 5G và khả năng gập ở nhiều góc độ linh hoạt chưa từng có.1 Không chỉ là điện thoại,đó là một ngôn ngữ thời trang cá tính",
                    DaXoa = false,
                    Status = Enum.Status.Active,
                    SoLuongTon = 1,
                });
            //ProductInDanhMuc
            //modelBuilder.Entity<ProductDanhMuc>().HasData(
            //    new ProductDanhMuc()
            //    {
            //        DanhMucId = "DM003",
            //        ProductId = "SP001"
            //    },
            //    new ProductDanhMuc()
            //    {
            //        DanhMucId = "DM003",
            //        ProductId = "SP002"
            //    });
            // any guid
            //var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            //modelBuilder.Entity<AppRole>().HasData(new AppRole
            //{
            //    Id = roleId,
            //    Name = "admin",
            //    NormalizedName = "admin",
            //    Description = "Administrator role"
            //});

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = adminId.ToString(),
                UserName = "havyclient1",
                NormalizedUserName = "havyclient1",
                Email = "yvonnetran.work@gmail.com",
                NormalizedEmail = "yvonnetran.work@gmail.com",
                PhoneNumber = "0905187524",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                Status = Enum.Status.Active
            });
            
            modelBuilder.Entity<KhachHang>().HasData(new KhachHang
            {
                Id = adminId.ToString(),
                Username = "havyclient1",
                Email = "yvonnetran.work@gmail.com",
                HoTen = "Yvonne Tran",
                GioiTinh = false,
                Sdt = "0905187524",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                UserId = adminId
            });
        }
    }
}
