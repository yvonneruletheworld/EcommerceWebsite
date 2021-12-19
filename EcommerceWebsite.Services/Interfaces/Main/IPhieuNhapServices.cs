using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
    public interface IPhieuNhapServices
    {
        Task<bool> CreateNewInventoryVoucher(PhieuNhap input);
        //Task<bool> CreateNewInventoryVoucherDetail(List<ChiTietNhapSanPham> inputs);
        Task<List<ChiTietNhapSanPham>> GetAllInventoryVoucherDetail(string maPhieuNhap);
        Task<List<PhieuNhap>> GetAllInventoryVoucher();
    }
}
