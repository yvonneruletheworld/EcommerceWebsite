using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        //[Key]
        //[MaxLength(100)]
        //[Required]
        public string Id { get; set; }
        //[StringLength(270,
        //              ErrorMessage = "Tên loại sản phẩm từ 8 kí tự đến 8 kí tự",
        //              MinimumLength = 8)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        //[Required]
        public decimal Const { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public Status Status { get; set; }
        //public string Brands { get; set; }

        //Foreign Key

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
