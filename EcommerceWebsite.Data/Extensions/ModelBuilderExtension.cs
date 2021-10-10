using EcommerceWebsite.Data.Entities;
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
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = "DM001",
                    Name = "Điện thoại",
                    Status = Enum.Status.Active,
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = "admin",
                    IsDeleted = false,
                    IsShowInHome = true,
                    ParentId = null,
                },
                new Category()
                {
                    Id = "DM002",
                    Name = "iPhone",
                    Status = Enum.Status.Active,
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = "admin",
                    IsDeleted = false,
                    IsShowInHome = true,
                    ParentId = "DM001",
                },
                new Category()
                {
                    Id = "DM003",
                    Name = "Samsung",
                    Status = Enum.Status.Active,
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = "admin",
                    IsDeleted = false,
                    IsShowInHome = true,
                    ParentId = "DM001",
                });
            //Product
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = "SP001",
                    Name = "Samsung Galaxy Z Fold3 5G 512GB",
                    Price = 44990000,
                    Const = 43990000,
                    Brand = "Samsung",
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = "admin",
                    Description = " Z Fold 3 đi kèm với bút S Pen được thiết kế đặc thù, trang bị kính Victus Corning Gorilla Glass và khung điện thoại Armor Frame, cho độ bền tốt hơn. Fold mới sẽ có hai màn hình Dynamic AMOLED 2X, tốc độ làm mới 120 Hz với kích thước 6.28 inch",
                    IsDeleted = false,
                    Status = Enum.Status.Active,
                    Stock = 1,
                    ViewCount = 0
                },
                new Product()
                {
                    Id = "SP002",
                    Name = "Samsung Galaxy Z Flip3 5G 128GB",
                    Price = 24990000,
                    Const = 23990000,
                    Brand = "Samsung",
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = "admin",
                    Description = " Biểu tượng thời trang độc đáo nằm gọn trong túi khi gập cho bạn thỏa sức tham gia các hoạt động yêu thích ở bất cứ nơi đâu. Siêu phẩm công nghệ khi mở để bạn đắm chìm trải nghiệm với tốc độ mạng 5G và khả năng gập ở nhiều góc độ linh hoạt chưa từng có.1 Không chỉ là điện thoại,đó là một ngôn ngữ thời trang cá tính",
                    IsDeleted = false,
                    Status = Enum.Status.Active,
                    Stock = 1,
                    ViewCount = 0
                });
            //ProductInCategory
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory()
                {
                    CategoryId = "DM003",
                    ProductId = "SP001"
                },
                new ProductCategory()
                {
                    CategoryId = "DM003",
                    ProductId = "SP002"
                });
        }
    }
}
