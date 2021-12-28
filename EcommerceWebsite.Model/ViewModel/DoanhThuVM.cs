using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.ViewModel
{
    public class DoanhThuVM
    {
        public Dictionary<DateTime, List<DoanhThuOutput>> ListSanPhamNhapVaBan;
        public List<ThuocTinh> ListDinhLuong;
        public List<DanhMucOutput> ListDanhMuc;
        public List<NhanHieu> ListNhanHieu;
        public SanPhamOutput SanPham;
    }
}
