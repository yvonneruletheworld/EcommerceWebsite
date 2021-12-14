using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Models
{
    public class GioHangOutput
    {
        public List<GioHang> HUICart { get; set; }
        public List<GioHang> NormalCart { get; set; }

    }
}
