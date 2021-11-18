using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Data.Enum
{
    public enum Status
    {
        [Display(Name = "Active")]
        [Description("Sản phẩm khả dụng")]
        Active = 1,
        [Display(Name = "Inactive")]
        [Description("Sản phẩm không khả dụng")] 
        InActive = 0,
        [Display(Name = "Hot")]
        [Description("Sản phẩm nổi bật")] 
        Hot = 3,
    }
}
