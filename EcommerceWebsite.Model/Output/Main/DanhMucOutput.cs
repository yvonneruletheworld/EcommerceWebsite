using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class DanhMucOutput : EntityBase
    {
        public string TenDanhMuc { get; set; }
        public string MaDanhMuc { get; set; }
        public string HinhAnh { get; set; }

        public Status TinhTrang { get; set; }
        //Khóa ngoại
    }
}
