using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Const { get; set; }
        public int Stock { get; set; }
        public DateTime DateCreate { get; set; }
        public Status Status { get; set; }
    }
}
