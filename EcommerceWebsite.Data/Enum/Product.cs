using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Data.Enum
{
    public enum  ProductPorpertyCode
    {
        [Display(Name = "TT014")]
        [Description("Thuộc tính mẫu mã")]
        TT014,
        [Display(Name = "TT07")]
        [Description("Thuộc tính dung lượng")]
        TT07
    }
}


