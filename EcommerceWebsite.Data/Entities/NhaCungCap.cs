using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public  class NhaCungCap : EntityBase
    {
        public NhaCungCap()
        {
            this.MaNhaCungCap = Guid.NewGuid().ToString();
        }

        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public List<PhieuNhap> PhieuNhaps { get; set; }
    }
}
