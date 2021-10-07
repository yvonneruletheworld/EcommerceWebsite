﻿using EcommerceWebsite.Data.Enum;
using EcommerceWebsite.Media.Strings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class Category: EntityBase
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        //[Key]
        //[MaxLength(100)]
        //[Required]
        public string Id { get; set; }
        //[Required]
        //[StringLength(270,
        //              ErrorMessage = "Tên loại sản phẩm từ 8 kí tự đến 8 kí tự",
        //              MinimumLength = 8)]
        public string Name { get; set; }
        public bool IsShowInHome { get; set; }
        public string ParentId { get; set; }
        public Status Status { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
