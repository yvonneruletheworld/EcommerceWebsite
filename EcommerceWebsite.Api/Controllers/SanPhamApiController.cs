using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Output.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamApiController : ControllerBase
    {
        private readonly ISanPhamServices _sanPhamServices;

        public SanPhamApiController(ISanPhamServices sanPhamServices)
        {
            _sanPhamServices = sanPhamServices;
        }

        [HttpGet("lay-chi-tiet-san-pham")]
        public async Task<ChiTietSanPhamOutput> ChiTietSanPham (string id)
        {
            var rs = await _sanPhamServices.LayChiTietSanPham(id, true);

            return rs;
        }
    }
}
