using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.System
{
   public class KhachHangOutput 
    {
        private string danhXung;
        public string TenKhachHang { get; set; }
        public bool GioiTinh { get; set; }
        public string Email { get; set; }
        public string DanhXung { get => danhXung; set => danhXung = GioiTinh? "Anh " : "Chị " + value; }
    }
}
