using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
  public  interface IKhuyenMaiApiServices
    {
        Task<List<BannerOutput>> LaykhuyenMais();
    }
}
