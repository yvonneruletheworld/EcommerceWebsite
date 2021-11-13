using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class DanhMuc: EntityBase
    {
        public DanhMuc()
        {
            this.MaDanhMuc = Guid.NewGuid().ToString();
        }
        public string MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public bool HienThiTrangHome { get; set; }
        public string HinhAnh { get; set; }
        public string ParentId { get; set; }
        public Status Status { get; set; }
        public List<SanPham> SanPhams { get; set; }
    }
}
