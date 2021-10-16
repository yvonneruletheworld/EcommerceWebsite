using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class BoPhan
    {   
        public string MaBoPhan { get; set; }
        public string TenBoPhan { get; set; }
        public List<NhanVien> NhanViens { get; set; }
    }
}
