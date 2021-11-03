using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Utilities.System;
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
    public class HUIController : ControllerBase
    {
        private readonly IHUIServices _huiServices;

        public HUIController(IHUIServices huiServices)
        {
            _huiServices = huiServices;
        }

        [HttpGet("read-hui")]
        public async Task<List<HUI>> ReadFileInputAsync (string fileName)
        {
            var listHUI = new List<HUI>();
           await foreach (var hui in _huiServices.ReadFromTextToList(fileName))
            {
                listHUI.Add(hui);
            }
            return listHUI;
        }

    }
}
