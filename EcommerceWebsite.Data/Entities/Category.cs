using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsShowInHome { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
    }
}
