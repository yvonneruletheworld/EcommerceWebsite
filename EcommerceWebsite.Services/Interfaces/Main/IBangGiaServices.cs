using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
    public interface IBangGiaServices
    {
        Task<BangGiaOutput> GetGiaSanPhamMoiNhat(string id);
        Task<bool> ThemGia(LichSuGia input);
        Task<bool> ModifyPrice(LichSuGia ls);
        Task<List<BangGiaOutput>> LayBangGiaSanPham(string prdId);
    }
}
