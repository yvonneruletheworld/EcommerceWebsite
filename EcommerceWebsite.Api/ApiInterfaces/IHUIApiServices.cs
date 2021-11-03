using EcommerceWebsite.Utilities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.ApiInterfaces
{
    public interface IHUIApiServices
    {
        Task<List<HUI>> GetListHuiFromApi();
    }
}
