using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Data.Enum
{
    public enum LoaiDiaChiEnum
    {
        [Display(Name ="Cá nhân")]
        [Description("Địa chỉ cá nhân")]
        CaNhan = 1,
        [Display(Name = "Công ty")]
        [Description("Địa chỉ công ty")]
        CongTy = 2
    }
    
    public enum LoaiTruyCap
    {
        [Display(Name ="Login")]
        [Description("Đăng nhập khách hàng")]
        Login = 1,
        [Display(Name = "Register")]
        [Description("Đăng ký khách hàng")]
        Register = 2
    }
}
