using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
    public interface ILichSuGiaServices
    {
        Task<bool> ThemGiaMoiTheoMaSanPham(LichSuGia input);
    }
}
