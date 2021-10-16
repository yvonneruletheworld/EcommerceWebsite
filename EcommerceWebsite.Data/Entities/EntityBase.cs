using System;

namespace EcommerceWebsite.Data.Entities
{
    public class EntityBase
    {
        public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public string NguoiSuaCuoi { get; set; }
        public DateTime? NgaySuaCuoi { get; set; }
        public bool DaXoa { get; set; }
        public DateTime? NgayXoa { get; set; }
        public string NguoiXoa { get; set; }

    }
}