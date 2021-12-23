using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
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
        Task<List<DoanhThuOutput>> GetListImportProduct(string maSanPham);
        Task<decimal> GetRecentlyPrice(string maSanPham);
    }
}
