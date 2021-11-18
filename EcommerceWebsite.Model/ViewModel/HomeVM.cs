using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.ViewModel
{
   public class HomeVM
    {
        public List<DanhMucOutput> DanhMucOutputs { get; set; }
        public List<BannerOutput> BannerOutputs { get; set; }
        public List<SanPhamVM> SanPhamHUIDons { get; set; }
        public List<CategorySetVM> LoaiVaSanPham { get; set; }
    }
}
