using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class BoPhan
    {
        public string MaBP { get; set; }
        public string TenBP { get; set; }
        public List<NhanVien> nhanViens { get; set; }
    }
}
