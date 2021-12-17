using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Admin.Controllers
{
    public class NhapSanPhamController : Controller
    {
        private readonly INhaCungCapApiServices _nhaCungCapApiServices;
        private readonly IDanhMucApiServices _danhMucApiServices;
        public NhapSanPhamController(INhaCungCapApiServices nhaCungCapApiServices, IDanhMucApiServices danhMucApiServices)
        {
            _nhaCungCapApiServices = nhaCungCapApiServices;
            _danhMucApiServices = danhMucApiServices;
        }
        public async Task<IActionResult> NhapHang(IEnumerable<SanPhamInput> importList = null)
        {
            try
            {
                var vm = new NhapHangVM();
                vm.DanhMucs = await _danhMucApiServices.GetCategories();
                vm.NhaCungCaps = await _nhaCungCapApiServices.layNhaCungCap();
                vm.SanPhamInputs = importList;
                return View("/Views/NhapSanPham/NhapHang.cshtml", vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> ReadInputExcel(IFormFile file , IHostingEnvironment hostingEnvironment)
        {
            string filePath = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(filePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var listProducts = GetListImport(file.FileName);
            return await NhapHang(listProducts);
        }

        private IEnumerable<SanPhamInput> GetListImport(string fileName)
        {
            var filePath = $"{ Directory.GetCurrentDirectory()}{@"\wwwroot\files}"}" +"\\" + fileName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using(var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using(var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while(reader.Read())
                    {
                        var prd = new SanPhamInput()
                        {
                            TenSanPham = reader.GetValue(1).ToString(),
                            NhanHieu = reader.GetValue(2).ToString(),
                            TenMauMa = reader.GetValue(3).ToString(),
                            SoLuongNhap = int.Parse(reader.GetValue(4).ToString().Trim()),
                            GiaNhap = decimal.Parse(reader.GetValue(5).ToString().Trim()),
                            ThanhTien = decimal.Parse(reader.GetValue(6).ToString().Trim())
                        };

                        yield return prd;
                    }
                }
            }
        }
    }
}
