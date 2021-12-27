using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
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
using EcommerceWebsite.Data.Enum;
using AutoMapper;
using EcommerceWebsite.Utilities.Input;
using System.Security.Claims;
using EcommerceWebsite.Data.Entities;

namespace EcommerceWebsite.Admin.Controllers
{
    public class NhapSanPhamController : Controller
    {
        private readonly INhaCungCapApiServices _nhaCungCapApiServices;
        private readonly IDanhMucApiServices _danhMucApiServices;
        private readonly ISanPhamApiServices _sanPhamApiServices;
        private readonly IMapper _mapper;
        public NhapSanPhamController(INhaCungCapApiServices nhaCungCapApiServices, IDanhMucApiServices danhMucApiServices, IMapper mapper, ISanPhamApiServices sanPhamApiServices)
        {
            _nhaCungCapApiServices = nhaCungCapApiServices;
            _danhMucApiServices = danhMucApiServices;
            _mapper = mapper;
            _sanPhamApiServices = sanPhamApiServices;
        }
        public async Task<IActionResult> NhapHang(IEnumerable<SanPhamInput> importList = null)
        {
            try
            {
                var vm = new NhapHangVM();
                vm.DanhMucs = await _danhMucApiServices.GetCategories();
                vm.NhaCungCaps = await _nhaCungCapApiServices.layNhaCungCap();
                vm.phieuNhap = await _sanPhamApiServices.layPhieuNhapSP();
                vm.SanPhamInputs = importList;
                return View("/Views/NhapSanPham/NhapHang.cshtml", vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public async Task<IActionResult> ReadInputExcel(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            //string filePath = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(file.FileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var listProducts = GetListImport(file.FileName);
            HttpContext.Session.Set<IEnumerable<SanPhamInput>>("ListImportPrd", listProducts);
            return await NhapHang(listProducts);
        }

        [HttpPost]
        public async Task<IActionResult> SaveInputExcel([FromQuery] List<SanPhamInput> listImport, string maNhaCungCap, string total, string maLoai)
        {
            var listProducts = listImport.Count() == 0 ? HttpContext.Session.Get<IEnumerable<SanPhamInput>>("ListImportPrd") : listImport;
            var ListChiTietNhap = new List<SanPhamOutput>();
            foreach (var prdImport in listProducts)
            {
                var ct = _mapper.Map<SanPhamOutput>(prdImport);
                ct.MaSanPham = Guid.NewGuid().ToString();
                if (ct != null)
                {
                    //prepare data
                    ct.MaLoai = prdImport.MaLoai;
                    ct.HinhAnh = prdImport.HinhAnh;
                    var maDinhLuong = Guid.NewGuid().ToString();
                    ct.ListThongSo.Add(new ThongSoSanPhamOutput()
                    {
                        MaDinhLuong = maDinhLuong,
                        MaThuocTinh = prdImport.MaThuocTinh,
                        DonVi = prdImport.TenMauMa,
                        GiaTri = prdImport.HinhAnh,
                    });
                    ct.BangGia.Add(new BangGiaOutput()
                    {
                        MaDinhLuong = maDinhLuong,
                        GiaBan = prdImport.GiaNhap,
                        TenDinhLuong = ct.ListThongSo[0].DonVi,
                    });
                    ListChiTietNhap.Add(ct);
                }
            }
            //call api
            //prepare data
            var userId = string.Empty;
            if (User.Claims != null && User.Claims.Count() > 1)
            {
                userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                               .FirstOrDefault()
                               .Value;
            }

            // create new input model
            var phieuNhapInput = new PhieuNhapInput()
            {
                CreatorId = userId,
                Investor = maNhaCungCap,
                Totalvalue = total,
                ListSanPhamInput = ListChiTietNhap
            };

            var resultInsert = await _sanPhamApiServices.ThemPhieuNhap(phieuNhapInput);

            if (resultInsert)
            {
                HttpContext.Session.Remove("ListImportPrd");
                var maPhieuNhap = HttpContext.Session.GetString("MaPhieuNhap");
                return Json(new { code = 200 });
            }
            else return Json(new { code = 500 });
        }
        
        private IEnumerable<SanPhamInput> GetListImport(string fileName)
        {
           // var filePath = $"D:\\School\triplev-store\\EcommerceWebsite.Admin\\wwwroot\\files\\{fileName}";
            //var filePath = $"{ Directory.GetCurrentDirectory()}{@"\wwwroot\files}"}" +"\\" + fileName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        var prd = new SanPhamInput()
                        {
                            TenSanPham = reader.GetValue(0).ToString(),
                            NhanHieu = reader.GetValue(1).ToString().Trim(),
                            MaLoai = reader.GetValue(2).ToString().Trim(),
                            TenMauMa = reader.GetValue(3).ToString(),
                            SoLuongNhap = int.Parse(reader.GetValue(4).ToString().Trim()),
                            GiaNhap = decimal.Parse(reader.GetValue(5).ToString().Trim()),
                            ThanhTien = decimal.Parse(reader.GetValue(6).ToString().Trim()),
                            HinhAnh = reader.GetValue(7).ToString(),
                            MaThuocTinh = nameof(ProductPorpertyCode.TT014)
                        };

                        yield return prd;
                    }
                }
            }
        }

     
    }
}
