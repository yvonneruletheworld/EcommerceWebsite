using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.ViewModel
{
    public class CategorySetVM
    {
        public string TenDanhMuc { get; set; }
        public string MaDanhMuc { get; set; }
        public List<DanhMucOutput> ListDanhMucCon { get; set;}
        public List<SanPhamVM> ListSanPham { get; set;}
    }
}
