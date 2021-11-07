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
}
