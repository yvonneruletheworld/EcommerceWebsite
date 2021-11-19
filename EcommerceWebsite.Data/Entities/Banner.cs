using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class Banner
    {
        public string MaBanner { get; set; }
        public string HinhAnhBanner { get; set; }
        public string MaKhuyenMai { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
    }
}
