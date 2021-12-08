﻿using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
   public interface IKhuyenMaiServices
    {
        Task<List<BannerOutput>> LayKhuyenMaiChoTrangChu();
        Task<List<KhuyenMai>> layKhuyenMai();
        Task<List<KhuyenMai>> layChiTietKhuyenMai(string MaKM);
    }
}
