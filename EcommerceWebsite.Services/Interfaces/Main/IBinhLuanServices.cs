using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
    public interface IBinhLuanServices
    {
        Task<List<BinhLuanOutput>> LayBinhLuanTheoSanPham(string maSanPham);
    }
}
