using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Models
{
    public static class GioHangOutput
    {
        public static Dictionary<string,List<GioHang>> HUICart { get; set; }
        public static List<GioHang> NormalCart { get; set; }

        //public GioHangOutput()
        //{
        //    HUICart = new Dictionary<string, List<GioHang>>();
        //    NormalCart = new List<GioHang>();
        //}

        public static int CountCart () 
        {
            var countNormal = NormalCart.Sum(nc => nc.soLuong);
            var huiNormal = HUICart.Values
                .Sum(hc => hc.Sum(ci => ci.soLuong));
            return countNormal + huiNormal;
        }
        public static decimal Cash ()
        {
            var countNormal = NormalCart.Sum(nc => nc.dThanhTien);
            var huiNormal = HUICart.Values
                .Sum(hc => hc.Sum(ci => ci.dThanhTien));
            return (decimal)(countNormal + huiNormal);
        }
        
        public static decimal Cash (List<string> Ids)
        {
            var countNormal = NormalCart.Sum(nc => nc.dThanhTien);
            var huiNormal = HUICart.Values
                .Sum(hc => hc.Sum(ci => ci.dThanhTien));
            return (decimal)(countNormal + huiNormal);
        }
        
        public static void AddNormal (GioHang input)
        {
            NormalCart.Add(input);
        }

        public static void AddHUI(List<SanPhamVM> listSanPhamHUI)
        {
            try{
                var cbCode = listSanPhamHUI[0].ComboCode;
                var listCart = listSanPhamHUI.Select(
                    item => new GioHang()
                    {
                        MaSanPham = item.MaSanPham,
                        giaSanPham = item.GiaBan,
                        hinhAnh = item.HinhAnh,
                        soLuong = 1,
                        tenSanPham = item.TenSanPham,
                        comboCode = item.ComboCode,
                        giaBan = item.GiaHUI
                    }).ToList();
                HUICart.Add(cbCode, listCart);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateHUICart(List<GioHang> listSanPhamHUI, string code)
        {
            try{
                HUICart[code] = listSanPhamHUI;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
