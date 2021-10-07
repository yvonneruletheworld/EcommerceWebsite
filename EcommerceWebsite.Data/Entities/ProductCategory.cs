using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class ProductCategory
    {
        public string ProductId { get; set; }
        public string CategoryId { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
