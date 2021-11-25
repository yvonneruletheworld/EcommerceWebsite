using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class BinhLuanOutput
    {
        private string nguoiTao;
        public string NoiDung { get; set; }
        public int SoSao { get; set; }
        public DateTime NgayTao { get; set; }
        public bool GioiTinh { get; set; }
        public string NguoiTao {
            get { return nguoiTao; }
            set {
                nguoiTao = GioiTinh ? "Anh " : "Chị " + value;
            } }
    }
}
