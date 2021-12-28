using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class NhapVaBanOutput
    {
        public Dictionary<DateTime,List<DoanhThuOutput>> ListNhapBan { get; set; }
        public int DaBan { get; set; }
        public decimal TongBan { get; set; }
    }
}
