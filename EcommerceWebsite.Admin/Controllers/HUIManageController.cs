using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Utilities.Output.System;
using EcommerceWebsite.Data.Entities;

namespace EcommerceWebsite.Admin.Controllers
{
    public class HUIManageController : Controller
    {
        private readonly IHUIApiServices _huiApiServices;

        public HUIManageController(IHUIApiServices huiApiServices)
        {
            _huiApiServices = huiApiServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var vm = new HUIManageVM();
            vm.ListHuiVaDoanhSo = await _huiApiServices.GetListHUIFromData();
            return View("/Views/HUIManage/Index.cshtml",vm);
        }
       
        public async Task<IActionResult> NhapNewHUI()
        {
            // doc hui

            var fileName = "output1";
            var huiReadRs = await _huiApiServices.GetListHUIFromOutput(fileName);

            if(huiReadRs != null && huiReadRs.Count() > 0)
            {
                var addResult = await _huiApiServices.AddListHui(huiReadRs,"add", DateTime.Now.ToString("s"));
                return Json(new { code = addResult? 1 : 2 });

            }
            //HttpContext.Session.Set<List<HUI>>("ListImportHUI", huiReadRs);
            return Json(new { code = 2 });
        }
        
        public async Task<IActionResult> XuatNewData(string min)
        {
            // doc data
            var result = await _huiApiServices.GetListHUIForInput("import",DateTime.Now.ToString("s"));
            if (result != null)
            {
                //prepare data 
                //Tính TU
                var dicHoaDon = result.GroupBy(ct => ct.HoaDons.NgayTao)
                    .ToDictionary(ct => ct.Key, ct => ct.ToList());
                var lines = new List<string>();
                lines.Add(min.Trim());
                foreach (var hd in dicHoaDon)
                {
                    var chiTiets = hd.Value;
                    var newLinePrd = "";
                    var newLineUtil = "";
                    int TU = 0;
                    foreach ( var ct in chiTiets)
                    {
                        newLinePrd += chiTiets.IndexOf(ct) != chiTiets.Count() - 1 ?
                            ct.SanPhams.NguoiXoa + " " : ct.SanPhams.NguoiXoa +":";
                        newLineUtil += chiTiets.IndexOf(ct) != chiTiets.Count() - 1 ?
                            (int)ct.SanPhams.Utility * ct.SoLuong + " " : (int)ct.SanPhams.Utility * ct.SoLuong + "";
                        TU += (int)ct.SanPhams.Utility * ct.SoLuong;
                        if(chiTiets.IndexOf(ct) == chiTiets.Count() - 1)
                        {
                            newLinePrd = newLinePrd + TU + ":" + newLineUtil;
                            lines.Add(newLinePrd);
                        }    
                    }    
                }

                //write

                string[] lineArray = lines.ToArray();
                try
                {
                    System.IO.File.WriteAllLines(@"D:\Applications\eclipse-workspace\java.huiminer_190921\src\tools\contextHUIM.txt", lines);
                    //System.IO.File.WriteAllLines(@"D:\KhoaLuan\BaiLam\BaiThu\src\tools\contextHUIM.txt", lines);
                    //update ngày sua cuoi
                    var rsUpdate = await _huiApiServices.UpdateNgaySua(DateTime.Now);

                    return Json(new { code = rsUpdate ? 1 : 2 });
                }
                catch (Exception err)
                {
                    throw err;
                }
                    
            }

            return Json(new { code =  2 });
        }

        public List<DoanhThuOutput> SetUpGiaChoHUIItemset(List<DoanhThuOutput> listSanPhamHUI, int mucLoiNhuan)
        {
            //tinh tong gia nhap moi nhat
            var tongGiaNhap = listSanPhamHUI.Sum(hui => hui.DonGiaNhap);
            var tongGiaHui = tongGiaNhap * (tongGiaNhap * (mucLoiNhuan / 100));
            foreach (var hui in listSanPhamHUI)
            {
                // tinh thi phan cua moi san pham so voi tong nhanh chung
                hui.LoiNhuan = (float)(hui.DonGiaNhap / tongGiaNhap);
                hui.GiaHUI = (decimal)((float)tongGiaHui * hui.LoiNhuan);
            }
            return listSanPhamHUI;
        }

    }
}
